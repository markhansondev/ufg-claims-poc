using System.Collections.Generic;

namespace Poc.Claims.Experiments.A
{
    public class Class1A
    {
        public virtual long Id { get; protected set; }
        public virtual IEnumerable<Class2A> Class2As => _class2As;
        private readonly IList<Class2A> _class2As;

        public Class1A()
        {
            _class2As = new List<Class2A>
            {
                new Class2A(),
                new Class2A()
            };
        }
    }
}
