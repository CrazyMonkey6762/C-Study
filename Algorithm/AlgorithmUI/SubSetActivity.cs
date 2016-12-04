using System;
using System.Collections;
using Algorithm;

namespace AlgorithmUI
{
    class SubSetActivity
    {
        private int[] para;
        private int sum;

        public SubSetActivity()
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
            Console.WriteLine("┃                  实验6 -- 子集和问题                       ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃说明--寻找集合的一个子集，使得子集中元素和为C               ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃参数输入 -- 先输入集合元素后输入目标和的大小 如2,4,3,6,5|7  ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.WriteLine("");
        }

        /// <summary>
        ///   获取参数
        /// </summary>
        private void getPara()
        {
            string[] item;
            string[] temp;
            int pos = 0;

            Console.Write("请输集合列表:");
            try
            {
                item = Console.ReadLine().Trim().Split('|');
                temp = item[0].Trim().Split(',');
                sum  = Convert.ToInt16(item[1].Trim());
                para = new int[temp.Length];

                foreach (string p in temp)
                {
                    para[pos++] = Convert.ToInt16(p.Trim());
                }

                // 重排序
                Array.Sort(para);
            }
            catch(Exception ex)
            {
                throw new FormatException("SubSetActivity -- getPara: "+ex.Message);
            }
        }

        /// <summary>
        ///   运行子集和算法
        /// </summary>
        private void run()
        {
            SubSet Set = new SubSet(para, sum);
            Set.ShowResult();
            if (Set.Visit[0] == 0)
            {
                Console.WriteLine("子集和的解不存在!");
            }
        }
    }
}
