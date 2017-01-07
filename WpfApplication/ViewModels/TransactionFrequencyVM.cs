using System;

namespace WpfApplication.ViewModels
{
    public class TransactionFrequencyVM : ViewModelBase
    {
        #region fields

        private string _description;
        private int _frequency;
        private DateTime? _beginDate;
        private DateTime? _endDate;
        private Guid _id;
        private bool _isDaily;
        private bool _isWeekly;
        private bool _isMonthly;

        #endregion

        #region properties

        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public int Frequency
        {
            get
            {
                return _frequency;
            }

            set
            {
                _frequency = value;
                OnPropertyChanged(nameof(Frequency));
            }
        }

        public DateTime? BeginDate
        {
            get
            {
                return _beginDate;
            }

            set
            {
                _beginDate = value;
                OnPropertyChanged(nameof(BeginDate));
            }
        }

        public DateTime? EndDate
        {
            get
            {
                return _endDate;
            }

            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public bool IsDaily
        {
            get
            {
                return _isDaily;
            }

            set
            {
                _isDaily = value;
                OnPropertyChanged(nameof(IsDaily));
            }
        }

        public bool IsWeekly
        {
            get
            {
                return _isWeekly;
            }

            set
            {
                _isWeekly = value;
                OnPropertyChanged(nameof(IsWeekly));
            }
        }

        public bool IsMonthly
        {
            get
            {
                return _isMonthly;
            }

            set
            {
                _isMonthly = value;
                OnPropertyChanged(nameof(IsMonthly));
            }
        }

        #endregion
    }
}
