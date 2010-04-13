using System;
using System.Collections.Generic;

namespace DinX.Common.Domain
{
    public class Sprint
    {
        #region Fields
        private IList<Task> _listSprintBacklog;
        #endregion
        
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Start { get; set; }
        public virtual DateTime End { get; set; }
        public virtual Project Project { get; set; }
        public virtual IList<Task> SprintBacklog
        {
            get
            {
                return _listSprintBacklog ?? (_listSprintBacklog = new List<Task>());
            }
            set
            {
                _listSprintBacklog = value;
            }
        }
    }
}
