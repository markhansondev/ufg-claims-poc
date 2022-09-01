using System.Collections.Generic;
using System.Linq;

namespace Poc.Claims
{
    public class Claim
    {
        public IEnumerable<Line> Lines => _lines;
        public decimal TotalReserveAmount => Lines.Sum(line => line.ReserveAmount);

        private readonly IList<Line> _lines;

        public Claim(IEnumerable<Line> lines)
        {
            _lines = lines.ToList();
        }

        public void AddLine(decimal initialLineAmount, string lineType)
        {
            _lines.Add(new Line(initialLineAmount, lineType));
        }

        public Line GetLine(string lineType)
        {
            return _lines.Single(line => line.LineType.Equals(lineType));
        }

        public void CloseLine(string lineType)
        {
            GetLine(lineType).Close();
        }
    }
}