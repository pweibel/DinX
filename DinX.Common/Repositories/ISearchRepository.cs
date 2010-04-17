using System.Collections;

namespace DinX.Common.Repositories
{
    public interface ISearchRepository
    {
        IList Search(string strQuery);
    }
}
