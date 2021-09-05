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

    }
}
 

