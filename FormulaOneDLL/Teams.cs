using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Teams
    {
        public int teamCode { get; set; }
        public string name { get; set; }
        public string teamFullname { get; set; }
        public string extCountry { get; set; }
        public string powerUnit { get; set; }
        public string technicalChief { get; set; }
        public string chassis { get; set; }
        public int extFirstDriver { get; set; }
        public int extSecondDriver { get; set; }
        public string logo { get; set; }
        public string img { get; set; }

        public Teams(int teamCode, string name, string teamFullname, string extCountry, string powerUnit, string technicalChief, string chassis, int extFirstDriver, int extSecondDriver, string logo, string img)
        {
            this.teamCode = teamCode;
            this.name = name;
            this.teamFullname = teamFullname;
            this.extCountry = extCountry;
            this.powerUnit = powerUnit;
            this.technicalChief = technicalChief;
            this.chassis = chassis;
            this.extFirstDriver = extFirstDriver;
            this.extSecondDriver = extSecondDriver;
            this.logo = logo;
            this.img = img;
        }
    }
}
