using Lab16.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab16.Data
{
    class RestService : IRestService
    {
        HttpClient client;

        public List<Student> Students { get; set; }

        public RestService()
        {
            client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecuretHandler());
        }

        public async Task DeleteStudentToAsync(string id)
        {
            var uri = new Uri(Constant_REST_URL.RestURLStudent + id);
            Console.WriteLine("url: " + uri);
            try
            {
                var response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tStudent Delete");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }

        public async Task<List<Student>> RefreshDataAsync()
        {
            Students = new List<Student>();
            string action = "GET";
            var uri = new Uri(string.Format(Constant_REST_URL.RestURLStudent, action));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Students = JsonConvert.DeserializeObject<List<Student>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
            return Students;
        }

        public async Task SaveStudentToAsync(Student student,byte[] Photo,List<String> dell,bool isNewStudent)
        {
            try
            {
                var form = new MultipartFormDataContent();
                var delete_list = JsonConvert.SerializeObject(dell.ToArray());
                form.Add(new ByteArrayContent(new MemoryStream(Photo).ToArray()), "uploads[]", "img.jpg");
                form.Add(new StringContent(student.StudentID.ToString()), "StudentID");
                form.Add(new StringContent(student.Name), "Name");
                form.Add(new StringContent(student.Paternal_Surname), "Paternal_Surname");
                form.Add(new StringContent(student.Maternal_Surname), "Maternal_Surname");
                form.Add(new StringContent(student.Birth_Date.ToString()), "Birth_Date");
                form.Add(new StringContent(student.Address), "Address");
                form.Add(new StringContent(delete_list), "dell[]");
                HttpResponseMessage response = null;
                if (isNewStudent)
                {
                    var uri = new Uri(string.Format(Constant_REST_URL.RestURLStudent, "POST"));
                    response = await client.PostAsync(uri, form);
                }
                else
                {
                    var uri = new Uri(string.Format(Constant_REST_URL.RestURLStudent, "PUT"));
                    response = await client.PutAsync(uri, form);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tStudent Saved");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
