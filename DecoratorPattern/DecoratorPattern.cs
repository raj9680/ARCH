using System;
using System.Collections.Generic;
using System.Text;

/* Decorator pattern is a design pattern that allows behavior to be added to an individual object dynamically without affecting the behaviour of other objects from the same class.

 * Decorator Pattern is nearly identical to Chain of Responsibility, the difference being that in chain of responsibilty is exacltly one of the classes handles the request, while for the decorator, all classes handles the
   request.

 * Extension method is not a part of decorator pattern as it is more of more static(extension method).
 * 
 * Step 1. Create Wrapper class.
 * Step 2. 
 */
namespace DecoratorPattern
{
    public interface ICustomer
    {
        string CustomerName { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        void Validate();
    }

    public class CustomerBasic : ICustomer
    {
        /* Question: How do we add the new validation on PhoneNumber without inheritance & changing base class.
         */
        public string CustomerName { get ; set ; }
        public string PhoneNumber { get ; set ; }
        public string Address { get ; set ; }

        // To get rid of null exception need to initialize properties.
        public CustomerBasic()
        {
            CustomerName = "Raj";
            PhoneNumber = "";
            Address = "";
        }


        public void Validate()
        {
            if (CustomerName.Length == 0)
                throw new Exception("Name is needed");
        }
    }

    // Step 1: Wrapper Class
    public abstract class WrapperCustomer: ICustomer
    {
        protected ICustomer _customerNext = null; // It should be protected so that base class cannot access it.
        public WrapperCustomer(ICustomer _cust)
        {
            _customerNext = _cust;
        }

        // Step 2: All steps are passed to the next customer
        public string CustomerName
        {
            get { return _customerNext.CustomerName; }
            set { _customerNext.CustomerName = value; }
        }
        public string PhoneNumber
        {
            get { return _customerNext.PhoneNumber; }
            set { _customerNext.PhoneNumber = value; }
        }
        public string Address
        {
            get { return _customerNext.Address; }
            set { _customerNext.Address = value; }
        }
        public virtual void Validate()
        {
            this._customerNext.Validate();
        }
    }


    // Step 3: Final Implmentation

    /* Dynamic Validation 1(PhoneNumber): Implement Dynamic Logic with Wrapper Class Extension to exend the
       validation dynamically
    */
    public class CustomerPhoneNumberLogic: WrapperCustomer
    {
        public CustomerPhoneNumberLogic(ICustomer cust)
            : base(cust) { } // pass ICustomer object to base class so that the linke dlist is maintained.

        public override void Validate()
        {
            //base.Validate(); // call the base logic/validation also.
            // OR
            _customerNext.Validate();
            
            /* Write the new logic The base will be called first. */
            if (_customerNext.PhoneNumber.Length == 0)
                throw new Exception("Phone number cannot be null");
        }
    }


    /* Dynamic Validation 2(Address): Implement Dynamic Logic with Wrapper Class Extension to exend the
       validation dynamically
    */
    public class CustomerAddressLogic: WrapperCustomer
    {
        public CustomerAddressLogic(ICustomer cust)
            : base(cust) { } // pass ICustomer object to base class so that the linke dlist is maintained.

        public override void Validate()
        {
            //base.Validate(); // call the base logic/validation also.
            // OR
            _customerNext.Validate();
            
            /* Write the new logic The base will be called first. */
            if (_customerNext.Address.Length == 0)
                throw new Exception("Address number cannot be null");
        }
    }
}
