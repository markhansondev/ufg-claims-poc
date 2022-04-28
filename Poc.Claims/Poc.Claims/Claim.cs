using System.Collections.Generic;
using System.Linq;

namespace Poc.Claims
{
    public class Claim
    {
        public IEnumerable<Line> Lines => _lines;
        private readonly IList<Line> _lines;

        public Claim(decimal initialReserveAmount)
        {
            _lines = new List<Line> { new(initialReserveAmount) };
        }

        public void AddLine(decimal initialLineAmount)
        {
            _lines.Add(new Line(initialLineAmount));
        }
    }
}