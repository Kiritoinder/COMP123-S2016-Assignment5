
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/**
 * Author: Inderjeet Singh
 * StudentNumber: 300874118
 * Description: Driver class for file I/O Exception handling
 * Version: 0.0.1
 * DateCreated: July 21rd, 2016
 * DateModified: July 21rd, 2016
 */
namespace Assignment5
{
    /**
    * this class is the "driver" class for my program
    * @class Program
    */
    class Program
    {
        /**Main method of driver class
         * 
         * @method Main
         * param {string} args
         */
        static void Main(string[] args)
        {
            Menu();
            Exit();
        }

        public static void Menu()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            const char DELIM = ',';

            int choice = 0;

            // While loop for Menu Choices
            while (choice != 2)
            {
                Console.WriteLine("|=======Student Grades=======|");
                Console.WriteLine("| 1) Display Grades          |");
                Console.WriteLine("| 2) Exit                    |");
                Console.WriteLine("|============================|");
                Console.Write("Please Select from above options --> ");
                
                // Exception handling
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    choice = 0;
                }
                switch (choice)
                {
                    case 1:
                        gradeTxt(path, DELIM);
                        ShowGrade(path, DELIM);
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Inavlid selection. Please Choose a valid option\n");
                        break;
                }
            }
        }

        // Create grade.txt file
        private static void gradeTxt(string path, char DELIM)
        {
            string fileName = "grade.txt";
            string[] firstName = { "Inderjeet", "Abhinav", "Iqbal" };
            string[] lastName = { "Singh", "Shardha", "gill" };
            string[] studentID = { "1", "2", "3" };
            string[] subject = { "Methodology", "Programming", "Database" };
            string[] grade = { "A+", "B", "A" };

            try
            {
                FileStream outFile = new FileStream(path + "\\" + fileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);

                for (int i = 0; i < 3; i++)
                {
                    writer.WriteLine(firstName[i] + DELIM + lastName[i] + DELIM + studentID[i] + DELIM + subject[i] + DELIM + grade[i]);
                }
                writer.Close();
                outFile.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error -> {0}", error.Message);
            }
        }

        // Displaying grade
        public static void ShowGrade(string pathName, char DELIM)
        {
            string fileName;
            string[] fields;
            string fileData = "";
            string firstName;
            string lastName;
            string studentIndex;
            string className;
            string classGrade;

            Console.Write("Please enter file name to load --> ");
            fileName = Console.ReadLine();
            Console.WriteLine();

            try
            {
                FileStream inFile = new FileStream(pathName + "\\" + fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                fileData = reader.ReadLine();

                //output for grade.txt file
                while (fileData != null)
                {
                    fields = fileData.Split(DELIM);
                    firstName = fields[0];
                    lastName = fields[1];
                    studentIndex = fields[2];
                    className = fields[3];
                    classGrade = fields[4];

                    Console.WriteLine("{0}, {1}: {2} {3}, {4}", firstName, lastName, studentIndex, className, classGrade);
                    fileData = reader.ReadLine();
                }
                Console.WriteLine();
                reader.Close();
                inFile.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine("File Not Found");
                Console.WriteLine(error.Message);
                Console.WriteLine();
            }
        }
        // Exiting 
        public static void Exit()
        {
            Console.WriteLine();
            Console.WriteLine("|================================|");
            Console.WriteLine("|Bye ----> |Press any key to exit|");
            Console.WriteLine("|================================|");
            Console.ReadKey();
            Console.Clear();
        }
    }//End of namespace
}// end of program