using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

/*  The Template pattern is a method in a superclass, usually an abstract superclass, and defines te skeleton of an
    operation in terms of a number of high level steps. You can override the operation but the skelton should not be
    changed of superclass method.

Example: 
OpenConnection();
Execute();
CloseConnection();

Sql override Execute();
 */
/* Top 5 Design Patterns
 * Iterator Pattern
 * Repository Pattern
 * Unit of Work
 * Mediator Pattern
 * Facade Pattern
 * Strategy Pattern
 * Adapter Pattern
 * Decorator Pattern
 * Factory pattern
 * Bridge Pattern
*/
namespace TemplatePattern
{
    public abstract class AdoDal
    {
        protected SqlCommand comm = null;
        SqlConnection conn = null;

        private void OpenConnection()
        {
            conn.Open();
        }
        public abstract void ExecuteQuery(); // Defering some steps to the subclasses
        private void CloseConnection()
        {
            conn.Close();
        }

        public void Add()
        {
            // Defined the skeleton of an algorithm in an operation.
            OpenConnection();
            ExecuteQuery();
            CloseConnection();
        }
    }

    public class CustomerAdoDal : AdoDal
    {
        // Lets subsclasses redefine certain steps of the algorithms without changing the algorithm structure.
        public override void ExecuteQuery()
        {
            comm.CommandText = "Override Execute";
            comm.ExecuteNonQuery();
        }
    }
}
