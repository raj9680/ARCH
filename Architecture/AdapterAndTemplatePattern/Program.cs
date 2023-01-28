using AdapterPattern;
using System;

namespace AdapterAndTemplatePattern
{
    /* When to use 
     
     * Let's say we have an external DAL i.e MySqlDal which is implementing another Third Party Dal i.e TpDal which has Insert and Edit method whereas our Dal has Add and Update method which is doing the exact same operation but the inconsistent names can create confusions. 
     
     * To solve this kind of problems we use adapter pattern. We will create a wrapper class which which will internally call the Insert & Edit method.
     
     */
    class Program
    {
        static void Main(string[] args)
        {
            IDal d = new SqlServerDal();
            d.Add();

            d = new OracleDal();
            d.Add();


            //MySqlTpDal m = new MySqlTpDal();
            //m.Insert();                         // X - due to incompatile interfaces

            d = new MySqlAdapter();              // Correct approach
            d.Add();
            d.Update();


            d = new AdoDal();
            d.Add();
            d.Update();

            

        }
    }
}
