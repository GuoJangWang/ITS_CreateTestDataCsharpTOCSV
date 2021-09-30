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

        const string Queryfilepath = @"C:\Users\John\Desktop\FamilyMartTestData_Query.csv";
        const string Payfilepath = @"C:\Users\John\Desktop\FamilyMartTestData_Pay.csv";

        const string Querycoupfilepath = @"C:\Users\John\Desktop\FamilyMartTestData_Querycoup.csv";
        const string Paycoupfilepath = @"C:\Users\John\Desktop\FamilyMartTestData_Paycoup.csv";

        const string PayfilepathSerial = @"C:\Users\John\Desktop\Serial.csv";

        static Random tran_no_5 = new Random();
        static Random barcode2_8 = new Random();
        static Random barcode3 = new Random();

        static List<FamilyMartQuery> CoupQueryData;
        static List<FamilyMartPay> CoupPayData;

        static void Main(string[] args)
        {

            #region 原始程式

            //#region Query

            //List<FamilyMartQuery> familyMartsRequest = new List<FamilyMartQuery>();

            //for (int i = 0; i < RequestDataNum - 1; i++)
            //{
            //    var b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
            //    var b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
            //    var tranno = tran_no_5.Next(trannohead, trannolast).ToString();

            //    while (familyMartsRequest.Where(x => x.BARCODE2 == b2value).Count() != 0)
            //    {
            //        b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
            //    }

            //    while (familyMartsRequest.Where(x => x.BARCODE3 == b3value).Count() != 0)
            //    {
            //        b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
            //    }

            //    while (familyMartsRequest.Where(x => x.TRAN_NO == tranno).Count() != 0)
            //    {
            //        tranno = tran_no_5.Next(trannohead, trannolast).ToString();
            //    }

            //    familyMartsRequest.Add(new FamilyMartQuery(tranno, b2value, b3value));
            //}

            ////foreach (var item in familyMarts)
            ////{
            ////    //Console.WriteLine($"第二個 = {item.BARCODE2} , 第三個 = {item.BARCODE3}");
            ////}

            //BuildQuerysTestData<FamilyMartQuery>(Queryfilepath, familyMartsRequest);

            //#endregion

            //#region Pay

            //List<FamilyMartPay> familyMartsPay = new List<FamilyMartPay>();

            //for (int i = 0; i < RequestDataNum - 1; i++)
            //{
            //    var b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
            //    var b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
            //    var tranno = tran_no_5.Next(trannohead, trannolast).ToString();

            //    while (familyMartsPay.Where(x => x.BARCODE2 == b2value).Count() != 0)
            //    {
            //        b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
            //    }

            //    while (familyMartsPay.Where(x => x.BARCODE3 == b3value).Count() != 0)
            //    {
            //        b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
            //    }

            //    while (familyMartsPay.Where(x => x.TRAN_NO == tranno).Count() != 0)
            //    {
            //        tranno = tran_no_5.Next(trannohead, trannolast).ToString();
            //    }

            //    familyMartsPay.Add(new FamilyMartPay(tranno, b2value, b3value));
            //}

            ////foreach (var item in familyMarts)
            ////{
            ////    //Console.WriteLine($"第二個 = {item.BARCODE2} , 第三個 = {item.BARCODE3}");
            ////}

            //BuildPaysTestData<FamilyMartPay>(Payfilepath, familyMartsPay);

            //#endregion

            #endregion
            

            CreatePayDataSerial();
            BuildTestData<FamilyMartPay>(PayfilepathSerial,CreatePayDataSerial());
            //BuildPaysTestData<FamilyMartPay>(Payfilepath, CreatePayData());
            //BuildQuerysTestData<FamilyMartQuery>(Queryfilepath, CreateQueryData());
            Console.WriteLine("處理完成");
            
        }

        static List<FamilyMartPay> CreatePayData()
        {

            List<FamilyMartPay> familyMartsPay = new List<FamilyMartPay>();

            for (int i = 0; i < RequestDataNum - 1; i++)
            {
                var b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
                var b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
                var tranno = tran_no_5.Next(trannohead, trannolast).ToString();

                while (familyMartsPay.Where(x => x.BARCODE2 == b2value).Count() != 0)
                {
                    b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
                }

                while (familyMartsPay.Where(x => x.BARCODE3 == b3value).Count() != 0)
                {
                    b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
                }

                while (familyMartsPay.Where(x => x.TRAN_NO == tranno).Count() != 0)
                {
                    tranno = tran_no_5.Next(trannohead, trannolast).ToString();
                }

                familyMartsPay.Add(new FamilyMartPay(tranno, b2value, b3value));
            }

            return familyMartsPay;

        }

        static List<FamilyMartQuery> CreateQueryData()
        {

            List<FamilyMartQuery> familyMartsQuery = new List<FamilyMartQuery>();

            for (int i = 0; i < RequestDataNum - 1; i++)
            {
                var b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
                var b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
                var tranno = tran_no_5.Next(trannohead, trannolast).ToString();

                while (familyMartsQuery.Where(x => x.BARCODE2 == b2value).Count() != 0)
                {
                    b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
                }

                while (familyMartsQuery.Where(x => x.BARCODE3 == b3value).Count() != 0)
                {
                    b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
                }

                while (familyMartsQuery.Where(x => x.TRAN_NO == tranno).Count() != 0)
                {
                    tranno = tran_no_5.Next(trannohead, trannolast).ToString();
                }

                familyMartsQuery.Add(new FamilyMartQuery(tranno, b2value, b3value));
            }
            return familyMartsQuery;
        }

        static void BuildQuerysTestData<T>(string FilePath, List<T> data)
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

        static void BuildTestData<T>(string FilePath, List<T> data)
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

        //static List<FamilyMartQuery> CreateQueryDataSerial()
        //{

        //} 

        static List<FamilyMartPay> CreatePayDataSerial()
        {
            List<FamilyMartPay> familyMartsPay = new List<FamilyMartPay>();

            for (int i = 10000; i < RequestDataNum +10000- 1; i++)
            {
                //var b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
                //var b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
                var tranno = i.ToString();

                //while (familyMartsPay.Where(x => x.BARCODE2 == b2value).Count() != 0)
                //{
                //    b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
                //}

                //while (familyMartsPay.Where(x => x.BARCODE3 == b3value).Count() != 0)
                //{
                //    b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
                //}

                //while (familyMartsPay.Where(x => x.TRAN_NO == tranno).Count() != 0)
                //{
                //    tranno = tran_no_5.Next(trannohead, trannolast).ToString();
                //}

                familyMartsPay.Add(new FamilyMartPay(tranno));
            }

            return familyMartsPay;
        }

        #region 待處理
        //static void CreatCoupData()
        //{
        //    CoupQueryData = new List<FamilyMartQuery>();
        //    CoupPayData = new List<FamilyMartPay>();

        //    for (int i = 0; i < RequestDataNum - 1; i++)
        //    {
        //        var b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
        //        var b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
        //        var tranno = tran_no_5.Next(trannohead, trannolast).ToString();

        //        while (familyMartsQuery.Where(x => x.BARCODE2 == b2value).Count() != 0)
        //        {
        //            b2value = barcode2_8.Next(bar2randomhead, bar2randomlast).ToString();
        //        }

        //        while (familyMartsQuery.Where(x => x.BARCODE3 == b3value).Count() != 0)
        //        {
        //            b3value = barcode3.Next(bar3randomhead, bar3randomlast).ToString();
        //        }

        //        while (familyMartsQuery.Where(x => x.TRAN_NO == tranno).Count() != 0)
        //        {
        //            tranno = tran_no_5.Next(trannohead, trannolast).ToString();
        //        }

        //        CoupQueryData.Add(new FamilyMartQuery(tranno, b2value, b3value));
        //        CoupPayData.Add(new FamilyMartPay(tranno,b2value,b3value));
        //    }

        //}
        #endregion
        

    }
}
