using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Tutor_API_Xamarin_Android
{
    public class DatabaseManager
    {
        public static List<Tutor> GetTutorData()
        {

            var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync("http://10.0.2.2:18915/api/Tutors");
            var tutor_Obj = JsonConvert.DeserializeObject<List<Tutor>>(response.Result);
            return tutor_Obj.ToList(); 
        }

        public static void Add_TutorData(string Tutor_Name, string Tutor_Email, string Tutor_Mobile, string Tutor_Address)
        {
            try
            {
                Tutor obj_tutor = new Tutor
                {
                    TutorName = Tutor_Name,
                    Email = Tutor_Email,
                    Mobile = Tutor_Mobile,
                    Address = Tutor_Address
                };
                var httpClient = new HttpClient();
                var Json = JsonConvert.SerializeObject(obj_tutor);
                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                httpClient.PostAsync(string.Format("http://10.0.2.2:18915/api/Tutors"), httpContent);
            }
            catch (Exception e)
            {
                Console.WriteLine("Insert Error:" + e.Message);
            }
        }

        public static void Edit_TutorData(string txt_Tutor_Name,string txt_Tutor_Email,string txt_Tutor_Mobile,string txt_Tutor_Address,int Tutor_Id)
        {
            try
            {
                Tutor obj_tutor = new Tutor
                {
                    TutorName = txt_Tutor_Name,
                    Email = txt_Tutor_Email,
                    Mobile = txt_Tutor_Mobile,
                    Address = txt_Tutor_Address,
                    Id = Tutor_Id
                };
                var httpClient = new HttpClient();
                var Json = JsonConvert.SerializeObject(obj_tutor);
                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                httpClient.PutAsync(string.Format("http://10.0.2.2:18915/api/Tutors/{0}", Tutor_Id), httpContent);
            }
            catch (Exception e)
            {
                Console.WriteLine("Update Error:" + e.Message);
            }
        }

        public static void DeleteTutor_Item(int Tutor_Id)
        {
            try
            {
                Tutor obj_tutor = new Tutor
                {
                    Id = Tutor_Id
                };
                var httpClient = new HttpClient();
                var Json = JsonConvert.SerializeObject(obj_tutor);
                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                httpClient.DeleteAsync(string.Format("http://10.0.2.2:18915/api/Tutors/{0}", Tutor_Id));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Error:" + ex.Message);
            }
        }
    }
}
 

