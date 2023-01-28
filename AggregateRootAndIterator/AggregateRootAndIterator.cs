using System;
using System.Collections.Generic;
using System.Text;

namespace AggregateRootAndIterator
{
    /* 
     * Aggregate root means, child objects are manupulated from the roots i.e. Address type prop. can be manupulated from  AffregateRootAndIterator class
      
       Aggregate root come into picture when insertion/updation/deletion records and DTO when fetching or reading
       record.

       The contained objects can not be manupulated directly from outside. It has to go through the root.
    */
    public class AggregateRootAndIterator
    {
        public AggregateRootAndIterator()
        {
            this._Addresses = new List<Address>();
        }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        private List<Address> _Addresses { get; set; } // Aggregate to Address class

        /* on the root level : Try to restrict not to add more than two address.
         */
        public void Add(Address temp)
        {
            if (this._Addresses.Count > 2)
            {
                throw new Exception("Not allowed");
            }
            this._Addresses.Add(temp);
        }

        // Return address
        //public readonly List<Address> GetAddresses() // readonly
        //public IEnumerable<Address> GetAddresses()
        //public IEnumerator<Address> GetAddresses()
        public IEnumerable<Address> GetAddresses()
        {
            //return this._Addresses.GetEnumerator();
            return this._Addresses; // sugested to clone the object and then use
        }
    }

    public class Address
    {
        public string AddressName { get; set; }
    } // Address is tightly coupled to customer class which is not good
    public class Supplier
    {
        public List<Address> Address { get; set; }
    }
    public class CustomerDTO
    {
        // Whtever is there in inner join just mapped out here send out to render out on view
        public string Name { get; set; }
        public int Amount { get; set; }
        public string AddressName { get; set; }
    }
}


// Aggregation = No object should depend on other object.
