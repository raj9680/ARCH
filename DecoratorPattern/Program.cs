using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //ICustomer cust = new CustomerBasic(); // Basic Validation
            //cust = new CustomerPhoneCheck(new CustomerBasic()); // PhoneCheck validation + Basic Validation

            ICustomer cust = new CustomerBasic();
            cust.Validate(); // Basic validation


            // Number of ways by which we can call based on requirement. Basic + Dynamic Extended Validation

            cust = new CustomerPhoneNumberLogic(new CustomerBasic());
            cust.Validate();

            // cust = new CustomerAddressLogic(new CustomerBasic());
            // cust.Validate();

            // cust = new CustomerPhoneNumberLogic(new CustomerAddressLogic(new CustomerBasic()));
            // cust.Validate();

            /* Order of call should always be bottom to top i.e. base (CustomerBasic()) 
             * -> second last (CustomerAddressLogic) 
             * -> first (CustomerPhoneNumberLogic)
            
             * Base will run 1st then CustomerAddressLogic then
             * Second CustomerAddressLogic
             * then CustomerPhoneNumberLogic
            */



        }
    }
}

/* Question: What if we dont have an interface ICustomer in DecoratorPattern class, How we implement decorator pattern ?
 */