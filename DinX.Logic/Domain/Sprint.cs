using System;
using System.Collections.Generic;

namespace DinX.Logic.Domain
{
    public class Sprint
    {
        public Project Project { get; set; }
        public IList<Item> Items { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
