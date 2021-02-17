using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Driver
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dob { get; set; }
        public string placeOfBirth { get; set; }
        public string extCountry { get; set; }
        public string img { get; set; }
        public string description { get; set; }

        public Driver(int id, string firstName, string lastName, DateTime dob, string placeOfBirth, string extCountry, string img, string description)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dob = dob;
            this.placeOfBirth = placeOfBirth;
            this.extCountry = extCountry;
            this.img = img;
            this.description = description;
        }
    }
}
