/*
 * 实验题目：贪心算法 -- 背包问题
 * 时间：2016-11-13
 * 创建人：Stone6762
 * 功能实现：输入物品列表及背包容量即可计算出最佳方案
 */
using System;
using System.Collections;

namespace Algorithm
{
    /// <summary>
    ///   商品价值信息
    /// </summary>
    public struct Goods
    {
        public double weight;
        public double value;

        public Goods(double weight, double value)
        {
            this.weight = weight;
            this.value = value;
        }
    }

    public class Pack : IComparer
    {
        private double volume;//容量
        private int count;//数量
        private Goods[] list;//商品

        public Pack(double volume,Goods[] list)
        {
            if(volume <= 0)
            {
                throw new ArgumentException("背包容量必须为正数");
            }
            if(list==null || list.Length==0)
            {
                throw new ArgumentNullException("商品列表为空或未初始化");
            }
            this.volume = volume;
            this.count = list.Length;
            this.list = list;
        }

        /// <summary>
        ///   计算分配策略
        /// </summary>
        public double[] Allocate()
        {
            double[] result = new double[count];
            double size = volume;
            int i = 0;

            for (; i < count; i++) result[i] = 0;

            // 按价值量排序
            Array.Sort(list, this);
            for (i = 0; i < count; i++)
            {
                if(list[i].weight > size)
                {
                    break;
                }
                result[i] = 1;
                size -= list[i].weight;
            }
            if(i < count)
            {
                result[i] = size / list[i].weight;//价值
            }
            return result;
        }

        /// <summary>
        ///   显示结果
        /// </summary>
        public void ShowResult()
        {
            double[] result = this.Allocate();
            int pos = 1;
            double sum = 0;
            Console.WriteLine("商品编号\t商品重量\t商品价值");

            foreach (double r in result)
            {
                if (r != 0)
                {
                    double value = (r * list[pos - 1].value);
                    Console.WriteLine(String.Format("{0}\t\t{1:f2}\t\t{2:f2}", pos, r, value));
                    sum += value;
                }
                pos++;
            }
            Console.WriteLine(String.Format("商品总价值{0:f2}", sum));
        }

        /// <summary>
        ///     实现比较接口
        /// </summary>
        public int Compare(object x, object y)
        {
            if(x==null || y==null)
            {
                throw new ArgumentNullException("Pack->Compare:参数不能为空");
            }
            Goods a = (Goods)x; Goods b = (Goods)y;
            return (int)((b.value / b.weight) - (a.value / a.weight));
        }
    }
}
