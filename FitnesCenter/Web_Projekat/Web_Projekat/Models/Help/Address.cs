using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Projekat.Models
{
    public class Address
    {
        string streetName;
        int streetNumber;
        string city;
        int postNumber;

        public Address()
        {

        }

        public Address(string streetName, int streetNumber, string city, int postNumber)
        {
            this.streetName = streetName;
            this.streetNumber = streetNumber;
            this.city = city;
            this.postNumber = postNumber;
        }

        public string StreetName { get => streetName; set => streetName = value; }
        public int StreetNumber { get => streetNumber; set => streetNumber = value; }
        public string City { get => city; set => city = value; }
        public int PostNumber { get => postNumber; set => postNumber = value; }

        public override string ToString()
        {
            return $"{StreetName} {StreetNumber}";
        }
    }
}