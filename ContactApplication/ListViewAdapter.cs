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
        private Activity activity;
        Database db;

        public ListViewAdapter(Activity activity, List<Person> contactItems)
        {
            this.activity = activity;
            this.contactItems = contactItems;
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

            var contactRow = convertView??activity.LayoutInflater.Inflate(Resource.Layout.listView, parent, false);

            TextView txtName = contactRow.FindViewById<TextView>(Resource.Id.txtContact);

           // contactItems = db.selectTablePerson();
            txtName.Text = contactItems[position].FirstName + " " + contactItems[position].LastName; 

            return contactRow;
        }
    }
}
