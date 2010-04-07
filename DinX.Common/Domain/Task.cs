using System;
using System.Collections.Generic;

namespace DinX.Common.Domain
{
    public class Task
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual Project Project { get; set; }
        public virtual Sprint Sprint { get; set; }
        public virtual IList<User> Users { get; set; }
    }
}
