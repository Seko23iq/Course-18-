using System;
using System.Data;
using ContactsDataAccessLayer;


namespace ContactsBusinessLayer
{
    public class clsContact
    {
        public enum enMode { Add = 1, Update = 2 };
        public enMode Mode = enMode.Add;

        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBrith { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }

        public clsContact()
        {
            ContactID = 0;
            FirstName = "";
            LastName = "";
            Phone = "";
            Email = "";
            Address = "";
            DateOfBrith = DateTime.Now;
            CountryID = 0;
            ImagePath = "";

            Mode = enMode.Add;
        }

        private clsContact(int ContactID, string FirstName, string LastName, string Email,string Phone, string Address, DateTime DateOfBrith, int CountryID, string ImagePath)
        {
            this.ContactID = ContactID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.DateOfBrith = DateOfBrith;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }

        private bool _AddNewContact()
        {
            this.ContactID = clsContactDataAccess.AddNewContact(this.FirstName, this.LastName, this.Email, this.Phone, this.Address, this.DateOfBrith,this.CountryID, this.ImagePath);

            return (this.ContactID != -1);
        }


        private bool _UpdateContact()
        {
            return clsContactDataAccess.UpdateContact(this.ContactID,this.FirstName, this.LastName, this.Email, this.Phone, this.Address, this.DateOfBrith, this.CountryID, this.ImagePath);
        }

        public static clsContact Find(int ContactID)
        {
            string FirstName = "", LastName = "", Phone = "", Email = "", Address = "", ImagePath = ""; 
            int CountryID = 0;
            DateTime DateOfBirth = DateTime.Now;

            if(clsContactDataAccess.GetContactByID(ContactID, ref FirstName, ref LastName, ref Email, ref Phone, ref Address, ref DateOfBirth, ref CountryID, ref ImagePath))
            {
                return new clsContact(ContactID, FirstName, LastName, Email, Phone, Address, DateOfBirth,CountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }


        public static bool DeleteContact(int ContactID)
        {
            return clsContactDataAccess.DeleteContact(ContactID);
        }

        public static DataTable GetAllContacts()
        {
            return clsContactDataAccess.GetAllContacts();
        }

        public static bool isContactExist(int ContactID)
        {
            return clsContactDataAccess.isContactExist(ContactID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.Add:
                    if(_AddNewContact())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateContact();
            }

            return true;
        }


    }
}
