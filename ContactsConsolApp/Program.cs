
using System;
using System.Data;
using ContactsBusinessLayer;

namespace ContactsConsolApp
{
    internal class Program
    {

        static void testFindContact(int ContactID)
        {
            clsContact contact1 = clsContact.Find(ContactID);

            if(contact1 != null)
            {
                Console.WriteLine(contact1.FirstName + " " + contact1.LastName);
                Console.WriteLine(contact1.Email);
                Console.WriteLine(contact1.Phone);
                Console.WriteLine(contact1.Address);
                Console.WriteLine(contact1.DateOfBrith);
                Console.WriteLine(contact1.ImagePath);
            } 
            else
            {
                Console.WriteLine("contact [" + ContactID + "] Not Found!");
            }
        }

        static void testAddContact()
        {
            clsContact newContact = new clsContact();

            newContact.FirstName = "John";
            newContact.LastName = "Mark";
            newContact.Phone = "07812313";
            newContact.Email = "John@iq.com";
            newContact.Address = "1 Strereet";
            newContact.ImagePath = "john.jpg";
            newContact.DateOfBrith = new DateTime(1990, 5, 1,1,1,1);
            newContact.CountryID = 1;
            if (newContact.Save())
            {
                Console.WriteLine("Contact Added Successfully with ID: " + newContact.ContactID);
            }
            else
            {
                Console.WriteLine("Failed to add contact.");

            }
        }

        static void testUpdateContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);

            Contact1.FirstName = "Ali";
            Contact1.LastName = "Shap";
            Contact1.Email = "ali@iq.com";
            Contact1.Phone = "078123";
            Contact1.Address = "Bsad 2 - Iraq";
            Contact1.CountryID = 1;
            Contact1.DateOfBrith = new DateTime(1999, 1, 1, 1, 1, 1);
            Contact1.ImagePath = "Ali.png";

            if (Contact1.Save())
            {
                Console.WriteLine("Contact Updated Successfully");
            }
            else
            {
                Console.WriteLine("Error updating contact");
            }
        }

        static void testDeleteContact(int ID)
        {
            bool result = clsContact.DeleteContact(ID);

            if (clsContact.isContactExist(ID))
                if (result)
                    Console.WriteLine("Contact Deleted Successfully");
                else
                    Console.WriteLine("Error deleting contact");
            else
                Console.WriteLine("Contact Not Found!");
          
        }

        static void testGetAllContacts()
        {
            DataTable Contacts = clsContact.GetAllContacts();
            foreach(DataRow row in Contacts.Rows)
            {
                Console.WriteLine(row["ContactID"].ToString() + " - " + row["FirstName"].ToString() + " " + row["LastName"].ToString());
            }
        }

        static void testFindContactFast(int ContactID)
        {
            if(clsContact.isContactExist(ContactID))
                Console.WriteLine("Contact Found!");
            else
                Console.WriteLine("Contact Not Found!");
        }


        static void Main(string[] args)
        {
            //testFindContact(5);
            //testAddContact();
            //testUpdateContact(1);
            //testDeleteContact(32);
            //testGetAllContacts();

            testFindContactFast(1);
            testFindContactFast(100);

            Console.ReadKey();

        }
    }
}
