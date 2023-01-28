using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

/* Adapter pattern allows the interface an existing class to be used as another interface.
 * It is often used to make existing classes work with other *without modifying their source code.
 */
namespace AdapterPattern
{
    interface IDal
    {
        void Add();
        void Update();
    }

    public class SqlServerDal : IDal
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
    public class OracleDal : IDal
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }

    /* Wrapper Class - Object Adapter
     */
    public class MySqlAdapter : IDal
    {
        MySqlTpDal m = new MySqlTpDal(); // Object Adapter
        public void Add()
        {
            m.Insert();
        }
        public void Update()
        {
            m.Edit();
        }
    }


    /* Third Party Dal
     */
    public class MySqlTpDal
    {
        public void Insert()
        {
            // any code
        }
        public void Edit()
        {
            // any code
        }
    }

    /* Third Party Dal
     */
    public class AdoDal : IDal
    {
        SqlCommand comm = null;
        public void Add()
        {
            comm.CommandText = "insert into";
            comm.ExecuteNonQuery();
        }

        public void Update()
        {
            comm.CommandText = "update from";
            comm.ExecuteNonQuery();
        }
    }


    /* Inheritance Adapter
     */
    public class MySqlAdapter1 : MySqlTpDal, IDal // Inheritance
    {
        // Inheritance adapter
        public void Add()
        {
            this.Insert();
        }
        public void Update()
        {
            this.Edit();
        }
    }
}
