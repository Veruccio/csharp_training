﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private object contactDetails;

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
                ContactDetails = value;
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
