
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NHibernate;

namespace Poc.Claims.Experiments.A
{
    public class Class1ARepository : Repository<Class1A>
    {
        public Class1A LoadWithClass2AsById(long id)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var class1A = session.Load<Class1A>(id);
                class1A.Class2As.Count(); //lazy load
                transaction.Commit();
                return class1A;
            }
        }
    }
}
