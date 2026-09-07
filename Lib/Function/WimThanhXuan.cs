using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace APISmartCity.Lib.Function
{

    public class WimThanhXuan
    {
        public static dynamic GetDataLogger(int laneID, string _WimSLowSpeedDB)
        {
            dynamic DataLogger = null;

            try
            {
                using (IDbConnection conn = new SqlConnection(_WimSLowSpeedDB))
                {
                    conn.Open();

                    string query = "SELECT * FROM LaneDevicesAPI WHERE LaneID = @LaneID and IsActive = 1 and Symbol = 'W' ";
                    DataLogger = conn.QueryFirstOrDefault<dynamic>(query, new { LaneID = laneID });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return DataLogger;
        }
        public static int GetWeightVehicle(string LicensePlate, string _WimSLowSpeedDB)
        {
            int WeightNo = 0;

            try
            {
                using (IDbConnection conn = new SqlConnection(_WimSLowSpeedDB))
                {
                    conn.Open();

                    string query = "Select WeightNo From Vehicles where LicensePlates = @LicensePlates ";
                    WeightNo = conn.QueryFirstOrDefault<int>(query, new { LicensePlate = LicensePlate });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }

            return WeightNo;
        }

        public static int Read_Data_LogWim(byte[] data, int startIndex, int Lengget)
        {

            if (startIndex + Lengget <= data.Length)
            {
                byte[] ByteRead = new byte[Lengget];

                for (int i = 0; i < Lengget; i++)
                {
                    ByteRead[i] = data[startIndex + i];
                }

                int intValue = List2Dec(ByteRead);

                Console.WriteLine(intValue);

                return intValue;
            }

            return 0;
        }
        static int List2Dec(byte[] val)
        {
            int res = 0;
            int a = 0;
            for (int i = val.Length - 1; i >= 0; i--)
            {
                res += val[i] * (int)Math.Pow(2, a);
                a += 8;
            }
            return res;
        }
        public static byte[] Weigh_request(string IPAddress)//0W
        {
            Console.WriteLine("Can Xe");
            byte[] package = { 2, 6, 0x30, 0x50, 0, 3 };

            // Tính giá trị CRC và cập nhật vào gói tin
            byte crc = CalculateCRC(package);
            package[package.Length - 2] = crc;

            Console.WriteLine("C# Equivalent Package:");

            return SendAndGetData(package, 8000, IPAddress);
        }
        public static byte[] ModifyValueOfZero(string IPAddress)
        {
            byte[] package = { 2, 25, 0x30, 0x63, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0x26, 0x3b, 0x26, 0x3b, 2, 1, 5, 9, 0, 0, 0 };

            // Tính giá trị CRC và cập nhật vào gói tin
            byte crc = CalculateCRC(package);
            package[package.Length - 2] = crc;

            Console.Write("C# Equivalent Package:");

            return SendAndGetData(package, 8000, IPAddress);

        }

        public static byte CalculateCRC(byte[] data)
        {
            byte crc = 0;

            // Exclude the last two elements from the XOR operation
            for (int i = 0; i < data.Length - 2; i++)
            {
                crc ^= data[i];
            }
            return crc;
        }

        public static byte[] SendAndGetData(byte[] data = null, int port = 0, string IPAddress = "")
        {
            byte[] a = new byte[10];

            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(IPAddress, port);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed");
                    return a;
                }
                try
                {
                    if (data != null)
                    {
                        NetworkStream stream = client.GetStream();
                        stream.Write(data, 0, data.Length);

                        byte[] receivedData = new byte[1024];
                        int bytesRead = stream.Read(receivedData, 0, receivedData.Length);

                        Console.WriteLine($"Receive: {BitConverter.ToString(receivedData, 0, bytesRead)}");
                        return receivedData;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message.ToString());
                }
            }
            return a;
        }
    }
}