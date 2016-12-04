using System;
using System.Collections.Generic;
using Algorithm;

namespace AlgorithmUI
{
    class TravellerActivity
    {
        private int[,] para;
        private Graphic map;

        public TravellerActivity()
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
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃                  实验7 -- 旅行售货员问题                             ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃          说明--计算售货员经过的最短回路                              ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃输入邻接矩阵(M表示不能通行) 如：M,30,6,4|30,M,5,10|6,5,M,20|4,10,20,M ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.WriteLine("");

            Console.WriteLine("** 实验7 -- 旅行售货员问题");
            Console.WriteLine("** 说明 -- ");
            Console.WriteLine("** 参数输入-- 输入邻接矩阵(M表示不能通行) 如：M,30,6,4|30,M,5,10|6,5,M,20|4,10,20,M");
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

            Console.Write("请输入邻接矩阵:");
            try
            {
                item = Console.ReadLine().Trim().Split('|');
                int size = (byte)item.Length;
                para = new int[size,size];

                foreach (string p in item)
                {
                    detail = p.Trim().Split(',');
                    for (int i = 0; i < size; i++)
                    {
                        if (detail[i] == "M")
                        {
                            para[pos, i] = int.MaxValue;
                        }
                        else 
                        {
                            para[pos, i] = Convert.ToInt16(detail[i]);
                        }
                    }
                    pos++;
                }
                // 生成Map
                map = new Graphic(para);
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
            Traveller way = new Traveller(map);
            way.ShowResult();
        }
    }
}
