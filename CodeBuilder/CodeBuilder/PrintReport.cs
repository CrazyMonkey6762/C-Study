using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Rendering;
namespace CodeBuilder
{
    public partial class PrintReport : DevExpress.XtraReports.UI.XtraReport
    {
       
        BarcodeWriter writer = null;
        EncodingOptions options = null;

        /// <summary>
        /// 画指定数字的条形码
        /// </summary>
        /// <param name="num"></param>
        /// <param name="text"></param>
        public PrintReport(CodeType type ,string text)
        {
            InitializeComponent();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
            };
            writer = new BarcodeWriter();
            writer.Options = options;
            XRPictureBox PBoxTemp = new XRPictureBox();
          
            if (type==CodeType.BarCode)
            {
                writer.Format = BarcodeFormat.CODE_39;//一维码或者二维码在这修改
                writer.Options.Width = 240;
                writer.Options.Height = 88;
                PBoxTemp.Size = new Size(240, 120);
            }
            else if (type == CodeType.QRCode) {
                writer.Format = BarcodeFormat.QR_CODE;
                writer.Options.Width = 480;
                writer.Options.Height = 480;
                PBoxTemp.Size = new Size(480, 480);
            }
            Bitmap bt = writer.Write(text);
            PBoxTemp.Image = bt;
            PBoxTemp.Location = new Point(80, 80);
            this.xrPanel1.Controls.Add(PBoxTemp);
        }

        /// <summary>
        /// 生成指定长度，指定个数的条形码
        /// </summary>
        /// <param name="num"></param>
        /// <param name="length"></param>
        public PrintReport(int num, int length)
        {
            InitializeComponent();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 240,
                Height = 80
            };
            writer = new BarcodeWriter();
            writer.Options = options;
            CreatBarCode(num, length);           
        }

        /// <summary>
        /// 生成指定长度指定个数的随机数字条形码
        /// </summary>
        /// <param name="num"></param>
        /// <param name="length"></param>
        private void CreatBarCode(int num, int length)
        {
            writer.Format = BarcodeFormat.CODE_39;//一维码或者二维码在这修改
            Random ra = new Random();
            Bitmap bt = writer.Write("123");
            Point p_gpx = new Point(33, 40);
            for (int i = 0; i < num; i++)
            {
                XRPictureBox PBoxTemp = new XRPictureBox();
                bt = writer.Write(RandCode(length));
                PBoxTemp.Size = new Size(240, 88);
                PBoxTemp.Image = bt;
                if (i == 0 || i % 2 != 0)
                {
                    PBoxTemp.Location = new Point(p_gpx.X, p_gpx.Y);
                    p_gpx.X = p_gpx.X + PBoxTemp.Width + 100;
                }
                else
                {
                    p_gpx.Y = p_gpx.Y + PBoxTemp.Height + 100;
                    p_gpx.X = 33;
                    PBoxTemp.Location = new Point(p_gpx.X, p_gpx.Y);
                    p_gpx.X = p_gpx.X + PBoxTemp.Width + 100;
                }

                this.xrPanel1.Controls.Add(PBoxTemp);
            }
           
        }

        /// <summary>
        /// 生成指定长度的随机数字字符串
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static string RandCode(int N)
        {
            char[] arrChar = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            StringBuilder num = new StringBuilder();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < N; i++)
            {
                num.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString());
            }
            return num.ToString();
        }


    }
}
