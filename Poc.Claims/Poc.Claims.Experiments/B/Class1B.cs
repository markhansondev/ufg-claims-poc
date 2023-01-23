using System.Collections.Generic;

namespace Poc.Claims.Experiments.B
{
    public class Class1B
    {
        public virtual long Id { get; protected set; }
        public virtual IEnumerable<Class2BBrief> Class2BBriefs => _class2BBriefs;
        private readonly IList<Class2BBrief> _class2BBriefs;

        public Class1B()
        {
            _class2BBriefs = new List<Class2BBrief>
            {
                new Class2BBrief(),
                new Class2BBrief()
            };
        }
    }
}
