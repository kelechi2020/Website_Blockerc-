using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace WebsiteBlocker
{
    public static class FileReader
    {
        public static string redirect = "127.0.0.1";
        public static string hostPath = @"E:\hosts";

        public static string[] websites = { "account.jetbrains.com", "www.google.com", "google.com", "facebook.com", "nairaland.com", "www.nairaland.com", "http://www.su-kam.com/load-chart.aspx" };

        public static void BlockSites()
        {

            FileStream fs = new FileStream(hostPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            StreamReader hostFile = new StreamReader(fs);
            StreamWriter sw = new StreamWriter(fs);

            string file = hostFile.ReadToEnd();


            foreach (var website in websites)
            {

                if (!file.Contains(website))
                {
                    sw.WriteLine($"{redirect}  {website}");
                    sw.Flush();

                }
            }

        }

        public static void UnblockSites()
        {
            string[] file = File.ReadAllLines(hostPath);
            foreach (var website in websites)
            {
                file = file.Where(x => x != website).ToArray();                
            }

            foreach (var item in file)
            {
                Console.WriteLine(item);
            }

            File.WriteAllLines(hostPath, file);
        }
    }
}
