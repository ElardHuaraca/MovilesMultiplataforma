using Lab16.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab16.Data
{
    public class StudentManager
    {
        IRestService restService;

        public StudentManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Student>> GetTaskAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Student student, byte[] photo, List<String> dell, bool isNewStudent)
        {
            return restService.SaveStudentToAsync(student, photo, dell, isNewStudent);
        }

        public Task DeleteTaskAsync(Student student)
        {
            return restService.DeleteStudentToAsync(student.StudentID.ToString());
        }
    }
}
