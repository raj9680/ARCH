using System;
using System.Collections.Generic;

namespace AggregateRootAndIterator
{
    /* Lecture 3: 
     */
    class Program
    {
        static void Main(string[] args)
        {
            
            AggregateRootAndIterator o = new AggregateRootAndIterator();
            // o._Addresses.Add(new Address()); // not allowed as property is private now.
            o.Add(new Address()); // allowed using constructor

            // o.GetAddresses().Add(new Address()); // It is not recommended as here we want to access address but this also leads to adding address from here as well which bad approach we can improve this by making the function readonly but this is not good solution using readonly developer can still see Add method but not able to add, so we need to look for to remove add method. IEnumerable or IEnumerator do not have add method so we can replace List by IEnumerable also. IEnumerator(stateful iteration) has more methods

            // using IEnumerable
            //foreach (var item in o.GetAddresses())
            //{
            //   Need to do all logic here
            //}

            // BDW IEnumerable is not the 100% right answere. It can still be overriden see below example:
            /*
            public class Customer
            {
                public IEnumerable<Address> Addresses
                {
                    get { return _Addresses;  }
                }
            }

            public class Breaker
            {
                public void BreakIt()
                {
                    var Customer = new Customer();
                    var addresses = (List<Address>)Customer.Addresses;
                    addresses.Add(new Address()); // It is iEnumerable but still we are able to add new aobject after typecasting it to List
                }
            }
            END */

            // using IEnumerator
            //o.GetAddresses().MoveNext();
            //o.GetAddresses().Current(); // or any logic
            //o.GetAddresses().MoveNext();

            AggregateRootAndIterator a = new AggregateRootAndIterator();
            a.Add(new Address());

            ((List<Address>)o.GetAddresses()).Add(new Address());


        }
    }
}
