﻿using System.Collections.Generic;
using System.Linq;

namespace Poc.Claims
{
    public class Claimant
    {
        public virtual long Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual IEnumerable<Line> Lines => _lines;
        public virtual decimal TotalReserveAmount => Lines.Sum(line => line.ReserveAmount);

        private readonly IList<Line> _lines;

        protected Claimant()
        {
        }

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

        public virtual void AddLine(decimal initialReserveAmount, string type)
        {
            _lines.Add(new Line(initialReserveAmount, type));
        }

        public virtual Line GetLine(string type)
        {
            return _lines.Single(line => line.Type.Equals(type));
        }

        public virtual void CloseLine(string type)
        {
            GetLine(type).Close();
        }
    }
}