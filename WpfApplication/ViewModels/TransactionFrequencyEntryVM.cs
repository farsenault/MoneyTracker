using System;
using System.Collections.ObjectModel;

namespace WpfApplication.ViewModels
{
    public class TransactionFrequencyEntryVM : ViewModelBase
    {
        #region fields
        
        private Guid _selectedFrequencyId;

        #endregion

        #region properties

        public ObservableCollection<TransactionFrequencyVM> Frequencies { get; private set; } = new ObservableCollection<TransactionFrequencyVM>();

        public Guid SelectedFrequencyId
        {
            get
            {
                return _selectedFrequencyId;
            }

            set
            {
                if (OnPropertyChanging(nameof(SelectedFrequencyId), _selectedFrequencyId, value))
                {
                    _selectedFrequencyId = value;
                    OnPropertyChanged(nameof(SelectedFrequencyId));
                }
            }
        }

        #endregion

        public TransactionFrequencyEntryVM()
        {
            // every X days/weeks/months
            //  starts on
            //  ends on            
            Frequencies.Add(new TransactionFrequencyVM() { Id = Guid.NewGuid(), Description = "Day (Every X Days)", IsDaily = true, BeginDate = DateTime.Now.Date });
            Frequencies.Add(new TransactionFrequencyVM() { Id = Guid.NewGuid(), Description = "Week (Every X Weeks)", IsWeekly = true, BeginDate = DateTime.Now.Date });
            Frequencies.Add(new TransactionFrequencyVM() { Id = Guid.NewGuid(), Description = "Month (Every X Months)", IsMonthly = true, BeginDate = DateTime.Now.Date });
        }
    }
}
