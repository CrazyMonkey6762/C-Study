/****************************************
 * 作者 : Stone6762
 * 创建时间 : 2016年10月19日
 * 描述 :
 *   实现任意位数的数字的加法，减法，乘法
 ****************************************/
using System;
using System.Collections;

namespace Algorithm
{
    /// 作者 : Stone6762
    /// 创建时间 : 2016年10月19日
    /// 描述 : 
    ///   大数运算，只限于正数运算，
    ///   不支持浮点数运算
    public class LargeNumber
    {
        #region 取绝对值

        private static string Abs(string x)
        {
            if(x.StartsWith("-"))
            {
                return x.Substring(1);
            }
            else
            {
                return x;
            }
        }
        #endregion

        #region 位数补齐

        private static void FillZero(ref string X, ref string Y)
        {
            int xLen = X.Length;
            int yLen = Y.Length;
            int len = 0;

            // 补齐位数
            if (xLen >= yLen)
            {
                len = xLen;
                for (int i = 0; i < xLen - yLen; i++)
                {
                    Y = Y.Insert(0, "0");
                }
            }
            else
            {
                len = yLen;
                for (int i = 0; i < yLen - xLen; i++)
                {
                    X = X.Insert(0, "0");
                }
            }
        }
        #endregion

        #region 交换顺序

        private static void Swap(ref string X, ref string Y)
        {
            string tmp;

            tmp = X;
            X = Y;
            Y = tmp;
        }
        #endregion

        #region 数字转换为字符

        private static string IntToString(int x)
        {
            return Convert.ToString(x);
        }
        #endregion

        #region 字符转换为数字

        private static int StringToInt(char x)
        {
            int t = (int)x;
            if(t<=57 && t>=48)
            {
                return (int)(t - 48);
            }
            else
            {
                throw new Exception("参数不是一个数字！");
            }

        }
        #endregion

        #region 参数检测

        private static string checkParameter(string x)
        {
            string tmp = x;

            // 不能为空
            if (tmp.Length == 0)
            {
                throw new ArgumentException("参数不能为空");
            }
            else
            {
                // 是否包含括号
                if(tmp.StartsWith("-"))
                {
                    tmp = Abs(tmp);
                }
                // 逐位校验
                for (int i = 0; i < tmp.Length; i++)
                {
                    int t = tmp[i];

                    if (t > 57 || t < 48)
                    {
                        throw new Exception("输入中包含非数字字符！");
                    }
                }
            }

            return x;
        }
        #endregion

        #region 分割数组

        private static void spliteNumber(string x, ref string high, ref string low)
        {
            int len = x.Length;

            for (int i = 0; i < len / 2; i++)
            {
                high = high.Insert(high.Length, x[i] + "");
            }
            for (int i = len / 2; i < len; i++)
            {
                low = low.Insert(low.Length, x[i] + "");
            }
        }
        #endregion

        #region 处理乘法产生的前缀的0

        private static string trim(string x)
        {
            int i = 0;
            if(x.StartsWith("-"))
            {
                i = 1;
            }
            for(; i<x.Length-1; i++)
            {
                if(x[i].Equals('0'))
                {
                    x = x.Substring(i + 1);
                }
                else
                {
                    break;
                }
            }
            if(x.Length == 0)
            {
                x.Insert(0, "0");
            }

            return x;
        }
        #endregion

        #region 加法运算

