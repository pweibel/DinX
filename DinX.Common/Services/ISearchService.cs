using System.Collections;

namespace DinX.Common.Services
{
    public interface ISearchService
    {
        IList Search(string strQuery);
    }
}
