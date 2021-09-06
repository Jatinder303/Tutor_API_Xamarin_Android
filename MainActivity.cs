using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Android.Content;
using Android.Views;

namespace Tutor_API_Xamarin_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView TutorList;
        List<Tutor> myList = new List<Tutor>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            TutorList = FindViewById<ListView>(Resource.Id.listView1);
            myList = DatabaseManager.GetTutorData();
            TutorList.Adapter = new DataAdapter(this, myList);
            TutorList.ItemClick += OnTutor_ListClick;


        }
        //Adds Add to the Menu in the top right of your screen.
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add("Add");
            return base.OnPrepareOptionsMenu(menu);
        }
        //When you choose Add from the Menu run the Add Activity. Good to know to add more options
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var itemTitle = item.TitleFormatted.ToString();

            switch (itemTitle)
            {
                case "Add":
                    StartActivity(typeof(AddTutor_Activity));
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        void OnTutor_ListClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var Tutor_Item = myList[e.Position];
            var Edit_Tutor_item = new Intent(this, typeof(EditTutor_Activity));
            Edit_Tutor_item.PutExtra("Tutor_Name", Tutor_Item.TutorName);
            Edit_Tutor_item.PutExtra("Tutor_Email", Tutor_Item.Email);
            Edit_Tutor_item.PutExtra("Tutor_Mobile", Tutor_Item.Mobile);
            Edit_Tutor_item.PutExtra("Tutor_Address", Tutor_Item.Address);
            Edit_Tutor_item.PutExtra("TutorId", Tutor_Item.Id);
            //Toast.MakeText(this, Tutor_Item.Id.ToString(), ToastLength.Long).Show();
            StartActivity(Edit_Tutor_item);
        }

        //Basically reload stuff when the app resumes operation after being paused
        protected override void OnResume()
        {
            base.OnResume();
            myList.Clear();
            myList = DatabaseManager.GetTutorData();
            TutorList.Adapter = new DataAdapter(this, myList);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}