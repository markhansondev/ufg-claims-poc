using System.Collections.Generic;

namespace Poc.Claims.Experiments.B
{
    public class Class2B
    {
        public virtual long Id { get; protected set; }
        public virtual IEnumerable<Class3B> Class3Bs => _class3Bs;
        private readonly IList<Class3B> _class3Bs;

        public virtual void AddClass3B()
        {
            _class3Bs.Add(new Class3B());
        }
    }
}
