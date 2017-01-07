using ClassLibrary.Models;

namespace WpfApplication.ViewModels
{
    public class ProductEntryVM : ViewModelBase<Product>
    {
        public ProductEntryVM(Product model) 
            : base(model)
        {
        }
    }
}
