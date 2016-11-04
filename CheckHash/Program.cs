using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelsLogic.Interfaces;
using LevelsLogic.Logic;

namespace CheckHash
{
    class Program
    {
        public static void Main(string[] args)
        {
            Level1Logic _level1 = new Level1Logic();
            //string s = Console.ReadLine();
            int n = Convert.ToInt32(Console.ReadLine());
            bool[] check = new bool[n];
            int a;
            for (int i = 0; i < n; i++)
            {
                a = Convert.ToInt32(Console.ReadLine());
                if (a > 0)
                {
                    check[i] = true;
                }
                else
                {
                    check[i] = false;
                }
            }
            //bool[] check = new bool[8] { true, true, true, true, true, true, true, true };
            int s1 = Level1Logic.GetNumberOfMistakes(Level1Logic.GetHashStringFromBool(check));
            Console.Write(s1 + "\n");
            Console.Read();
        }
    }
}
