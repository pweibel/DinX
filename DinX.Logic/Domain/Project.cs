using System.Collections.Generic;

namespace DinX.Logic.Domain
{
    public class Project
    {
        public string Name { get; set; }
        public IList<User> Members { get; set; }
        public IList<Item> ProductBacklog { get; set; }
        public IList<Sprint> Sprints { get; set; }
    }
}
