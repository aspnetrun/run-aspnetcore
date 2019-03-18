using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }
    }
}
