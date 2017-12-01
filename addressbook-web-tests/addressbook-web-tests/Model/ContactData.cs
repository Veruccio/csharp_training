using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;
        private object contactdetails;
        private string text;

        public ContactData(string firstname, string lastname)
        {
            this.firstname = Firstname;
            this.lastname = Lastname;
        }

        public ContactData(string text)
        {
            this.text = text;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return ContactDetails == other.contactdetails;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            return "contactdetails=" + ContactDetails;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
               return 1;
            }
            return ContactDetails.CompareTo(other.ContactDetails);
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public object ContactDetails
        {
            get
            {
                return contactdetails;
            }
            set
            {
                contactdetails = value;
            }
        }
    }
}
