using System;
using System.Collections.Generic;

namespace DinX.Common.Domain
{
    public class Project
    {
        #region Fields
        private IList<User> _listMembers;
        private IList<Task> _listProductBacklog;
        private IList<Sprint> _listSprints;
        #endregion

        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual User Owner { get; set; }
        public virtual IList<User> Members
        { 
            get
            {
                return _listMembers ?? (_listMembers = new List<User>());
            }
            set
            {
                _listMembers = value;
            }
        }
        public virtual IList<Task> ProductBacklog
        {
            get
            {
                return _listProductBacklog ?? (_listProductBacklog = new List<Task>());
            }
            set
            {
                _listProductBacklog = value;
            }
        }
        public virtual IList<Sprint> Sprints
        {
            get
            {
                return _listSprints ?? (_listSprints = new List<Sprint>());
            }
            set
            {
                _listSprints = value;
            }
        }
    }
}
