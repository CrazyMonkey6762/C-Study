using System;
using Algorithm;

namespace AlgorithmUI
{
    class LargeNumberCalcActivity
    {
        private string[] save = new string[3];

        public LargeNumberCalcActivity()
        {
            Menu.cls();
            showDetail();
            getPara();
            run();
            Menu.BackMenu();
        }

        /// <summary>
        ///   显示详情
        /// </summary>
        private void showDetail()
        {
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃     实验 1   -- 大整数相乘           ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃       说明--计算任意位整数           ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃参数输入 -- 输入表达式 如：123 * 456  ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━┛");
            Console.WriteLine("");
        }

        /// <summary>
        ///   获取参数
        /// </summary>
        private void getPara()
        {
            string para;
            string[] temp;

            Console.Write("请输入表达式:");
            try
            {
                para = Console.ReadLine().Trim();
                if (para.Contains("+"))
                {
                    save[0] = "+";
                    temp = para.Split('+');
                    save[1] = temp[0];
                    save[2] = temp[1];
                }
                if (para.Contains("-"))
                {
                    save[0] = "-";
                    temp = para.Split('-');
                    save[1] = temp[0];
                    save[2] = temp[1];
                }
                if (para.Contains("*"))
                {
                    save[0] = "*";
                    temp = para.Split('*');
                    save[1] = temp[0];
                    save[2] = temp[1];
                }
            }
            catch(Exception ex)
            {
                throw new FormatException("LargeNumberCalcActivity -- getPara: " + ex.Message);
            }
        }

        /// <summary>
        ///   运行分治算法
        /// </summary>
        private void run()
        {
            Console.WriteLine();
            LargeNumber.ShowResult(save);
        }
    }
}
