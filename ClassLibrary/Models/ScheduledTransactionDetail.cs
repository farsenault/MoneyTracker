using System;

namespace ClassLibrary.Models
{
    public class ScheduledTransactionDetail : ModelBase
    {
        #region fields

        private decimal _amount;
        private string _reference;
        private Guid _scheduledTransactionId;
        private Guid? _productId;

        #endregion

        #region properties

        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (OnPropertyChanging(nameof(Amount), _amount, value))
                {
                    _amount = value;
                    OnPropertyChanged(nameof(Amount));
                }
            }
        }

        public string Reference
        {
            get { return _reference; }
            set
            {
                if (OnPropertyChanging(nameof(Reference), _reference, value))
                {
                    _reference = value;
                    OnPropertyChanged(nameof(Reference));
                }
            }
        }

        public Guid ScheduledTransactionId
        {
            get { return _scheduledTransactionId; }
            set
            {
                if (OnPropertyChanging(nameof(ScheduledTransactionId), _scheduledTransactionId, value))
                {
                    _scheduledTransactionId = value;
                    OnPropertyChanged(nameof(ScheduledTransactionId));
                }
            }
        }

        public Guid? ProductId
        {
            get { return _productId; }
            set
            {
                if (OnPropertyChanging(nameof(ProductId), _productId, value))
                {
                    _productId = value;
                    OnPropertyChanged(nameof(ProductId));
                }
            }
        }

        #endregion
    }
}
