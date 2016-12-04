using System;

namespace Algorithm
{
    public class NQueen
    {
        private int QueenSize;
        int[] QueenInfo;

        /// <summary>
        ///     构造函数
        /// </summary>
        private NQueen() { }
        public NQueen(int size)
        {
            if (size > 0)
            {
                this.QueenSize = size;
                this.QueenInfo = new int[size + 1];
            }
            else
            {
                throw new ArgumentException("参数不能为负值！");
            }
        }

        /// <summary>
        ///   验证放置位置是否符合规则
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private bool Place(int pos)
        {
            for (int i = 1; i < pos; i++)
            {
                if(Math.Abs(pos-i)==Math.Abs(QueenInfo[i]-QueenInfo[pos]) || (QueenInfo[i] == QueenInfo[pos]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///   利用迭代回溯解决n皇后问题
        /// </summary>
        public void ShowResult()
        {
            QueenInfo[1] = 0;
            int pos = 1;

            while (pos > 0)
            {
                QueenInfo[pos] += 1;
                while (QueenInfo[pos] <= QueenSize && (!this.Place(pos)))
                {
                    QueenInfo[pos] += 1;
                }
                if (QueenInfo[pos] <= QueenSize)
                {
                    if (pos == QueenSize)
                    {
                        QueenInfo[0]++;
                        this.Print();
                    }
                    else
                    {
                        QueenInfo[++pos] = 0;
                    }
                }
                else 
                {
                    pos--;
                }
            }
        }

        /// <summary>
        ///   输出中间结果
        /// </summary>
        private void Print()
        {
            Console.WriteLine("方案" + QueenInfo[0]);
            for(int i = 1; i <= QueenSize; i++)
            {
                for (int j = 1; j <= QueenSize; j++)
                {
                    if (j == QueenInfo[i])
                    {
                        Console.Write("■");
                    }
                    else
                    {
                        Console.Write("□");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
