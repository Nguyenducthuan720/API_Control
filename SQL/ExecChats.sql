CREATE PROCEDURE [dbo].[ExecChats]
    @type VARCHAR(50),
    @language VARCHAR(10),
    @CmpnID INT,
    @UserIDCurent INT,
    @ID INT = NULL,
    @FactorID VARCHAR(50) = NULL,
    @EntryID VARCHAR(50) = NULL,
    @OID VARCHAR(50) = NULL,
    @UserID INT = NULL,
    @ChatType VARCHAR(50) = NULL,
    @ChatMessage NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @type NOT IN ('GET', 'GET-BYID', 'ADD', 'EDIT', 'DEL')
    BEGIN
        SELECT NLConfiguration.dbo.[F_GetDataErrCode]('005', @language) ErrDescription, '005' Valuerr
        RETURN
    END

    IF @type = 'GET'
    BEGIN
        SELECT 
            ID,
            FactorID,
            EntryID,
            OID,
            UserID,
            ChatType,
            ChatMessage,
            ChangeUser,
            ChangeDate,
            NLConfiguration.dbo.[F_GetDataErrCode]('0', @language) ErrDescription,
            '0' Valuerr
        FROM Chats
        WHERE FactorID = @FactorID
        AND EntryID = @EntryID
        AND OID = @OID
        AND IsDeleted = 0
        ORDER BY CreateDate DESC
        RETURN
    END

    IF @type = 'GET-BYID'
    BEGIN
        -- Bảng 1: Thông tin chi tiết chat
        SELECT 
            ID,
            FactorID,
            EntryID,
            OID,
            UserID,
            ChatType,
            ChatMessage,
            ChangeUser,
            ChangeDate,
            NLConfiguration.dbo.[F_GetDataErrCode]('0', @language) ErrDescription,
            '0' Valuerr
        FROM Chats
        WHERE ID = @ID
        AND IsDeleted = 0;

        -- Bảng 2: Lịch sử thao tác
        EXEC NLConfiguration.dbo.ExecMediaHistories 
            @type = 'GET', 
            @FactorID = 'Chats', 
            @EntryID = 'ChatByOID', 
            @OID = @ID, 
            @Language = @language;
        RETURN
    END

    IF @type = 'ADD'
    BEGIN
        DECLARE @NewID INT;

        INSERT INTO Chats (
            FactorID,
            EntryID,
            OID,
            UserID,
            ChatType,
            ChatMessage,
            CreateUser,
            CreateDate,
            ChangeUser,
            ChangeDate,
            IsDeleted
        )
        VALUES (
            @FactorID,
            @EntryID,
            @OID,
            @UserID,
            @ChatType,
            @ChatMessage,
            CAST(@UserIDCurent AS VARCHAR(50)),
            GETDATE(),
            CAST(@UserIDCurent AS VARCHAR(50)),
            GETDATE(),
            0
        );

        SET @NewID = SCOPE_IDENTITY();

        IF @NewID IS NOT NULL
        BEGIN
            -- Ghi log
            EXEC NLConfiguration.dbo.ExecMediaHistories 
                @type = 'ADD', 
                @FactorID = 'Chats', 
                @EntryID = 'ChatByOID', 
                @OID = @NewID, 
                @ActionTypeID = 1, 
                @UserIDCurent = @UserIDCurent;

            SELECT 
                @NewID AS ID,
                NLConfiguration.dbo.[F_GetDataErrCode]('0', @language) ErrDescription,
                '0' Valuerr;
        END
        ELSE
        BEGIN
            SELECT 
                NLConfiguration.dbo.[F_GetDataErrCode]('400', @language) ErrDescription,
                '400' Valuerr;
        END
        RETURN
    END

    IF @type = 'EDIT'
    BEGIN
        -- Kiểm tra tồn tại
        IF NOT EXISTS (SELECT 1 FROM Chats WHERE ID = @ID AND IsDeleted = 0)
        BEGIN
            SELECT NLConfiguration.dbo.[F_GetDataErrCode]('400', @language) ErrDescription, '400' Valuerr;
            RETURN
        END

        UPDATE Chats
        SET 
            FactorID = @FactorID,
            EntryID = @EntryID,
            OID = @OID,
            UserID = @UserID,
            ChatType = @ChatType,
            ChatMessage = @ChatMessage,
            ChangeUser = CAST(@UserIDCurent AS VARCHAR(50)),
            ChangeDate = GETDATE()
        WHERE ID = @ID
        AND IsDeleted = 0;

        -- Ghi log
        EXEC NLConfiguration.dbo.ExecMediaHistories 
            @type = 'ADD', 
            @FactorID = 'Chats', 
            @EntryID = 'ChatByOID', 
            @OID = @ID, 
            @ActionTypeID = 1, 
            @UserIDCurent = @UserIDCurent;

        SELECT 
            @ID AS ID,
            NLConfiguration.dbo.[F_GetDataErrCode]('0', @language) ErrDescription,
            '0' Valuerr;
        RETURN
    END

    IF @type = 'DEL'
    BEGIN
        -- Kiểm tra tồn tại
        IF NOT EXISTS (SELECT 1 FROM Chats WHERE ID = @ID AND IsDeleted = 0)
        BEGIN
            SELECT NLConfiguration.dbo.[F_GetDataErrCode]('400', @language) ErrDescription, '400' Valuerr;
            RETURN
        END

        UPDATE Chats
        SET 
            IsDeleted = 1,
            ChangeUser = CAST(@UserIDCurent AS VARCHAR(50)),
            ChangeDate = GETDATE()
        WHERE ID = @ID
        AND IsDeleted = 0;

        SELECT 
            @ID AS ID,
            NLConfiguration.dbo.[F_GetDataErrCode]('0', @language) ErrDescription,
            '0' Valuerr;
        RETURN
    END
END 