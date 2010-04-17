using System;
using System.Collections.Generic;
using NHibernate.Search.Attributes;
using NHibernate.Search.Bridge.Builtin;

namespace DinX.Common.Domain
{
    [Indexed(Index = "Task")] 
    public class Task
    {
        #region Fields
        private IList<User> _listUsers;
        #endregion

        [DocumentId]
        [FieldBridge(typeof(GuidBridge))]
        public virtual Guid Id { get; set; }

        [Field(Index.Tokenized, Store = Store.Yes)]
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
