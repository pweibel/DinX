using System.Collections.Generic;

namespace DinX.Common.Domain
{
    public class Item
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
        public IList<User> Users { get; set; }
    }
}
