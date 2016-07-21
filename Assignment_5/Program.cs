
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Exit();
        }

        public static void Menu()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            const char DELIM = ',';

            int selection = 0;

            while (selection != 2)
            {
                Console.WriteLine("|=======Student Grades=======|");
                Console.WriteLine("| 1) Display Grades          |");
                Console.WriteLine("| 2) Exit                    |");
                Console.WriteLine("|============================|");
                Console.Write("Please Select from above options --> ");

                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    selection = 0;
                }
            }
        }
        // Exiting ++++++++++++++++++++++++++++++++++++++
        public static void Exit()
        {
            Console.WriteLine();
            Console.WriteLine("|================================|");
            Console.WriteLine("|Bye ----> |Press any key to exit|");
            Console.WriteLine("|================================|");
            Console.ReadKey();
            Console.Clear();
        }
    }
}