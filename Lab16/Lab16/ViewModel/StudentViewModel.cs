using Lab16.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Lab16.ViewModel
{
    public class StudentViewModel : BaseViewModel
    {
        #region Attribute
        private List<Student> students;
        private Student student;
        private int studentID;
        private string name;
        private string paternal_Surname;
        private string maternal_Surname;
        private DateTime birth_Date;
        private string address;
        private string image;
        #endregion Attribute

        #region Properties
        public List<Student> Students 
        {
            get { return this.students; }
            set { SetValue(ref this.students,value); } 
        }
        public Student Student 
        {
            get { return this.student; }
            set { SetValue(ref this.student, value); }
        }
        public int StudentID 
        {
            get { return this.studentID; }
            set { SetValue(ref this.studentID, value); }
        }
        public string Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }
        public string Paternal_Surname 
        {
            get { return this.paternal_Surname; }
            set { SetValue(ref this.paternal_Surname, value); } 
        }
        public string Maternal_Surname
        {
            get { return this.maternal_Surname; }
            set { SetValue(ref this.maternal_Surname, value); }
        }
        public DateTime Birth_Date
        {
            get { return this.birth_Date; }
            set { SetValue(ref this.birth_Date, value); }
        }
        public string Address
        {
            get { return this.address; }
            set { SetValue(ref this.address, value); }
        }
        public string Image
        {
            get { return this.image; }
            set { SetValue(ref this.image, value); }
        }
        #endregion Properties
        #region Method
        protected async void listStudents()
        {
            var students = await Task.Run(() => App.StudentManager.GetTaskAsync());
            this.Students = students;
        }
        #endregion Method
        #region Constructor
        public StudentViewModel()
        {
            this.Birth_Date = DateTime.Now;
            this.listStudents();
        }
        #endregion Constructor
    }
}
