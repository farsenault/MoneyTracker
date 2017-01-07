using System;

namespace ClassLibrary.Models
{
    public class Frequency : ModelBase
    {
        #region fields

        private bool _isDaily;
        private bool _isWeekly;
        private bool _isMonthly;
        private int _value;
        private DateTime _beginDate;
        private DateTime? _endDate;

        #endregion

        #region properties

        public bool IsDaily
        {
            get { return _isDaily; }
            set
            {
                if (OnPropertyChanging(nameof(IsDaily), _isDaily, value))
                {
                    _isDaily = value;
                    OnPropertyChanged(nameof(IsDaily));
                }
            }
        }

        public bool IsWeekly
        {
            get { return _isWeekly; }
            set
            {
                if (OnPropertyChanging(nameof(IsWeekly), _isWeekly, value))
                {
                    _isWeekly = value;
                    OnPropertyChanged(nameof(IsWeekly));
                }
            }
        }

        public bool IsMonthly
        {
            get { return _isMonthly; }
            set
            {
                if (OnPropertyChanging(nameof(IsMonthly), _isMonthly, value))
                {
                    _isMonthly = value;
                    OnPropertyChanged(nameof(IsMonthly));
                }
            }
        }

        public int Value
        {
            get { return _value; }
            set
            {
                if (OnPropertyChanging(nameof(Value), _value, value))
                {
                    _value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }
        }

        public DateTime BeginDate
        {
            get { return _beginDate; }
            set
            {
                if (OnPropertyChanging(nameof(BeginDate), _beginDate, value))
                {
                    _beginDate = value;
                    OnPropertyChanged(nameof(BeginDate));
                }
            }
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                if (OnPropertyChanging(nameof(EndDate), _endDate, value))
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        #endregion
    }
}
