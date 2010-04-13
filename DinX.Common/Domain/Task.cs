using System;
using System.Collections.Generic;

namespace DinX.Common.Domain
{
    public class Task
    {
        #region Fields
        private IList<User> _listUsers;
        #endregion

        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual Project Project { get; set; }
        public virtual Sprint Sprint { get; set; }
        public virtual IList<User> Users
        {
            get
            {
                return _listUsers ?? (_listUsers = new List<User>());
            }
            set
            {
                _listUsers = value;
            }
        }
    }
}