        private static string Add(string X, string Y)
        {
            string ans = "";        // 保存结果
            int carry = 0;
            int midResult = 0;
            int x = 0, y = 0;

            // 验证输入
            X = checkParameter(X);
            Y = checkParameter(Y);

            // 都为负数
            if(X.StartsWith("-") && Y.StartsWith("-"))
            {
                // 取绝对值
                X = Abs(X);
                Y = Abs(Y);
                // 计算结果
                ans = Add(X, Y);
                // 添加符号
                ans = ans.Insert(0, "-");
            }
            // 一负一正
            else if(X.StartsWith("-") && !Y.StartsWith("-"))
            {
                // 取绝对值
                X = Abs(X);
                ans = Sub(Y, X);
            }
            // 一正一负
            else if (!X.StartsWith("-") && Y.StartsWith("-"))
            {
                // 取绝对值，并校验参数
                Y = checkParameter(Abs(Y));
                ans = Sub(X, Y);
            }
            // 都为正数
            else
            {
                // 补齐位数
                FillZero(ref X, ref Y);
                // 计算过程
                for(int i = X.Length-1; i >= 0; i--)
                {
                    x = StringToInt(X[i]);
                    y = StringToInt(Y[i]);

                    midResult = x + y + carry;
                    ans = ans.Insert(0, IntToString(midResult % 10));
                    carry = midResult / 10;
                }
                if(carry != 0)
                {
                    ans = ans.Insert(0, IntToString(carry));
                }
            }

            return ans;
        }
        #endregion

        #region 减法运算

        private static string Sub(string X, string Y)
        {
            string ans = "";        // 保存结果
            bool Sign = true;       // True为正数
            int carry = 0;
            int midResult = 0;
            int x = 0, y = 0;

            // 验证输入
            X = checkParameter(X);
            Y = checkParameter(Y);

            // 都为负数
            if(X.StartsWith("-") && Y.StartsWith("-"))
            {
                // 取绝对值
                X = X.Substring(1);
                Y = Y.Substring(1);
                // 计算结果
                ans = Add(X, Y);
            }
            // 一负一正
            else if (X.StartsWith("-") && !Y.StartsWith("-"))
            {
                // 取绝对值
                X = X.Substring(1);
                ans = Add(X, Y);

            }
            // 一正一负
            else if (!X.StartsWith("-") && Y.StartsWith("-"))
            {
                // 取绝对值
                Y = Y.Substring(1);
                ans = Add(X, Y);
            }
            // 都是正数
            else
            {
                // 补齐位数
                FillZero(ref X, ref Y);
                // 保证被减数大于减数
                x = StringToInt(X[0]); 
                y = StringToInt(Y[0]);
                if(x < y)
                {
                    // 交换
                    Swap(ref X, ref Y);
                }
                // 计算过程
                for (int i = X.Length - 1; i > 0; i--)
                {
                    x = StringToInt(X[i]);
                    y = StringToInt(Y[i]);

                    midResult = x - carry - y;
                    carry = 0;
                    if(midResult < 0)
                    {
                        midResult += 10;
                        carry = 1;
                    }
                    ans = ans.Insert(0, IntToString(midResult % 10));
                }
                x = StringToInt(X[0]);
                y = StringToInt(Y[0]);

                midResult = x - carry - y;
                if (midResult < 0)
                {
                    midResult += 10;
                    Sign = false;
                }
                if(midResult != 0)
                {
                    ans = ans.Insert(0, IntToString(midResult));
                }
                if(!Sign)
                {
                    ans = ans.Insert(0, "-");
                }
            }

            return trim(ans);
        }
        #endregion

        #region 乘法运算

