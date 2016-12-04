///*************************************
// * 作者 : Stone6762
// * 创建时间 : 2016年12月4日19:07:20
// * 描述 :
// *   实现在二维空间上求解最近点对的分治
// *   算法，该算法时间复杂度为nlog(n)
// * 
// *************************************/
using System;
using System.Collections.Generic;
using System.Collections;

namespace Algorithm
{
    /// 作者 : Stone6762
    /// 创建时间 : 2016-10-18
    /// 描述 : 
    ///   二维空间点
    public class Point2D : IComparable
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        /// 
        /// 说明：构造函数
        /// 
        private Point2D() { }
        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// 
        /// 说明：比较两点是否相等
        /// 
        public bool Equals(Point2D p)
        {
            return (this.X == p.X && this.Y == p.Y) ? true : false;
        }

        /// 
        /// 说明：两点之间距离
        ///
        public double Distance(Point2D p)
        {
            double dx = this.X - p.X;
            double dy = this.Y - p.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// 
        /// 说明：覆写 ToString 方法
        ///
        public override string ToString()
        {
            return "<" + this.X + "," + this.Y + ">";
        }

        /// <summary>
        /// 按X轴坐标排序
        /// </summary>
        public int CompareTo(object x)
        {
            return (int)(this.X - (x as Point2D).X);
        }
    }

    /// <summary>
    ///   平面点对
    /// </summary>
    class PointPair : IComparable
    {
        public Point2D L { get; private set; }
        public Point2D R { get; private set; }
        public double dist { get; private set; }

        private PointPair() { }
        public PointPair(Point2D l, Point2D r, double d) 
        {
            this.L = l;
            this.R = r;
            dist = d;
        }

        public override string ToString()
        {
            return "{" + L.ToString() + "," + R.ToString() + "}";
        }

        public int CompareTo(object x)
        {
            return (int)(this.dist - (x as PointPair).dist);
        }
    }

    /// <summary>
    ///   计算平面最近点对
    /// </summary>
    public class Cpair2D 
    {
        private List<Point2D> Set;
        private List<PointPair> Result;
        private double delta;

        public Cpair2D(List<Point2D> set)
        {
            this.Set = set;
            Set.Sort();
            delta = int.MaxValue;
            Result = new List<PointPair>();
        }

        /// <summary>
        /// 寻找最近点对
        /// </summary>
        private double FindCloset(List<Point2D> set)
        {
            // 两点计算
            if (set.Count == 2)
            {
                double dist = set[0].Distance(set[1]);
                // 拟最近点
                if (dist <= delta)
                {
                    Result.Add(new PointPair(set[0], set[1], dist));
                    delta = dist;
                }
                return dist;
            }
            // 三点计算
            else if (set.Count == 3)
            {
                double tmp_dis1 = set[0].Distance(set[1]);
                double tmp_dis2 = set[0].Distance(set[2]);
                double tmp_dis3 = set[1].Distance(set[2]);
                double dist = Min(Min(tmp_dis1, tmp_dis2), tmp_dis3);

                if (dist <= delta)
                {
                    if (tmp_dis1 == dist)
                    {
                        Result.Add(new PointPair(set[0], set[1], dist));
                    }
                    else if (tmp_dis2 == dist)
                    {
                        Result.Add(new PointPair(set[0], set[2], dist));
                    }
                    else
                    {
                        Result.Add(new PointPair(set[1], set[2], dist));
                    }

                    delta = dist;
                }
                return dist;
            }
            // 多于三点
            else
            {
                // 分割平面
                List<Point2D> Left = new List<Point2D>();
                List<Point2D> Right = new List<Point2D>();
                this.Splite(set, Left, Right);
                // 计算距离
                double leftDist = FindCloset(Left);
                double rightDist = FindCloset(Right);
                delta = (leftDist < rightDist) ? leftDist : rightDist;
                // 计算平面间距离
                CalcSplite(Left, Right);
            }
            return delta;
        }

        /// <summary>
        ///   显示结果
        /// </summary>
        public void ShowResult()
        {
            FindCloset(Set);
            Console.WriteLine(string.Format("最近点对距离：{0:f}", delta));
            Result.Sort();
            for (int i = 0; i < Result.Count; i++)
            {
                if (Result[i].dist == delta)
                {
                    Console.WriteLine(string.Format("最近点对距离：{0}", Result[i].ToString()));
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 求解最小值
        /// <summary>
        private double Min(double x, double y)
        {
            return (x >= y) ? y : x;
        }

        /// <summary>
        /// 按中位数分割平面
        /// </summary>
        private void Splite(List<Point2D> S, List<Point2D> L, List<Point2D> R)
        {
            int count = S.Count;
            int i = 0;
            // 左平面
            for (; i < count / 2; i++)
            {
                L.Add(S[i]);
            }
            // 右平面
            for (; i < count; i++)
            {
                R.Add(S[i]);
            }
        }

        /// <summary>
        /// 计算分割线附近的点
        /// </summary>
        private void CalcSplite(List<Point2D> L, List<Point2D> R)
        {
            for (int i = 0; i < L.Count; i++)
            {
                for (int j = 0; j < R.Count; j++)
                {
                    if (Math.Abs(L[i].X - R[j].X) <= delta && Math.Abs(L[i].Y - R[j].Y) <= delta)
                    {
                        double d = L[i].Distance(R[j]);
                        if (d <= delta)
                        {
                            Result.Add(new PointPair(L[i], R[j], d));
                            delta = d;
                        }
                    }
                }
            }
        }
    }
}

