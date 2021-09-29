using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Csharp_TO_CSV
{
    class Program
    {

        const int RequestDataNum = 5000;

        const int bar2randomhead = 10000000;
        const int bar2randomlast = 99999999;

        const int bar3randomhead = 1;
        const int bar3randomlast = 20000;

        const int trannohead = 10000;
        const int trannolast = 99999;

        const string filepath = @"C:\Users\John\Desktop\FamilyMartData.csv";

        static void Main(string[] args)
        {

            Random tran_no_5 = new Random();
            Random barcode2_8 = new Random();
            Random barcode3 = new Random();

            List<FamilyMart> familyMarts = new List<FamilyMart>();

            for (int i = 0; i < RequestDataNum-1; i++)
            {
                var b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
                var b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
                var tranno = tran_no_5.Next(trannohead,trannolast).ToString();

                while (familyMarts.Where(x => x.BARCODE2 == b2value).Count() != 0)
                {
                    b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
                }

                while (familyMarts.Where(x => x.BARCODE3 == b3value).Count() != 0)
                {
                    b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
                }

                while (familyMarts.Where(x => x.TRAN_NO == tranno).Count() != 0)
                {
                    tranno = tran_no_5.Next(trannohead,trannolast).ToString();
                }

                familyMarts.Add(new FamilyMart(tranno, b2value, b3value));
            }

            //foreach (var item in familyMarts)
            //{
            //    //Console.WriteLine($"第二個 = {item.BARCODE2} , 第三個 = {item.BARCODE3}");
            //}

            CSVGenerator<FamilyMart>(filepath, familyMarts);

        }

        static void CSVGenerator<T>(string FilePath, List<T> data)
        {
            using (var file = new StreamWriter(FilePath))
            {
                Type t = typeof(T);
                PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                if (true)
                {
                    file.WriteLine(string.Join(",", propInfos.Select(i => i.Name)));
                }


                foreach (var item in data)
                {
                    var sub = string.Join(",", propInfos.Select(i => i.GetValue(item)));
                    sub = sub.TrimEnd(',');
                    file.WriteLine(sub);
                }
            }
        }

    }
}