        private static string Mul(string X, string Y)
        {
            string ans = "", ansHigh = "", ansLow = "";
            string high = "", low = "";
            string xHigh = "", xLow = "";
            string yHigh = "", yLow = "";
            int th = 0, tl = 0, xmLen = 0, ymLen = 0;
            bool Sign = true, xSign = true, ySign = true;
            int len = 0, xLen = 0, yLen = 0;
            string AC = "", AD = "", BC = "", BD = "";

            // 验证输入
            X = checkParameter(X);
            Y = checkParameter(Y);

            // 一位正整数相乘
            if(X.Length==1 && Y.Length==1)
            {
                th = StringToInt(X[0]);
                tl = StringToInt(Y[0]);
                th *= tl;

                // 计算并保存
                ans = ans.Insert(0, IntToString(th % 10));
                ans = ans.Insert(0, IntToString(th / 10));
            }
            // 被乘数为一位正整数
            else if(X.Length ==1 && Y.Length>1)
            {
                if(Y.StartsWith("-"))
                {
                    Sign = false;
                    Y = Abs(Y);
                }
                yLen = Y.Length;
                if(yLen == 1)
                {
                    ans = Mul(X, Y);
                    if(!Sign)
                    {
                        ans = ans.Insert(0, "-");
                    }
                }
                else
                {
                    // 采用分治算法，将数字拆分为高位与低位
                    spliteNumber(Y, ref high, ref low);
                    
                    len = low.Length;
                    ansHigh = Mul(X, high);
                    ansLow  = Mul(X, low);
                    // 补齐位数
                    for(int i=0; i<len; i++)
                    {
                        ansHigh = ansHigh.Insert(ansHigh.Length, "0");
                    }
                    // 合并结果
                    ans = Add(ansHigh, ansLow);
                    if(!Sign)
                    {
                        ans = ans.Insert(0, "-");
                    }
                }
            }
            // 乘数是一位数
            else if (X.Length > 1 && Y.Length == 1)
            {
                // 乘法适用交换律
                Swap(ref X, ref Y);

                ans = Mul(X, Y);
            }
            // 一般情形
            else
            {
                // 判断符号
                if(X.StartsWith("-"))
                {
                    xSign = false;
                    X = Abs(X);
                }
                if(Y.StartsWith("-"))
                {
                    ySign = false;
                    Y = Abs(Y);
                }
                if((!xSign && ySign)||(xSign && !ySign))
                {
                    Sign = false;
                }

                xLen = X.Length;
                yLen = Y.Length;
                // 如果有一个数是一位数，则直接递归调用
                if (xLen == 1 || yLen == 1)
                {
                    ans = Mul(X, Y);
                    if (!Sign)
                    {
                        ans = ans.Insert(0, "-");
                    }
                }
                else
                {
                    // 采用分治算法，将数字拆分为高位与低位
                    spliteNumber(X, ref xHigh, ref xLow);
                    spliteNumber(Y, ref yHigh, ref yLow);

                    xmLen = (xLen + 1) / 2;
                    ymLen = (yLen + 1) / 2;

                    AC = Mul(xHigh, yHigh);
                    AD = Mul(xHigh, yLow);
                    BC = Mul(xLow, yHigh);
                    BD = Mul(xLow, yLow);

                    // 补齐位数
                    for (int i = 0; i < xmLen + ymLen; i++)
                    {
                        AC = AC.Insert(AC.Length, "0");
                    }
                    for (int i = 0; i < xmLen; i++)
                    {
                        AD = AD.Insert(AD.Length, "0");
                    }
                    for (int i = 0; i < ymLen; i++)
                    {
                        BC = BC.Insert(BC.Length, "0");
                    }

                    // 合并结果
                    ans = Add(AC, AD);
                    ans = Add(ans, BC);
                    ans = Add(ans, BD);
                    if(!Sign)
                    {
                        ans = ans.Insert(0, "-");
                    }
                }
            }
            return trim(ans);
        }
        #endregion

        /// <summary>
        ///   UI调用接口
        /// </summary>
        /// <param name="para">包含表达式的信息</param>
        public static void ShowResult(string[] para)
        {
            string result;

            switch (para[0])
            {
                case "+": 
                    {
                        result = Add(para[1], para[2]);
                        break;
                    }
                case "-":
                    {
                        result = Sub(para[1], para[2]);
                        break;
                    }
                case "*":
                    {
                        result = Mul(para[1], para[2]);
                        break;
                    }
                default: 
                    {
                        throw new Exception("LargeNumber -- ShowResult: 请检查表达式信息");
                    }
            }

            Console.WriteLine("\n计算结果：");
            Console.WriteLine(String.Format("{0} {1} {2} = {3}", para[1], para[0], para[2], result));
        }
    }
}