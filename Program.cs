﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration_for_Software_Developers
{
    class Program
    {
        static void Main(string[] args)
        {
            int? userInput = 0;
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

            do
            {   // Menu system
                Console.Clear();
                Console.WindowWidth = 70;
                Console.WriteLine("\n");
                
                // Draws the title graphic
                foreach (string line in title)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("\n   Choose an option (1-5): \n");
                Console.WriteLine("     1. Number One");
                Console.WriteLine("     2. Number Two");
                Console.WriteLine("     3. Number Three");
                Console.WriteLine("     4. Number Four");
                Console.WriteLine("     5. Number Five");
                Console.WriteLine("     6. Exit");

                try
                {   // PURELY VISUAL: Moves the text cursor to a new position
                    Console.SetCursorPosition(27, 18);           
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
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Alternative 1!");
                        System.Threading.Thread.Sleep(2000);
                        break;
                  
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Alternative 2!");
                        System.Threading.Thread.Sleep(2000);
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Alternative 3!");
                        System.Threading.Thread.Sleep(2000);
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Alternative 4!");
                        System.Threading.Thread.Sleep(2000);
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Alternative 5!");
                        System.Threading.Thread.Sleep(2000);
                        break;
                    
                    case 6:
                        Console.Clear();
                        break;

                }
            } while (userInput != 6);
        }
        }
    }
