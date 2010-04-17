using System;
using System.Collections;
using DinX.Common.Exceptions;
using DinX.Common.Repositories;
using DinX.Common.Services;
using DinX.Data.Repositories;

namespace DinX.Logic.Services
{
    public class SearchService : ISearchService
    {
        #region Fields
        private ISearchRepository _searchRepository;
        #endregion

        #region Properties
        private ISearchRepository SearchRepository
        {
            get
            {
                return _searchRepository ?? (_searchRepository = new SearchRepository());
            }
        }
        #endregion
        
        public IList Search(string strQuery)
        {
            if(string.IsNullOrEmpty(strQuery)) throw new SearchException("Die Suchanfrage ist ungültig.");

            IList listResult;
            try
            {
                listResult = this.SearchRepository.Search(strQuery);
            }
            catch(Exception ex)
            {
                throw new SearchException(ex.Message);
            }

            return listResult;
        }
    }
}
