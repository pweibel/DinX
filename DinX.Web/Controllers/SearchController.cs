using System;
using System.Web.Mvc;
using DinX.Common.Exceptions;
using DinX.Common.Services;
using DinX.Logic.Services;
using DinX.Web.Models;

namespace DinX.Web.Controllers
{
    public class SearchController : Controller
    {
        #region Fields
        private ISearchService _service;
        #endregion

        #region Properties
        private ISearchService SearchService
        {
            get
            {
                return _service ?? (_service = new SearchService());
            }
        }
        #endregion

    	#region Methods
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Search(string query)
    	{
			SearchViewModel model = new SearchViewModel();

    		try
    		{
				model.Results = this.SearchService.Search(query); 
    		}
    		catch(SearchException ex)
    		{
    			model.ErrorMessage = ex.ErrorMessage;
    		}
    		catch(Exception ex)
    		{
    			model.ErrorMessage = string.Format("Unknown error occured: {0}", ex.Message);
    		}

    		return View(model);
    	}
    	#endregion
    }
}
