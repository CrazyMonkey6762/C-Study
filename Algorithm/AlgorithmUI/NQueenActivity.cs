using System;
using Algorithm;

namespace AlgorithmUI
{
    class NQueenActivity
    {
        private byte size;

        public NQueenActivity()
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
            Console.WriteLine("┃                  实验5 -- N后问题                  ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃ 说明--寻找N*NQ棋盘上互不攻击的N个皇后的位置        ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃          参数输入 -- 输入棋盘规模 如：10           ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.WriteLine("");
        }

        /// <summary>
        ///   获取运行参数
        /// </summary>
        private void getPara()
        {
            Console.Write("请输入皇后的个数:");
            try
            {
                size = Convert.ToByte(Console.ReadLine().Trim());
            }
            catch(Exception ex)
            {
                throw new Exception("NQueenActivity -- getPara(): " + ex.Message);
            }
        }

        /// <summary>
        ///   运行N皇后算法
        /// </summary>
        private void run()
        {
            NQueen queen = new NQueen(size);
            queen.ShowResult();
        }
    }
}
