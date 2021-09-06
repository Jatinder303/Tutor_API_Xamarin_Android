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
    [Activity(Label = "EditTutor_Activity")]
    public class EditTutor_Activity : Activity
    {
        int Tutor_Id;
        string Tut_Name;
        string Tut_Email;
        string Tut_Mobile;
        string Tut_Address;

        TextView txt_Tutor_Name;
        TextView txt_Tutor_Email;
        TextView txt_Tutor_Mobile;
        TextView txt_Tutor_Address;

        Button btn_Edit;
        Button btn_Delete;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.EditTutor);

            txt_Tutor_Name = FindViewById<TextView>(Resource.Id.txtEditTutorName);
            txt_Tutor_Email = FindViewById<TextView>(Resource.Id.txtEditEmail);
            txt_Tutor_Mobile = FindViewById<TextView>(Resource.Id.txtEditMobile);
            txt_Tutor_Address = FindViewById<TextView>(Resource.Id.txtEditAddress);

            btn_Edit = FindViewById<Button>(Resource.Id.btnEdit);
            btn_Delete = FindViewById<Button>(Resource.Id.btnDelete);

            btn_Edit.Click += OnBtnEditClick;
            btn_Delete.Click += OnBtnDeleteClick;

            Tutor_Id = Convert.ToInt32(Intent.GetLongExtra("TutorId", -1)); //-1 is default as well as TutorId will be a 'long' and is not converting to an 'int' so convertion is used.
            Tut_Name = Intent.GetStringExtra("Tutor_Name");
            Tut_Email = Intent.GetStringExtra("Tutor_Email");
            Tut_Mobile = Intent.GetStringExtra("Tutor_Mobile");
            Tut_Address = Intent.GetStringExtra("Tutor_Address");
          
            txt_Tutor_Name.Text = Tut_Name;
            txt_Tutor_Email.Text = Tut_Email;
            txt_Tutor_Mobile.Text = Tut_Mobile;
            txt_Tutor_Address.Text = Tut_Address;
        }

        public void OnBtnEditClick(object sender, EventArgs e)
        {
            try
            {
                //Toast.MakeText(this, Tutor_Id.ToString(), ToastLength.Long).Show();
                DatabaseManager.Edit_TutorData(txt_Tutor_Name.Text, txt_Tutor_Email.Text, txt_Tutor_Mobile.Text, txt_Tutor_Address.Text, Tutor_Id);
                Toast.MakeText(this, "Tutor data Updated", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred:" + ex.Message);
            }
        }
        public void OnBtnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                DatabaseManager.DeleteTutor_Item(Tutor_Id);
                Toast.MakeText(this, "Tutor Data Deleted", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred:" + ex.Message);
            }
        }
    }
}