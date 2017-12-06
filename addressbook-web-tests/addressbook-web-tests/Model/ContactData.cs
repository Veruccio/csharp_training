using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string text;
        private string allPhones;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname ;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(WorkPhone) + CleanUp(MobilePhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone =="")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";

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
            return Firstname == other.Firstname
                && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Firstname + "" + Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return (Firstname + "" + Lastname).ToString();
        }


        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
               return 1;
            }
            return (Firstname + "" + Lastname).CompareTo(other);
        }
    }
}
