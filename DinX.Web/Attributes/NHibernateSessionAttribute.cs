using System;
using System.Web.Mvc;
using DinX.Data.Helper;
using NHibernate;
using NHibernate.Context;

namespace DinX.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class NHibernateSessionAttribute
    : ActionFilterAttribute
    {
        public NHibernateSessionAttribute()
        {
            Order = 100;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ISession session = PersistenceManager.OpenSession();
            CurrentSessionContext.Bind(session);
        }
        
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ISession session = CurrentSessionContext.Unbind(PersistenceManager.Factory);
            session.Close();
        }
    }
}