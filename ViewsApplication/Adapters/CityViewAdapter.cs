using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EW_API_DB.Models;

namespace ViewsApplication.Adapters
{
    class CityViewAdapter : BaseAdapter<CityJson>
    {
        private CityJson[] items;
        private Context context;

        public CityViewAdapter(Context context, CityJson[] items)
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            CityViewAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as CityViewAdapterViewHolder;

            if (holder == null)
            {
                holder = new CityViewAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.citylistview_row, null, false);
                
                //holder.Title = view.FindViewById<TextView>(Resource.Id.text);
                //view.Tag = holder;
            }

            TextView txtCity = view.FindViewById<TextView>(Resource.Id.txtCity);
            txtCity.Text = items[position].city_name + ", " + items[position].state_name + ", " + items[position].country_name + " " + items[position].country_code;
            //txtCity.Text = items[position];
            return view;
        }

        public override int Count
        {
            get { return items.Length; }
        }

        public override CityJson this[int position]
        {
            get { return items[position]; }
        }
    }

    class CityViewAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}