namespace APISmartCity.Models
{
    public class Notifications
    {
        public class Request
        {
            public class Add
            {
                /// <summary>
                /// Tiêu đề thông báo
                /// </summary>
                /// <example>Tiêu đề thông báo</example>
                public string? Title { get; set; }

                /// <summary>
                /// Tiêu đề thông báo (tiếng Anh)
                /// </summary>
                /// <example>Message Title</example>
                public string? TitleExtention1 { get; set; }

                /// <summary>
                /// TitleExtention2
                /// </summary>
                /// <example>1</example>
                public string? TitleExtention2 { get; set; }

                /// <summary>
                /// TitleExtention3
                /// </summary>
                /// <example>1</example>
                public string? TitleExtention3 { get; set; }

                /// <summary>
                /// TitleExtention4
                /// </summary>
                /// <example>1</example>
                public string? TitleExtention4 { get; set; }

                /// <summary>
                /// TitleExtention5
                /// </summary>
                /// <example>1</example>
                public string? TitleExtention5 { get; set; }

                /// <summary>
                /// TitleExtention6
                /// </summary>
                /// <example>1</example>
                public string? TitleExtention6 { get; set; }

                /// <summary>
                /// TitleExtention7
                /// </summary>
                /// <example>1</example>
                public string? TitleExtention7 { get; set; }

                /// <summary>
                /// TitleExtention8
                /// </summary>
                /// <example>1</example>
                public string? TitleExtention8 { get; set; }

                /// <summary>
                /// TitleExtention9
                /// </summary>
                /// <example>1</example>
                public string? TitleExtention9 { get; set; }

                /// <summary>
                /// Nội dung thông báo
                /// </summary>
                /// <example>Nội dung thông báo</example>
                public string? Body { get; set; }

                /// <summary>
                /// Nội dung thông báo (tiếng Anh)
                /// </summary>
                /// <example>Message content</example>
                public string? BodyExtention1 { get; set; }

                /// <summary>
                /// BodyExtention2
                /// </summary>
                /// <example>1</example>
                public string? BodyExtention2 { get; set; }

                /// <summary>
                /// BodyExtention3
                /// </summary>
                /// <example>1</example>
                public string? BodyExtention3 { get; set; }

                /// <summary>
                /// BodyExtention4
                /// </summary>
                /// <example>1</example>
                public string? BodyExtention4 { get; set; }

                /// <summary>
                /// BodyExtention5
                /// </summary>
                /// <example>1</example>
                public string? BodyExtention5 { get; set; }

                /// <summary>
                /// BodyExtention6
                /// </summary>
                /// <example>1</example>
                public string? BodyExtention6 { get; set; }

                /// <summary>
                /// BodyExtention7
                /// </summary>
                /// <example>1</example>
                public string? BodyExtention7 { get; set; }

                /// <summary>
                /// BodyExtention8
                /// </summary>
                /// <example>1</example>
                public string? BodyExtention8 { get; set; }

                /// <summary>
                /// BodyExtention9
                /// </summary>
                /// <example>1</example>
                public string? BodyExtention9 { get; set; }

                /// <summary>
                /// Danh sách nhóm khách hàng. Tất cả gửi %, nếu không gửi danh sách nhóm khách hàng
                /// </summary>
                /// <example>5008,5016,5017</example>
                public string? DataKey { get; set; }

                /// <summary>
                /// Base64 hoặc link hình
                /// </summary>
                /// <example>iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAAsQAAALEBxi1JjQAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAALmSURBVEiJrZNbiE1RGMd/a++19zlz5sycuTAzjDHNGObMhISk1JgRwoOaco5SPCjXePBCUYg3orwhUmiQUpTyoFyLojTJqDMTyiWX4xLmcvZtediHKXM2Zw7/2u3V+n//77e+vdqCPKVOJWoIa3cRaNh0itUXuvPJafkCkNpSKszxNEYbkNxWXYlF/xcgVAipCWIGtJSUouuX1Nnkxn8CqNOdVWrv3t9qBEQroLU0Skg/qM4l9xUEUF2JXRjGc+I9j9WpRM1wIgz1O6GkHlpLooT1bepCcs/oJ9C0xdQXR6gtnkKR9gho/uXJGMTmgdSgpiiKEguC2ggAdaNd8rZuMzK8GEEIACczATczmYZikEKj75tLVZFHfZlJxRJIX4GPQ4rnAx56KIUMvfZHJ4Pbf43qN0dFx01HApBuOMG4eIKmhRF0YxjvOfDwJJRnIB6ToMDLQPoyvHPgc0TQvlVHky1ACwCuDb3X20mHZ8LNtf4E51d/ZcWJEnRz5IxWP9zYDzINdVn4SwucMdCxG8zikRknA5fWfxMrT5f6d6CUkbM5gBGByiYY8Ib3BhRUTva9XJIh8DwD/vYfuDbcOQgf7kOjAXYW0mTCh3tw54Bf8wcFA6x+uL4brBRM0CCVgfcOCAml06DRBKs3W9NfAODBcTDfQ6WAlA3lcUCAMKB2E5S1wUTDr3lwrACAZsAg8MyFth1QO2vYUx6ooexaEHh/gAx05myAN4/8C45UwJeX2YY2vDoCA33wwgJjIsxeVwBAN6Buzsh95cD3XnhmQ/l0mLsFNL0AwO8Swn9bHvRZMGkpTEv+NZY/YGwzdHvwyYUZa2BSR16x/AGxOlh2yF8Xlecdyx8wysY/JVTXqrd4bjWG6QTVoBCBDqicnm1JNP2dRIgYy7dD0DRfbsFgKjc60gyxtuDjXz0ck2iyl9c9U6ltzX3Ksvn+M1q9eqLQ9ZRQZxJNmJGLuHY84EOMXgow5FOGBpM/AFGr3gdOdqReAAAAAElFTkSuQmCC</example>
                public string? Image { get; set; }

                /// <summary>
                /// Đặt lịch
                /// </summary>
                /// <example>1</example>
                public int? IsSchedule { get; set; }

                /// <summary>
                /// Ngày đặt lịch
                /// </summary>
                /// <example>2021-03-03 14:12:40.733</example>
                public string? ScheduleDate { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Ghi chú</example>
                public string? Note { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }

            public class EditStatus : Del
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class ResetSend : Del
            {
            }
        }

        public class Response
        {
        }
    }
}