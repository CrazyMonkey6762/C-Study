using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder
{
    public partial class ChooseForm : Form
    {
        public ChooseForm()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// 指定内容的二维码生成器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQ_Click(object sender, EventArgs e)
        {
            if (tbx_3.Text.ToString().Trim() == "")
            {
                MessageBox.Show("请输入生成二维码的内容");
            }
            else
            {
                PrintReport report = new PrintReport(CodeType.QRCode, tbx_3.Text.ToString().Trim());
                report.ShowPreview();
                tbx_3.Text = "";
            }
        }
        /// <summary>
        /// 指定内容的条形码生成器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_B_Click(object sender, EventArgs e)
        {
            string str = tbx_4.Text.ToString().Trim();
            if (str == "")
            {
                MessageBox.Show("请输入生成条形码的内容");
            }
            else if (!isLetter(str))
            {
                MessageBox.Show("请输入数字");
            }
            else
            {
                PrintReport report = new PrintReport(CodeType.BarCode, str);
                report.ShowPreview();
                tbx_4.Text = "";
            }

        }

        /// <summary>
        /// 是否是数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private Boolean isLetter(string str) {
            System.Text.RegularExpressions.Regex rex =
           new System.Text.RegularExpressions.Regex(@"^\d+$");
            return rex.IsMatch(str);
        }
        /// <summary>
        /// 批量随机产生指定长度指定个数的条形码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click_1(object sender, EventArgs e)
        {
            string num = tbx_1.Text.ToString().Trim();
            string length = tbx_2.Text.ToString().Trim();
            if (num == "")
            {
                MessageBox.Show("请输入生成条形码的个数");
            }
            else if (length == "")
            {
                MessageBox.Show("请输入生成条形码的长度");
            }
            else if ((!isLetter(num)) || (!isLetter(length)))
            {
                MessageBox.Show("条形码个数和长度均为数字");

            }
            else if (length.Length > 20)
            {
                MessageBox.Show("条形码长度应小于20");
            }
            else
            {
                PrintReport report = new PrintReport(Convert.ToInt32(num), Convert.ToInt32(length));
                report.ShowPreview();
                tbx_1.Text = "";
                tbx_2.Text = "";
            }
        }

    }
}
