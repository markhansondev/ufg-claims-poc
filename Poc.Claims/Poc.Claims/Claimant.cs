using System.Collections.Generic;
using System.Linq;

namespace Poc.Claims
{
    public class Claimant
    {
        public string Name { get; set; }
        public IEnumerable<Line> Lines => _lines;
        public decimal TotalReserveAmount => Lines.Sum(line => line.ReserveAmount);

        private readonly IList<Line> _lines;

        public Claimant(string name, IEnumerable<Line> lines)
        {
            Name = name;
            _lines = lines.ToList();
        }

        public Claimant(string name)
        {
            Name = name;
            _lines = new List<Line>();
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