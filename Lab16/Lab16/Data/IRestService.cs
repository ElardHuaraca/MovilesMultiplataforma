using Lab16.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab16.Data
{
    public interface IRestService
    {
        Task<List<Student>> RefreshDataAsync();
        Task SaveStudentToAsync(Student student, byte[] Photo, List<String> dell, bool isNewStudent);
        Task DeleteStudentToAsync(string id);
    }
}
