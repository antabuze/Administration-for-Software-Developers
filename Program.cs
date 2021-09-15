using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using DLL;

namespace Administration_for_Software_Developers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instance to access methods from DLL.
            Class1 dll = new Class1();
            
            // Userinput in menu.
            int? userInput = 0;
            
            // Collection for programmer objects.
            List<Programmer> programmers = new List<Programmer>();
            
            // Imports employee information from XML.
            programmers = dll.ImportXML();

            // String array for title graphic
            var title = new[] {
                @"  ___      _           _       _     _             _   _               ",
                @" / _ \    | |         (_)     (_)   | |           | | (_)              ",
                @"/ /_\ \ __| |_ __ ___  _ _ __  _ ___| |_ _ __ __ _| |_ _  ___  _ __    ",
                @"|  _  |/ _` | '_ ` _ \| | '_ \| / __| __| '__/ _` | __| |/ _ \| '_ \   ",
                @"| | | | (_| | | | | | | | | | | \__ \ |_| | | (_| | |_| | (_) | | | |  ",
                @"\_| |_/\__,_|_| |_| |_|_|_| |_|_|___/\__|_|  \__,_|\__|_|\___/|_| |_|  ",
                @"                                                                       ",
                @"                                                                       ",
                @"           _____        __ _                                           ",
                @"          /  ___|      / _| |                                          ",
                @"          \ `--.  ___ | |_| |___      ____ _ _ __ ___                  ",
                @"           `--. \/ _ \|  _| __\ \ /\ / / _` | '__/ _ \                 ",
                @"          /\__/ / (_) | | | |_ \ V  V / (_| | | |  __/                 ",
                @"          \____/ \___/|_|  \__| \_/\_/ \__,_|_|  \___|                 ",
                @"                                 By: Måns Andersson  "
                 };
            
            // Menu system.
            do
            {   
                Console.Clear();
                Console.WindowWidth = 70;
                Console.WriteLine("\n");
                
                
                // Draws the title graphic.
                foreach (string line in title)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("\n     Choose an option (1-5): \n");
                Console.WriteLine("     1. Create new employee");
                Console.WriteLine("     2. List all employees");
                Console.WriteLine("     3. Export XML");
                Console.WriteLine("     4. Import XML");
                Console.WriteLine("     5. Number Five");
                Console.WriteLine("     6. Exit");
                
                try
                {   // PURELY VISUAL: Moves the text cursor to a new position.
                    Console.SetCursorPosition(29, 18);           
                    userInput = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Error! Try Again!");
                    System.Threading.Thread.Sleep(500);
                    userInput = null;
                }
                
                switch (userInput)
                {
                    // Menu Option 1: Create new Employee
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter full name of the employee:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the payroll number of the employee:");
                        string payrollNumber = Console.ReadLine();
                        
                        // Array for language skills. Each index represents a language according to: Java/C#/Python. e.g 0/1/0 = skills in C# but not in Java or Python.
                        bool[] languageSkills = new bool[3];

                        Console.WriteLine("Does the employee got skills with Java? (Y/N)");
                        if(Console.ReadKey().Key == ConsoleKey.Y) { languageSkills[0] = true; }
                        else { languageSkills[0] = false; }
                        Console.WriteLine();
                        
                        Console.WriteLine("Does the employee got skills with C#? (Y/N)");
                        if (Console.ReadKey().Key == ConsoleKey.Y) { languageSkills[1] = true; }
                        else { languageSkills[1] = false; }
                        Console.WriteLine();
                        
                        Console.WriteLine("Does the employee got skills with Python? (Y/N)");
                        if (Console.ReadKey().Key == ConsoleKey.Y) { languageSkills[2] = true; }
                        else { languageSkills[2] = false; }

                        // Creates a new programmer object, adds it to the list of programmers and saves the list to a XML File.
                        programmers.Add(new Programmer(name, payrollNumber, "30000", languageSkills));
                        dll.ExportXML(programmers);
                        break;
                    
                    // Menu Option 2: List all employee
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Employees:");
                        foreach (Programmer programmer in programmers)
                        {
                            Console.WriteLine("Name: " + programmer.Name);
                            Console.WriteLine("Payroll Number: " + programmer.PayrollNumber);
                            Console.WriteLine("Salary: " + programmer.Salary);
                            Console.WriteLine("Language skills (Java/C#/Python): " + programmer.languageSkills[0] + "/" + programmer.languageSkills[1] + "/" + programmer.languageSkills[2]);
                        }
                        Console.ReadKey();
                        break;
                    
                    // Menu Option 3: 
                    case 3:
                        Console.Clear();
                        break;
                 
                    // Menu Option 4:
                    case 4:
                        Console.Clear();
                        break;

                    // Menu Option 5:
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Alternative 5!");
                        System.Threading.Thread.Sleep(2000);
                        break;
                    
                    // Menu Option 6:
                    case 6:
                        Console.Clear();
                        break;

                }
            } while (userInput != 6);
        }
    }
}

