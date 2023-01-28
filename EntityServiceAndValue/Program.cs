using DifferentClassesOfDDD;
using System;
using System.Collections.Generic;

namespace EntityServiceAndValue
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Lecture 1: Entity objects are always different even of the values are same i.e it is compared based on reference not by value.
             */
            Customer obj = new Customer();
            obj.Name = "Raj";

            Customer obj1 = new Customer();
            obj.Name = "Raj";

            Console.WriteLine(obj == obj1);
            Console.WriteLine(obj.Equals(obj1));

            /* Lecture 2: Value objects are always compared based on values.
             */
            //Year y = new Year();
            //y.Value = "12";
            //Year y1 = new Year();
            //y1.Value = "dec";

            //Console.WriteLine(y.Equals(y1));
            //Console.WriteLine(y == y1);      // bcoz of operator overloading
            //Console.WriteLine(y != y1);      // bcoz of operator overloading


            // Values object are always immutable i.e cannot be changed later

            //Year y = new Year();
            //y.Value = "dec";

            //Customer c = new Customer();
            //c.Name = "Raj";

            //c.Year = y;

            //y = new Year { Value = "jan" }; // value dec is assiged but later we assigned jan which is not allowed.

            //Year y = new Year("dec");

            //Customer c = new Customer();
            //c.Name = "Raj";

            //c.Year = y;

            //y = new Year("Jan"); // even if we assign new value it will be assigned to new object, old obj value will no change.

            // Get hascode
            Dictionary<Year, Year> yearCollection = new Dictionary<Year, Year>();
            Year y = new Year("dec");
            yearCollection.Add(y, y);

            Year ylookup = new Year("12");

            Year y1 = yearCollection[ylookup];  // lookup will fail bcoz it uses hascode, so we need to override gethashcode alos
            // for dec, the hash is geting generated differently 
            // for 12, the hash is getting generated differently
        }
    }
}
