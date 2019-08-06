
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ContactApplication
{
    [Activity(Label = "AddNewContact")]
    public class AddNewContact : Activity
    {
        private EditText txtFirstName;
        private EditText txtLastName;
        private EditText txtMobile;
        private EditText txtHome;
        private EditText txtAddress;
        private EditText txtEmail;

        private Button btnSaveContact;
        private Button btnCancel;

        private List<Person> contactList = new List<Person>();
        private ListView contactListView;
        Database db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addNewContact);

            db = new Database();
            db.createDatabase();

            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Log.Info("DB_PATH", folder);

            txtFirstName = FindViewById<EditText>(Resource.Id.firstNameText);
            txtLastName = FindViewById<EditText>(Resource.Id.lastNameText);
            txtMobile = FindViewById<EditText>(Resource.Id.mobileNumberText);
            txtHome = FindViewById<EditText>(Resource.Id.homeNumberText);
            txtAddress = FindViewById<EditText>(Resource.Id.addressText);
            txtEmail = FindViewById<EditText>(Resource.Id.emailText);

            btnSaveContact = FindViewById<Button>(Resource.Id.saveContactButton);
            btnCancel = FindViewById<Button>(Resource.Id.cancelAddViewButton);

            btnSaveContact.Click += delegate
            {
                Person person = new Person()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    MobileNumber = txtMobile.Text,
                    HomeNumber = txtHome.Text,
                    Address = txtAddress.Text,
                    EmailAddress = txtEmail.Text
                };

                db.InsertInToTablePerson(person);

 
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);


            };

        }
    }
}
