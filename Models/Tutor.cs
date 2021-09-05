using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tutor_API_Xamarin_Android
{
    public class Tutor
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("tutor_Name")]
        public string TutorName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}