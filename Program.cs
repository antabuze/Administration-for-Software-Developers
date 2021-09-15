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
            
            // Collections for different type of employee objects.
            List<Programmer> programmers = new List<Programmer>();
            List<Mentor> mentors = new List<Mentor>();
            List<Mentee> mentees = new List<Mentee>();
            // Imports employee information from XML.
            programmers = dll.ImportXML_Programmer();
            mentors = dll.ImportXML_Mentor();
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

                // Syncs the salaries between the lists.
                SyncSalary();
                
                // Draws the title graphic.
                foreach (string line in title)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("\n     Choose an option (1-5): \n");
                Console.WriteLine("     1. Create new employee");
                Console.WriteLine("     2. List all employees");
                Console.WriteLine("     3. Create new Mentor");
                Console.WriteLine("     4. Create new Mentee");
                Console.WriteLine("     5. List all Mentors and Mentees");
                Console.WriteLine("     6. End Menteeship");
                Console.WriteLine("     7. Exit");
                
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
                        int baseSalary = 30000;
                        
                        // Array for language skills. Each index represents a language according to: Java/C#/Python. e.g 0/1/0 = skills in C# but not in Java or Python.
                        bool[] LanguageSkills = new bool[3];

                        Console.WriteLine("Does the employee got skills with Java? (Y/N)");
                        if(Console.ReadKey().Key == ConsoleKey.Y) { LanguageSkills[0] = true; }
                        else { LanguageSkills[0] = false; }
                        Console.WriteLine();
                        
                        Console.WriteLine("Does the employee got skills with C#? (Y/N)");
                        if (Console.ReadKey().Key == ConsoleKey.Y) { LanguageSkills[1] = true; baseSalary = (int)Math.Ceiling(baseSalary*1.1); }
                        else { LanguageSkills[1] = false; }
                        Console.WriteLine();
                        
                        Console.WriteLine("Does the employee got skills with Python? (Y/N)");
                        if (Console.ReadKey().Key == ConsoleKey.Y) { LanguageSkills[2] = true; }
                        else { LanguageSkills[2] = false; }

                        // Creates a new programmer object, adds it to the list of programmers and saves the list to a XML File.
                        programmers.Add(new Programmer(name, payrollNumber, baseSalary.ToString(), LanguageSkills));
                        dll.ExportXML_Programmers(programmers);
                        break;
                    
                    // Menu Option 2: List all employee
                    case 2:
                        Console.Clear();
                        int totalSalary = 0;
                        Console.WriteLine("Employees:");
                        foreach (Programmer programmer in programmers)
                        {
                            Console.WriteLine("Name: " + programmer.Name);
                            Console.WriteLine("Payroll Number: " + programmer.PayrollNumber);
                            Console.WriteLine("Salary: " + programmer.Salary);
                            Console.WriteLine("Language skills (Java/C#/Python): " + programmer.LanguageSkills[0] + "/" + programmer.LanguageSkills[1] + "/" + programmer.LanguageSkills[2]);
                            Console.WriteLine("-------------");
                            totalSalary += Int32.Parse(programmer.Salary);
                        }
                        Console.WriteLine("TOTAL SALARY COST: " + totalSalary + "kr");
                        Console.ReadKey();
                        break;
                    
                    // Menu Option 3: Create new mentor
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter the payroll number for the new mentor: ");
                        string input = Console.ReadLine();

                        try
                        {
                            foreach (Programmer programmer in programmers)
                            {
                                if (programmer.PayrollNumber == input)
                                {
                                    Mentor mentor = new Mentor(programmer);
                                    mentors.Add(mentor);
                                    dll.ExportXML_Mentors(mentors);
                                }
                            }
                        }
                        catch (Exception)
                        {

                            break;
                        }     
                        break;
                 
                    // Menu Option 4: Create new mentee
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter the payroll number for the new mentee: ");
                        input = Console.ReadLine();
                        try
                        {
                            foreach (Programmer programmer in programmers)
                            {
                                if (programmer.PayrollNumber == input)
                                {
                                    Console.WriteLine("Enter the payroll number of the assigned mentor: ");
                                    foreach (Mentor mentor in mentors)
                                    {
                                        if (mentor.PayrollNumber == Console.ReadLine())
                                        {
                                            Mentee mentee = new Mentee(programmer, mentor);   
                                            mentees.Add(mentee);
                                            mentor.AddMentee(mentee);
                                            dll.ExportXML_Mentee(mentees);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            break;
                        }                      
                        break;
                        

                    // Menu Option 5: List all mentors and their mentees
                    case 5:
                        Console.Clear();
                        foreach (Mentor mentor in mentors)
                        {
                            Console.WriteLine("Name: " + mentor.Name);
                            Console.WriteLine("Payroll Number: " + mentor.PayrollNumber);
                            Console.WriteLine("Salary: " + mentor.Salary);
                            Console.WriteLine("Language skills (Java/C#/Python): " + mentor.LanguageSkills[0] + "/" + mentor.LanguageSkills[1] + "/" + mentor.LanguageSkills[2]);
                            Console.WriteLine("Mentees:");
                            foreach (Mentee mentee in mentor.MenteeList)
                            {
                                Console.WriteLine("     " + mentee.Name);
                            }
                            Console.WriteLine("-------------");
                        }
                        Console.ReadKey();
                        break;
                    
                    // Menu Option 6: End menteeship for a mentee.
                    case 6:
                        Console.Clear();
                        break;

                    // Menu Option 7:
                    case 7:
                        Console.Clear();
                        break;

                }
            } while (userInput != 6);

            void SyncSalary()
            {
                foreach (Programmer programmer in programmers)
                {
                    foreach (Mentor mentor in mentors)
                    {
                        if (mentor.Salary != programmer.Salary && mentor.PayrollNumber == programmer.PayrollNumber)
                        {
                            // Updates the salary in the programmers list.
                            programmer.Salary = mentor.Salary;
                        }
                    }
                }
                
                
                
               
            }
        }
    }
}

// (x)Klasser med olika egenskaper 
// (x)Konstruktorer för dessa klasser
// (x)Metoder för dessa klasser
// (x)Arv mellan minst 2 klasser
// ()Statisk klass med metod som accepterar parametrar
// (x)Polymorphism
// ()Använd en delegate

// (x)Skapa en.DLL
// (x)Exception - handlers

// (x)Datastrukturer(Collections)