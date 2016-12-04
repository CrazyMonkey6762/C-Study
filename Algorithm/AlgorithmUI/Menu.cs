/*
 * 算法调用界面 - SystemUI
 * 时间：2016年12月1日22:05:30
 * 创建人：Stone6762
 * 功能实现：现在可以通过统一的界面调用算法了
 */
using System;

namespace AlgorithmUI
{
    /*
     * MENU菜单
     * 时间：2016-11-19
     * 创建人：Stone6762
     * 功能实现：显示菜单界面
     */
    public class Menu
    {
        private const byte Size = 7;
        private byte item;

        public Menu()
        {
            showMenu();
            Console.Write("请输入选项(0-"+Size+")");
            try
            {
                item = Convert.ToByte(Console.ReadLine().Trim());
            }
            catch
            {
                throw new Exception("Menu -- Menu(): 输入格式不正确");
            }
            
            selectItem(item);
        }

        /// <summary>
        ///   显示算法菜单
        /// </summary>
        private void showMenu()
        {
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃          算法演示程序 V0.1               ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃     1.大整数乘法       2.平面最近点对    ┃");
            Console.WriteLine("┃     3.矩阵连乘         4.背包问题        ┃");
            Console.WriteLine("┃     5.N后问题          6.子集和问题      ┃");
            Console.WriteLine("┃     7.旅行售货员       0.退出            ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃     Email: 676280501@qq.com              ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━┛");
        } 

        /// <summary>
        ///   选取菜单选项
        /// </summary>
        /// <param name="item"></param>
        private void selectItem(byte item)
        {
            if (item < 0 || item > Size)
            {
                throw new ArgumentException("Menu -- selectItem: 错误的参数");
            }
            switch (item)
            {
                case 0: 
                    {
                        ShutDown();
                        break;
                    }
                case 1: 
                    {
                        LargeNumberCalcActivity active = new LargeNumberCalcActivity();
                        break;
                    }
                case 2:
                    {
                        CpairActivity active = new CpairActivity();
                        break;
                    }
                case 3:
                    {

                        MatrixActivity active = new MatrixActivity();
                        break;
                    }
                case 4:
                    {
                        PackActivity active = new PackActivity();
                        break;
                    }
                case 5:
                    {
                        NQueenActivity active = new NQueenActivity();
                        break;
                    }
                case 6:
                    {

                        SubSetActivity active = new SubSetActivity();
                        break;
                    }
                case 7:
                    {
                        TravellerActivity active = new TravellerActivity();
                        break;
                    }
                default:
                    {
                        ShutDown();
                        break;
                    }
            }
            cls();
        }

        /// <summary>
        ///   清除屏幕信息
        /// </summary>
        public static void cls()
        {
            Console.Clear();
        }

        /// <summary>
        ///   退出程序
        /// </summary>
        public static void ShutDown() 
        {
            Environment.Exit(0);
        }

        /// <summary>
        ///   返回主菜单
        /// </summary>
        public static void BackMenu()
        {
            Console.WriteLine("\n运行完毕，按回车返回主菜单");
            Console.ReadLine();
            Menu.cls();
        }
    }
}
