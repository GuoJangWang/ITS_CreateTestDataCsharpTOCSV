using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_TO_CSV
{
    class FamilyMartPay
    {
        const string Src = "FamilyMart";
        const string Ten_code = "001234";
        const string Tran_no = "70325A";
        const string Mmk_id = "AC1";
        const string Pay_date = "20210929";
        const string Pay_time = "150000";
        const string Barcode1 = "101231AC1";
        const string Barcode2_head = "08029000";
        const string Barcode3_head = "00316823000";


        public FamilyMartPay(string tran_no, string barcode2, string paynumber)
        {
            this.SRC = Src;
            this.TEN_CODE = Ten_code;
            this.TRAN_NO = Tran_no + tran_no;//隨機補5碼
            this.MMK_ID = Mmk_id;
            this.PAY_DATE = Pay_date;
            this.PAY_TIME = Pay_time;
            this.PAY_AMT = paynumber;
            this.BARCODE1 = Barcode1;
            this.BARCODE2 = Barcode2_head + barcode2;//補隨機 8 碼
            this.BARCODE3 = Barcode3_head + paynumber;//補隨機 1-20000
        }


        public string SRC { get; set; }

        public string TEN_CODE { get; set; }

        public string TRAN_NO { get; set; }

        public string MMK_ID { get; set; }

        public string PAY_DATE { get; set; }

        public string PAY_TIME { get; set; }

        public string PAY_AMT { get; set; }

        public string BARCODE1 { get; set; }

        public string BARCODE2 { get; set; }

        public string BARCODE3 { get; set; }

        

    }
}
