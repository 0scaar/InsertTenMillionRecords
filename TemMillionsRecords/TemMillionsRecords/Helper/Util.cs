using TemMillionsRecords.Code;

namespace TemMillionsRecords.Helper
{
    public class Util
    {
        public static void CreateFileWithData(int records, string route)
        {
            if (File.Exists(route))
            {
                File.Delete(route);
            }

            using (StreamWriter writer = new StreamWriter(route, append: true))
            {
                for (int i = 1; i <= records; i++)
                {
                    writer.WriteLine($"value {i}");
                }
            }
        }

        public static void Warmup(string route)
        {
            CreateFileWithData(1000000, route);
            //EfficientCode.InsertData(route);
        }
    }
}
