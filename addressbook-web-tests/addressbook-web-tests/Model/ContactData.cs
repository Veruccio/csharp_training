using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;


namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]

    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private object contactDetails;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname ;
        }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
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

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts select c).ToList();
            }
        }

        public string ContactDetails
        {
            get
            {
                if (contactDetails != null)
                {
                    return ContactDetails;
                }
                else
                {
                    return (CleanUp(Firstname) + CleanUp(Lastname) 
                        + CleanUp(Address) + CleanUp(Address) + CleanUp(HomePhone) 
                        + CleanUp(WorkPhone) + CleanUp(MobilePhone)).Trim();
                }
            }
            set
            {
                contactDetails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone =="")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n"; 
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
            return "firstname=" + Firstname +  "lastname=" + Lastname;
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
