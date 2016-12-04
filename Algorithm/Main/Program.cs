using System;
using AlgorithmUI;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu menu;
                while (true)
                {
                    menu = new Menu();
                    menu = null;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                Console.WriteLine("\n按回车键返回菜单");
                Console.ReadLine();
                Menu.cls();
                Main(null);
            }
        }
    }
}
