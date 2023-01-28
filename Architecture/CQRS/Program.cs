using Ninject;
using Ninject.Modules;
using System;
using System.Reflection;

namespace CQRS
{
    class Program
    {
        static public IKernel kernel = new StandardKernel(); // from Ninject
        static void Main(string[] args)
        {
            kernel.Load(Assembly.GetExecutingAssembly()); // lookups
            CustomerQuery q = new CustomerQuery();
            q.Id = 1;
            CustomerQueryDispatcher x = new CustomerQueryDispatcher();
            // var res = x.Send<CustomerQuery>(q);

            // For command
            // kernel.Load(Assembly.GetExecutingAssembly()); //

            // CustomerCreate insertCustomer = new CustomerCreate(); // to be done by factory.
            // insertCustomer.Name = "Raj";

            // CommandDispatcher dispatcher = new CommandDispatcher();
            // dispatcher.Send(insertCustomer);
        }
    }


    // Ninject Class
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(ICommandHandler<CustomerCreate>)).
                To(typeof(CustomerCreateHandler));

            Bind(typeof(IQueryHandler)).
                To(typeof(CustomerQueryHandler));
        }
    }
}
