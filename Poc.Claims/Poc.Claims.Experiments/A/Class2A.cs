using System.Collections.Generic;

namespace Poc.Claims.Experiments.A
{
    public class Class2A
    {
        public virtual long Id { get; protected set; }
        public virtual IEnumerable<Class3A> Class3As => _class3As;
        private readonly IList<Class3A> _class3As;

        public Class2A()
        {
            _class3As = new List<Class3A>
            {
                new Class3A(),
                new Class3A()
            };
        }
    }
}
