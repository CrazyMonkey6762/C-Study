using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithm
{
    /// <summary>
    ///   道路节点
    /// </summary>
    class Node:IComparer
    {
        public int cc;
        public int rcost;
        public int s;
        public int[] x;
        public int lcost;

        public int Compare(object x, object y)
        {
            return (y as Node).lcost - (x as Node).lcost;
        }
    }

    /// <summary>
    ///   分支限界法解决旅行商问题
    /// </summary>
    public class Traveller
    {
        private int NOEDGE = int.MaxValue;
        private PriorityQueue queue;       //最小堆
        private int[] MinOut;
        private int[] Result;
        private int MinSum;
        private Graphic Map;
        private int bestc;

        /// <summary>
        /// 构造函数
        /// </summary>
        private Traveller() { }
        public Traveller(Graphic map)
        {
            try
            {
                int Min = NOEDGE;

                this.Map = map;
                MinOut = new int[Map.Scale];
                MinSum = 0;
                bestc = NOEDGE;
                queue = new PriorityQueue(2*Map.Scale);
                Result = new int[Map.Scale];

                //
                for (int i = 0; i < Map.Scale; i++)
                {
                    Min = NOEDGE;
                    for (int j = 0; j < Map.Scale; j++)
                    {
                        int temp = Map.GetDistance(i,j);
                        if (temp != NOEDGE && (temp < Min || Min == NOEDGE)) 
                        {
                            Min = temp;
                        }
                    }
                    if (Min == NOEDGE)
                    {
                        throw new Exception("没有找到回路！");
                    }
                    MinOut[i] = Min;
                    MinSum += Min;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Traveller--Constructor:" + ex.Message);
            }
        }

        private void Resovle()
        {
            int count = Map.Scale;

            // 初始化结点
            Node E = new Node();
            E.x = new int[Map.Scale];
            for (int i = 0; i < count; i++)
            {
                E.x[i] = i;
            }
            E.s = 0;
            E.cc = 0;
            E.rcost = MinSum;
            // 搜索排列空间树
            while (E.s < count - 1)     //  非叶结点
            {
                //  当前扩展结点是叶结点的父结点
                if (E.s == count - 2)
                {
                    int tnode = Map.GetDistance(E.x[count - 2], E.x[count - 1]);
                    int enode = Map.GetDistance(E.x[count - 1], 0);
                    int cbest = 0;

                    if (tnode != NOEDGE && enode != NOEDGE && (cbest = E.cc + tnode + enode) < bestc || bestc == NOEDGE)
                    {
                        bestc = cbest;
                        E.cc = bestc;
                        E.s++;
                        E.lcost = bestc;
                        queue.Push(E);
                    }
                    else
                    {
                        E.x = null;
                    }
                }
                else
                {
                    // 产生当前扩展结点的儿子结点
                    for (int i = E.s + 1; i < count; i++)
                    {
                        if (Map.GetDistance(E.x[E.s], E.x[i]) != NOEDGE)
                        {
                            // 可行儿子结点
                            int cc = E.cc + Map.GetDistance(E.x[E.s], E.x[i]);
                            int rcost = E.rcost - MinOut[E.x[E.s]];
                            int b = cc + rcost;
                            if (b < bestc || bestc == NOEDGE)
                            {
                                // 可能包含最优解
                                Node N = new Node();
                                N.x = new int[count];
                                for (int j = 0; j < count; j++)
                                {
                                    N.x[j] = E.x[j];
                                }
                                N.x[E.s + 1] = E.x[i];
                                N.x[i] = E.x[E.s + 1];
                                N.cc = cc;
                                N.s = E.s + 1;
                                N.rcost = rcost;
                                N.lcost = b;
                                queue.Push(N);
                            }
                            else
                            {
                                E.x = null;
                            }
                        }
                    }
                    // 取下一扩展结点
                    if (queue.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        E = queue.Pop();
                    }
                }
            }
            if (bestc == NOEDGE)
            {
                throw new Exception("无回路");
            }
            for (int i = 0; i < count; i++)
            {
                Result[i] = E.x[i] + 1;
            }
            while (true)
            {
                E.x = null;
                if (queue.Count == 0)
                {
                    break;
                }
                else
                {
                    queue.Pop();
                }
            }
        }

        public void ShowResult()
        {
            this.Resovle();
            Console.WriteLine("所需最小消费为" + bestc);
            Console.Write("最短回路为：");
            for (int i = 0; i < Map.Scale; i++)
            {
                Console.Write(Result[i] + "->");
            }
            Console.Write(Result[0]);
        }
    }
}
