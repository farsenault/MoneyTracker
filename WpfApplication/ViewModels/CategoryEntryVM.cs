using ClassLibrary.Models;

namespace WpfApplication.ViewModels
{
    public class CategoryEntryVM : ViewModelBase<Category>
    {
        public CategoryEntryVM(Category model)
            : base(model)
        {
        }
    }
}
