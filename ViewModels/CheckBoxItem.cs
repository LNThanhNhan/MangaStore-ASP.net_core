using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MangaStore.ViewModels
{
	[ValidateNever]
    public class CheckBoxItem
    {
        public int Value { get; set; }
        public string Display { get; set; }
        public bool IsChecked { get; set; }
    }
}
