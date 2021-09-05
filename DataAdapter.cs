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
    class DataAdapter : BaseAdapter<Tutor>
    {
        private readonly Activity context;
        private readonly List<Tutor> items;
        public DataAdapter(Activity context, List<Tutor> items)
        {
            this.context = context;
            this.items = items;
        }
        public override Tutor this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.AllTutorDetails, null);
            view.FindViewById<TextView>(Resource.Id.lblTutorName).Text = item.TutorName;
            view.FindViewById<TextView>(Resource.Id.lblEmail).Text = item.Email;
            view.FindViewById<TextView>(Resource.Id.lblMobile).Text = item.Mobile;
            view.FindViewById<TextView>(Resource.Id.lblAddress).Text = item.Address;

            return view;
        }
    }
}