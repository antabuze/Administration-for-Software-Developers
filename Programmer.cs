using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration_for_Software_Developers
{
    [Serializable]
    public class Programmer
    {
        public string Name { get; set; }
        public string PayrollNumber { get; set; }
        public string Salary { get; set; }

        // Array for language skills. Each index represents a language according to: Java/C#/Python. e.g 0/1/0 = skills in C# but not in Java or Python.
        public bool[] languageSkills { get; set; }
        public Programmer(string Name, string PayrollNumber, string Salary, bool[] languageSkills)
        {
            this.Name = Name;
            this.PayrollNumber = PayrollNumber;
            this.Salary = Salary;
            this.languageSkills = languageSkills;
        }
        public Programmer()
        {
            
        }
    } 
}
