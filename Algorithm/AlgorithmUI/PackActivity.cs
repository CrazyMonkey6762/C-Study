using System;
using Algorithm;

namespace AlgorithmUI
{
    class PackActivity
    {
        private Goods[] list;
        private byte size;
        private double packSize;

        public PackActivity()
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


            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃                  实验4 -- 背包问题                         ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃             说明--给出合理的背包安排                       ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃输入物品重量和价值（物品间用|分割）如：10,60|20,100|30,120  ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
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

            Console.Write("请输入物品列表:");
            try
            {
                item = Console.ReadLine().Trim().Split('|');
                size = (byte)item.Length;
                list = new Goods[size];

                foreach (string p in item)
                {
                    detail = p.Trim().Split(',');
                    list[pos].weight = Convert.ToByte(detail[0]);
                    list[pos].value = Convert.ToByte(detail[1]);
                    pos++;
                }

                Console.Write("\n请输入背包容量:");
                packSize =  Convert.ToDouble(Console.ReadLine().Trim());
            }
            catch
            {
                throw new FormatException("GreedySelectorActivity -- getPara: 参数格式不正确");
            }
        }

        /// <summary>
        ///   运行贪婪算法
        /// </summary>
        private void run()
        {
            Console.WriteLine();
            Pack pack = new Pack(packSize, list);
            pack.ShowResult();
        }
    }
}
