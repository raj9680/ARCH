using System;
using System.Collections.Generic;
using System.Text;

namespace DifferentClassesOfDDD
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Year Year { get; set; }
    }

    public static class Utility
    {
        public static bool Check(Year y1, Year y2)
        {
            if (y1 == y2)
                return true;
            return false;
        }
    }

    public class Year
    {
        // making class/variable immutable
        private readonly string _value;
        public string Value
        {
            get { return _value; }
        }

        public Year(string _val)
        {
            _value = _val;
        }

        // Equal
        // ==
        // !=
        // gethashCode

        public override bool Equals(object obj)
        {
            var temp = (Year)obj;
            if ((this.Value == "12" && temp.Value == "dec") || (this.Value == "dec" && temp.Value == "12"))
            {
                return true;
            }
            return false;
        }

        /* Operator Overloading
         * 
         */
        public static bool operator !=(Year y1, Year y2)
        {
            if ((y1.Value == "12" && y2.Value == "dec") || (y2.Value == "dec" && y1.Value == "12"))
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Year y1, Year y2)
        {
            if ((y1.Value == "12" && y2.Value == "dec") || (y2.Value == "dec" && y1.Value == "12"))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            // for dec, the hash is geting generated differently 
            // for 12, the hash is getting generated differently

            if (this.Value == "12" || this.Value == "dec")
            {
                return "12".GetHashCode();
            }
            else
            {
                return base.GetHashCode();
            }
        }
    }
}
