using System;
using System.Collections.Generic;

namespace DinX.Common.Domain
{
    public class Project
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual User Owner { get; set; }
        public virtual IList<User> Members { get; set; }
        public virtual IList<Task> ProductBacklog { get; set; }
        public virtual IList<Sprint> Sprints { get; set; }
    }
}
