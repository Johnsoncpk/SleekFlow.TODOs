using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SleekFlow.TODOs.Library.Dto
{
    //
    // Summary:
    //     Basic Sorting and Paging Dto
    public class SortingPagingDto : PagingDto
    {
        //
        // Summary:
        //     Gets or sets sorting property name. The default is null.
        [MaxLength(128)]
        [DefaultValue(null)]
        public string? Sorting
        {
            get;
            set;
        }

        //
        // Summary:
        //     Gets or sets a value indicating whether is order by descending? The default is
        //     false.
        [DefaultValue(false)]
        public bool IsDesc
        {
            get;
            set;
        }
    }
}
