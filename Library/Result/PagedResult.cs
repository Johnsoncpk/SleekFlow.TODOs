using System.ComponentModel.DataAnnotations;

namespace SleekFlow.TODOs.Library.Result
{
    public class PagedResult<T>
    {
        //
        // Summary:
        //     The total number of records. Max 10000.
        [Range(0, 10000)]
        public int TotalCount
        {
            get;
            set;
        }

        //
        // Summary:
        //     The total number of pages. It it TotalCount / PageSize.
        [Range(0, int.MaxValue)]
        public int PageCount
        {
            get;
            set;
        }

        //
        // Summary:
        //     The current page number.
        [Range(1, int.MaxValue)]
        public int CurrentPage
        {
            get;
            set;
        }

        //
        // Summary:
        //     The total number of records per page.
        [Range(1, 200)]
        public int PageSize
        {
            get;
            set;
        }

        //
        // Summary:
        //     The records list.
        public IReadOnlyList<T> Items
        {
            get;
            set;
        }

        public PagedResult()
        {
            Items = new List<T>();
        }

        public PagedResult(int currentPage, int pageSize, int totalCount)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalCount = totalCount;
            Items = new List<T>();
        }
    }
}
