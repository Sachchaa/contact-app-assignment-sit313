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
using System.Linq;
using AlertDialog = Android.App.AlertDialog;

namespace ContactApplication
{
    [Activity(Label = "ViewContactDetails")]
    public class ViewContactDetails : Activity
    {
        
        private EditText editTextFirstName;
        private EditText editTextLastName;
        private EditText editTextMobile;
        private EditText editTextHome;
        private EditText editTextAddress;
        private EditText editTextEmail;

        private Button editButton;
        private Button deleteButton;
        private Button cancelButton;

        private List<Person> contactList;
        Database db; 


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.viewContactDeatils);

            var ListID = Intent.GetLongExtra("ListID", 999);
            int ListIDInt = (int)ListID;

            contactList = new List<Person>();
            db = new Database();

            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Log.Info("DB_PATH", folder);

            editTextFirstName = FindViewById<EditText>(Resource.Id.editFirstNameText);
            editTextLastName = FindViewById<EditText>(Resource.Id.editLastNameText);
            editTextMobile = FindViewById<EditText>(Resource.Id.editMobileNumberText);
            editTextHome = FindViewById<EditText>(Resource.Id.editHomeNumberText);
            editTextAddress = FindViewById<EditText>(Resource.Id.editAddressText);
            editTextEmail = FindViewById<EditText>(Resource.Id.editEmailText);

            editButton = FindViewById<Button>(Resource.Id.editContactButton);
            deleteButton = FindViewById<Button>(Resource.Id.deleteContactButton);
            cancelButton = FindViewById<Button>(Resource.Id.cancelEditViewButton);

            contactList = db.selectTablePerson();
            //contactList = db.selectQueryPerson(ListIDInt);

            editTextFirstName.Text = contactList[ListIDInt].FirstName;
            editTextLastName.Text = contactList[ListIDInt].LastName;
            editTextMobile.Text = contactList[ListIDInt].MobileNumber;
            editTextHome.Text = contactList[ListIDInt].HomeNumber;
            editTextAddress.Text = contactList[ListIDInt].Address;
            editTextEmail.Text = contactList[ListIDInt].EmailAddress;

            editButton.Click += delegate
            {
                Person person = new Person()
                {
                    //Id = ListIDInt,
                    FirstName = editTextFirstName.Text,
                    LastName = editTextLastName.Text,
                    MobileNumber = editTextMobile.Text,
                    HomeNumber = editTextHome.Text,
                    Address = editTextAddress.Text,
                    EmailAddress = editTextEmail.Text

                };

                db.updateTablePerson(person);

                contactList = db.selectTablePerson();
                /*
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetTitle("Edit Contact");
                alertDialog.SetMessage("Edit Contact Done");
                alertDialog.SetNeutralButton("OK", delegate
                {
                    alertDialog.Dispose();
	            });
                alertDialog.Show();
             
    */
                Toast.MakeText(this, "Contact Edited", ToastLength.Short).Show();
                //Intent intent = new Intent(this, typeof(MainActivity));
                //StartActivity(intent);
            };

            deleteButton.Click += delegate {

                Person person = new Person()
                {
                    
                    //Id = ListIDInt,
                    FirstName = editTextFirstName.Text,
                    LastName = editTextLastName.Text,
                    MobileNumber = editTextMobile.Text,
                    HomeNumber = editTextHome.Text,
                    Address = editTextAddress.Text,
                    EmailAddress = editTextEmail.Text

                };

                if (db.selectQueryPerson(person) == true)
                {
                    db.deleteTablePerson(person);
                    contactList.Remove(person);
                }
                else
                {
                    Toast.MakeText(this, "Error in delete", ToastLength.Short).Show();
                }

                //db.deleteTablePerson();
                //contactList = new List<Person>();

                //contactList = db.selectTablePerson();

                Toast.MakeText(this, "Contact Deleted", ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);

            };

            cancelButton.Click += delegate {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };


        }




    }
    
}
