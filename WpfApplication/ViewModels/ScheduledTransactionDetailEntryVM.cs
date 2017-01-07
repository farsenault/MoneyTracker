using ClassLibrary.Models;

namespace WpfApplication.ViewModels
{
    public class ScheduledTransactionDetailEntryVM : ViewModelBase<ScheduledTransactionDetail>
    {
        public ScheduledTransactionDetailEntryVM()
            : this(new ScheduledTransactionDetail())
        {
        }

        public ScheduledTransactionDetailEntryVM(ScheduledTransactionDetail model)
            : base(model)
        {        
        }
    }
}
