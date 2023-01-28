using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using Ninject;

namespace CQRS
{
    #region Command
    // Initial thought of CQRS
    public interface ICommand
    {

    }
    public interface IDispatcher // Dispatcher works like a delegates
    {
        void Send<T>(T Command) where T: ICommand;
    }
    public interface ICommandHandler<T>
        where T: ICommand
    {
        void Handle(T command);
    }

    public class CommandDispatcher : IDispatcher // Dispatcher- It can dispatch any kind of command
    {
        public void Send<T>(T Command) where T : ICommand
        {
            var handler = Program.kernel.Get<ICommandHandler<T>>();
            handler.Handle(Command);
        }
    }


    // Customer 
    public class Customer // Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class CustomerCreate: Customer, ICommand
    {
        public bool IsActive { get; set; }
        public string UpdatedBy { get; set; }
    }
    public class CustomerCreateHandler : ICommandHandler<CustomerCreate>
    {
        public void Handle(CustomerCreate command)
        {
            Console.WriteLine("Inserted of ADO Executed");
            Console.WriteLine(command.Name+" Inserted");
        }
    }


    public class CustomerEdit : ICommand
    {
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string UpdatedBy { get; set; }
    }
    public class CustomerEditHandler : ICommandHandler<CustomerEdit>
    {
        public void Handle(CustomerEdit command)
        {
            Console.WriteLine("Edit of ADO Executed");
            Console.WriteLine(command.Address + " Updated");
        }
    }

    #endregion Command

    public interface IQuery
    {

    }
    public interface IResult
    {

    }
    public interface IQueryHandler
    {
        IResult Handle(IQuery query);
    }
    public interface IQueryDispatcher
    {
        IResult Send<T>(T query) where T : IQuery;
    }


    public class CustomerQuery
    {
        public int Id { get; set; }
    }
    public class CustomerResult
    {
        public string LastUpdatedBy { get; set; }
    }

    public class CustomerQueryHandler : IQueryHandler
    {
        public IResult Handle(IQuery query)
        {
            throw new NotImplementedException("We will see this later");
        }
    }
    public class CustomerQueryDispatcher : IQueryDispatcher
    {
        public IResult Send<T>(T query) where T : IQuery
        {
            var handler = Program.kernel.Get<IQueryHandler>();
            return handler.Handle(query);
        }
    }
}
