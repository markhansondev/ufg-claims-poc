﻿using System.Collections.Generic;
using System.Linq;

namespace Poc.Claims
{
    public class Claim
    {
        public IEnumerable<Line> Lines => _lines;
        public decimal TotalReserveAmount => Lines.Sum(line => line.ReserveAmount);

        private readonly IList<Line> _lines;

        public Claim(decimal initialReserveAmount)
        {
            _lines = new List<Line> { new(initialReserveAmount) };
        }

        public void AddLine(decimal initialLineAmount)
        {
            _lines.Add(new Line(initialLineAmount));
        }

        //public void CloseLine(Line line)
        //{
            ////We are zeroing out the reserve amount: may be additional steps to closing a line
            ////line.ReserveAmount = 0;
        //}
    }
}