using System;
using Algorithm;

namespace AlgorithmUI
{
    class MatrixActivity
    {
        private int[] para;

        public MatrixActivity()
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
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃               实验3 -- 矩阵连乘                    ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃       说明--计算N个矩阵乘积的最优次序              ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃矩阵规模输入（两个之间用|分割）如：10,5|5,20|20,40  ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.WriteLine("");
        }

        /// <summary>
        ///   获取参数
        /// </summary>
        private void getPara()
        {
            string[] item;
            string[] detail;
            int pos = 0;

            Console.Write("请输矩阵品列表:");
            try
            {
                item = Console.ReadLine().Trim().Split('|');
                int size = (byte)item.Length;
                para = new int[2 * size];

                foreach (string p in item)
                {
                    detail = p.Trim().Split(',');
                    para[pos++] = Convert.ToInt16(detail[0]);
                    para[pos++] = Convert.ToInt16(detail[1]);
                }
            }
            catch
            {
                throw new FormatException("GreedySelectorActivity -- getPara: 参数格式不正确");
            }
        }

        /// <summary>
        ///   运行程序
        /// </summary>
        private void run()
        {
            Console.WriteLine();
            DPMatrixMultiply matrix = new DPMatrixMultiply(para);
            matrix.ShowResult();
        }
    }
}
