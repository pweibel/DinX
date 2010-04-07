using System;
using System.Collections.Generic;

namespace DinX.Common.Domain
{
    public class User
    {
        public virtual Guid Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string EMail { get; set; }
        public virtual IList<Project> Projects { get; set; }
        public virtual IList<Task> Tasks { get; set; }
    }
}
