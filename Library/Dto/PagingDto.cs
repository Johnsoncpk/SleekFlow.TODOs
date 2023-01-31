using System.ComponentModel.DataAnnotations;

namespace SleekFlow.TODOs.Library.Dto
{
    public class PagingDto
    {
        //
        // Summary:
        //     Gets or sets the page number. The default is 1.
        [Range(1, int.MaxValue)]
        public int Page
        {
            get;
            set;
        } = 1;


        //
        // Summary:
        //     Gets or sets the page size for each page. The default is 10. The max page size
        //     is 200.
        [Range(1, 200)]
        public int PageSize
        {
            get;
            set;
        } = 10;

    }
}
