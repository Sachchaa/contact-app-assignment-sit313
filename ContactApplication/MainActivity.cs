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
using Android.Content.Res;
using Android.Util;

namespace ContactApplication
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity 
    {
        /* Create List to add contacts */

        private List<Person> contactList = new List<Person>();
        private ListView contactListView;
        private Button btnAddContact;
        Database db; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.content_main);

            db = new Database();
            db.createDatabase();

            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Log.Info("DB_PATH", folder);


            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            /*
                        contactList.Add(new Person() { FirstName = "Sachin", LastName = "Kanishka", MobileNumber = "", HomeNumber = "", Address = "", EmailAddress = "" });
                        contactList.Add(new Person() { FirstName = "Sample", LastName = "Sample", MobileNumber = "", HomeNumber = "", Address = "", EmailAddress = "" });
                        contactList.Add(new Person() { FirstName = "Sample", LastName = "Sample", MobileNumber = "", HomeNumber = "", Address = "", EmailAddress = "" });
                        contactList.Add(new Person() { FirstName = "Sample", LastName = "Sample", MobileNumber = "", HomeNumber = "", Address = "", EmailAddress = "" });
                        contactList.Add(new Person() { FirstName = "Sample", LastName = "Sample", MobileNumber = "", HomeNumber = "", Address = "", EmailAddress = "" });
                        contactList.Add(new Person() { FirstName = "Sample", LastName = "Sample", MobileNumber = "", HomeNumber = "", Address = "", EmailAddress = "" });
                        contactList.Add(new Person() { FirstName = "Sample", LastName = "Sample", MobileNumber = "", HomeNumber = "", Address = "", EmailAddress = "" });
                        contactList.Add(new Person() { FirstName = "Sample", LastName = "Sample", MobileNumber = "", HomeNumber = "", Address = "", EmailAddress = "" });
                        contactList.Add(new Person() { FirstName = "Sample", LastName = "Sample", MobileNumber = "", HomeNumber = "", Address = "", EmailAddress = "" });

               */

            // Create the list view adapter

            contactListView = FindViewById<ListView>(Resource.Id.contactList);
            btnAddContact = FindViewById<Button>(Resource.Id.addContactButton);

            btnAddContact.Click += delegate
            {
                Intent intentAdd = new Intent(this, typeof(AddNewContact));
                StartActivity(intentAdd);
            };

            LoadData();

            contactListView.ItemClick += contactListView_ItemClick;

        }

        void contactListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Toast.MakeText(this, contactList[e.Position].FirstName, ToastLength.Short).Show();

            /*
            for (int i = 0; i < contactListView.Count; i++)
            {
                if (e.Position == i)
                {
                    contactListView.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.DarkGray);
                }
                else
                {
                    contactListView.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
            }

    */

            Intent intent = new Intent(this, typeof(ViewContactDetails));
            intent.PutExtra("ListID", e.Id);
            StartActivity(intent);



        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void LoadData()
        {
            contactList = db.selectTablePerson();
            var adapter = new ListViewAdapter(this, contactList);
            contactListView.Adapter = adapter;

        }
        
    }
}

