using System;
using System.Collections.Generic;
using System.Text;

namespace Lab16.Model
{
    public class Student
    {
        public int StudentID { get; set; }
        public String Name { get; set; }
        public String Paternal_Surname { get; set; }
        public String Maternal_Surname { get; set; }
        public DateTime Birth_Date { get; set; }
        public String Address { get; set; }
        public String Image { get; set; }
    }
}
