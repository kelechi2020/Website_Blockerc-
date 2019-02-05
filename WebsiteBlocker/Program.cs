using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteBlocker
{
    class Program
    {
        static void Main(string[] args)
        {
      
            DateTime result = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);


            if ((result + new TimeSpan(9, 0, 0)).Hour < DateTime.Now.Hour && DateTime.Now.Hour < (result + new TimeSpan(11, 0, 0)).Hour)
            {
                FileReader.BlockSites();
            }
            else
            {
                FileReader.UnblockSites();
            }




        }
    }
}
