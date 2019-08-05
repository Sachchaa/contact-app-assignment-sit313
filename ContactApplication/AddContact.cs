using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace ContactApplication
{
    public class AddContact : Activity
    {
        private List<Person> contactList;
        private ListView contactListView;
        Database db;

        private EditText txtFirstName;
        private EditText txtLastName;
        private EditText txtMobile;
        private EditText txtHome;
        private EditText txtAddress;
        private EditText txtEmail;

        private Button btnSaveContact;
        private Button btnCancel;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            //SetContentView(Resource.Layout.add_contact);

            // var view = inflater.Inflate(Resource.Layout.addContact, container, false);

            txtFirstName = FindViewById<EditText>(Resource.Id.firstNameText);
            txtLastName = FindViewById<EditText>(Resource.Id.lastNameText);
            txtMobile = FindViewById<EditText>(Resource.Id.mobileNumberText);
            txtHome = FindViewById<EditText>(Resource.Id.homeNumberText);
            txtAddress = FindViewById<EditText>(Resource.Id.addressText);
            txtEmail = FindViewById<EditText>(Resource.Id.emailText);

            // btnSaveContact = FindViewById<Button>(Resource.Id.saveButton);
            //btnCancel = FindViewById<Button>(Resource.Id.cancelButton);

            // contactList = new List<Person>();
            /*
            btnSaveContact.Click += delegate
            {
                this.Finish();
            };

            Create the database */

            // db = new Database();
            //db.createDatabase();

            // LoadData();

            /* btnAddContact.Click += delegate
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
                // LoadData();
             };

     */
            //  return view;

        }

        private void LoadData()
        {
            contactList = db.selectTablePerson();
            var adapter = new ListViewAdapter(this, contactList);
            contactListView.Adapter = adapter;


        }
        public AddContact()
        {
        }
    }
}
