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
            return firstname == other.Firstname;
            return lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
            return Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname=" + Firstname;
            return "Lastname=" + Lastname;
        }


        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
               return 1;
            }
            return Firstname.CompareTo(other.Firstname);
            return Lastname.CompareTo(other.Lastname);
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
    }
}
