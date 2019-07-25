using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
namespace ContactApplication
{
    /*    
     Craete the list view adpter to customize the row in the list view
     */

    public class ListViewAdapter: BaseAdapter<Person>
    {
        public List<Person> contactItems;
        private Context contactContext;

        public ListViewAdapter(Context context, List<Person> items)
        {
            contactContext = context;
            contactItems = items;
        }

        public override Person this[int position]
        {
            get { return contactItems[position]; }
        } 

        public override int Count
        {
            get { return contactItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View contactRow = convertView;
            if (contactRow == null)
            {
                contactRow = LayoutInflater.From(contactContext).Inflate(Resource.Layout.listView, null, false);
            }
            TextView txtName = contactRow.FindViewById<TextView>(Resource.Id.txtContact);
            txtName.Text = contactItems[position].FirstName + " " + contactItems[position].LastName; 



            return contactRow;
        }
    }
}
