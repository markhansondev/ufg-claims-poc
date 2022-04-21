using System;
using System.Collections.Generic;

namespace Poc.Claims
{
    public class Claim
    {
        public decimal ReserveAmount { get; set; }
        public IList<Line> Lines { get; set; } = new List<Line> { new () };

        public void AddLine()
        {
            Lines.Add(new Line());
        }
    }
}