using System;
using System.Collections.Generic;
using Algorithm;

namespace AlgorithmUI
{
    class CpairActivity
    {
        byte size;
        List<Point2D> Set;

        public CpairActivity()
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
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃          实验2--平面最近点对                     ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃     说明--寻找平面中最近的点                     ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃坐标输入--（两点坐标用|分割）如：5,6|2,10|3,9|8,6 ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.WriteLine("");
        }

        /// <summary>
        ///   获取参数
        /// </summary>
        private void getPara()
        {
            string[] item;
            string[] detail;

            Console.Write("请输入点集:");
            try
            {
                item = Console.ReadLine().Trim().Split('|');
                size = (byte)item.Length;
                Set = new List<Point2D>();

                // 判断点的数量
                if (size < 2)
                {
                    throw new Exception("点的个数必须大于2个");
                }
                foreach (string p in item)
                {
                    detail = p.Trim().Split(',');
                    Set.Add(new Point2D(Convert.ToByte(detail[0]), Convert.ToByte(detail[1])));
                }
            }
            catch(Exception ex)
            {
                throw new FormatException("GreedySelectorActivity -- getPara: " + ex.Message);
            }
        }

        /// <summary>
        ///   寻找最近点对
        /// </summary>
        private void run()
        {
            Cpair2D pair = new Cpair2D(Set);
            pair.ShowResult();
        }
    }
}
