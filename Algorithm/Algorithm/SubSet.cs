using System;

namespace Algorithm
{
    public class SubSet
    {
        private int SetSize;
        private int[] Set;
        private int[] visit;
        private int wanted;

        public int[] Visit
        {
            get 
            {
                return this.visit;
            }
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        public SubSet(int[] para, int sum)
        {
            Set = para;
            SetSize = Set.Length;
            wanted = sum;
            visit = new int[SetSize + 1];
        }
        private SubSet() { }

        /// <summary>
        ///     判断选取的位置是否已选
        /// </summary>
        private bool choose(int pos)
        {
            int index = 1;

            try
            {
                while (index < pos && visit[index] != 0)
                {
                    if (visit[pos] <= visit[index])
                    {
                        return false;
                    }
                    index++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SubSet--choose:" + ex.Message);
            }

            return true;
        }

        /// <summary>
        ///   计算子集和
        /// </summary>
        /// <returns></returns>
        private int Sum()
        {
            int sum = 0;
            int pos = 1;

            try
            {
                while (pos <= SetSize && Convert.ToBoolean(visit[pos]))
                {
                    sum += Set[visit[pos++] - 1];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SubSet--Sum:" + ex.Message);
            }

            return sum;
        }

        /// <summary>
        ///     回溯求解
        /// </summary>
        public void ShowResult()
        {
            visit[1] = 0;
            int pos = 1;
            int sum = 0;
            try
            {
                while (pos > 0)
                {
                    visit[pos] += 1;
                    while (visit[pos] <= SetSize && (sum = Sum()) <= wanted && !choose(pos))
                    {
                        visit[pos]++;
                    }

                    if (visit[pos] <= SetSize && sum <= wanted)
                    {
                        if (sum == wanted)
                        {
                            visit[0]++;
                            Print();
                        }
                        else
                        {
                            if (pos < SetSize)
                            {
                                visit[++pos] = 0;
                            }
                            else 
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        visit[pos--] = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SubSet--ShowResult:" + ex.Message);
            }

        }

        /// <summary>
        ///   输出中间结果
        /// </summary>
        private void Print()
        {   
            Console.WriteLine("方案" + visit[0]);
            Console.Write("子集序列：{ ");
            for (int i = 1; i < visit.Length; i++)
            {
                if (visit[i] != 0)
                {
                    Console.Write(Set[visit[i]-1]+" ");
                }
            }
            Console.Write("}\n");
        }
    }
}
