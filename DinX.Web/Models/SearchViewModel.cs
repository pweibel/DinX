using System.Collections;

namespace DinX.Web.Models
{
	public class SearchViewModel
	{
        public string ErrorMessage { get; set; }
        public IList Results { get; set; }
	    public int Count
	    {
	        get { return this.Results == null ? 0 : this.Results.Count; }
	    }
	}
}
