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

namespace Tutor_API_Xamarin_Android
{
    [Activity(Label = "AddTutor_Activity")]
    public class AddTutor_Activity : Activity
    {
        Button btn_Add;
        EditText txtItem_TutorName;
        EditText txtItem_Email;
        EditText txtItem_Mobile;
        EditText txtItem_Address;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddTutor);

            txtItem_TutorName = FindViewById<EditText>(Resource.Id.txtItemTutorName);
            txtItem_Email = FindViewById<EditText>(Resource.Id.txtItemEmail);
            txtItem_Mobile = FindViewById<EditText>(Resource.Id.txtItemMobile);
            txtItem_Address= FindViewById<EditText>(Resource.Id.txtItemAddress);

            btn_Add = FindViewById<Button>(Resource.Id.btnAdd);
            btn_Add.Click += OnBtnAddClick;
        }

        private void OnBtnAddClick(object sender, EventArgs e)
        {
            if (txtItem_TutorName.Text != "" && txtItem_Email.Text != "" && txtItem_Mobile.Text != "" && txtItem_Address.Text != "")
            {
                DatabaseManager.Add_TutorData(txtItem_TutorName.Text, txtItem_Email.Text, txtItem_Mobile.Text, txtItem_Address.Text);
                Toast.MakeText(this, "New Tutor data Added", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
            }
        }

    }
}