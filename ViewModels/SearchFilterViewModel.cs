using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MangaStore.ViewModels
{
    [ValidateNever]
    public class SearchFilterViewModel
    {
        public List<CheckBoxItem> Categories { get; set; }
        public int min_price { get; set; }
        public int max_price { get; set; }
    }
}
