using System;
using System.Collections.Generic;

namespace DinX.Common.Domain
{
    public class User
    {
        #region Fields
        private IList<Project> _listProjects;
        private IList<Task> _listTasks;
        #endregion

        public virtual Guid Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string EMail { get; set; }
        public virtual IList<Project> Projects
        {
            get
            {
                return _listProjects ?? (_listProjects = new List<Project>());
            }
            set
            {
                _listProjects = value;
            }
        }
        public virtual IList<Task> Tasks
        {
            get
            {
                return _listTasks ?? (_listTasks = new List<Task>());
            }
            set
            {
                _listTasks = new List<Task>();
            }
        }
    }
}
