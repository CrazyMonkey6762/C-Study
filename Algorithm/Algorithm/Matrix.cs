using System;

namespace Algorithm
{
    /// <summary>
    ///   矩阵类
    /// </summary>
    public class Matrix
    {
        private int row;
        private int col;
        //private int[,] matrix;

        public int Row
        {
            get
            {
                return this.row;
            }
        }
        public int Col
        {
            get
            {
                return this.col;
            }
        }

        public Matrix(int row, int col)
        {
            this.row = row;
            this.col = col;
            //this.matrix = null;
        }
    }

    /// <summary>
    ///   动态规划解矩阵连乘最优解
    /// </summary>
    public class DPMatrixMultiply
    {
        private Matrix[] para;
        private int[,] record;
        private int MatrixLength;
        private int[,] broke;

        /// <summary>
        ///   构造函数
        /// </summary>
        private DPMatrixMultiply() { }
        public DPMatrixMultiply(int[] para)
        {
            if(para.Length % 2 != 0)
            {
                throw new Exception("参数个数有误");
            }
            else
            {
                // 验证数组
                for(int i=1; i<para.Length-2; i+=2)
                {
                    if(para[i] != para[i+1])
                    {
                        throw new Exception("输入矩阵无法进行连乘");
                    }
                }
                // 存储数据
                MatrixLength = para.Length / 2;
                this.para = new Matrix[MatrixLength];
                for (int i = 0,k = 0; k < MatrixLength; i+=2,k++)
                {
                    this.para[k] = new Matrix(para[i], para[i + 1]);
                }
                record = new int[MatrixLength, MatrixLength];
                broke  = new int[MatrixLength, MatrixLength];
            }
        }

        /// <summary>
        ///   计算最优解
        /// </summary>
        private int Count()
        {
            // 单个矩阵乘法次数设为0
            for(int i=0; i<MatrixLength; i++)
            {
                record[i, i] = 0;
            }
            // 使用状态函数计算最小值
            for(int linkLength=2; linkLength<=MatrixLength; linkLength++)    // linkLength 为矩阵链长度 , 2-n
            {
                for(int i=0; i<=MatrixLength-linkLength; i++)    // i 起始位置
                {
                    int j = i + linkLength - 1;                  // j 终止位置
                    record[i, j] = record[i + 1, j] + para[i].Row * para[i].Col * para[j].Col;
                    // 记录断开位置
                    broke[i, j] = i;
                    // 取最优断开位置
                    for(int k=i+1; k<j; k++)
                    {
                        int tmp = record[i, k] + record[k + 1, j] + para[i].Row * para[k].Col * para[j].Col;
                        if(tmp<record[i,j])
                        {
                            record[i, j] = tmp;
                            broke[i, j] = k;
                        }
                    }
                }
            }
            return record[0, MatrixLength - 1];
        }
        /// <summary>
        ///   返回结果
        /// </summary>
        private void trace_back(int i, int j)
        {
            if(i==j)
            {
                Console.Write(string.Format("A{0}", i));
                return;
            }
            Console.Write("(");
            trace_back(i, broke[i, j]);
            Console.Write(",");
            trace_back(broke[i, j] + 1, j);
            Console.Write(")");
        }

        public void ShowResult()
        {
            Console.WriteLine("最佳计算次数为" + this.Count());
            Console.Write("最佳连乘方式 -- ");
            trace_back(0, MatrixLength - 1);
            
            Console.WriteLine("\n结果矩阵");
            for (int i = 0; i < MatrixLength; i++)
            {
                for (int j = 0; j < MatrixLength; j++)
                {
                    Console.Write(record[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n分割矩阵");
            for (int j = 0; j < MatrixLength; j++)
            {
                for (int i = 0; i < MatrixLength; i++)
                {
                    Console.Write(broke[j, i] + 1 + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
