using System;

namespace WpfApplication.ViewModels
{
    public class TransactionEntryLineItemVM : ViewModelBase
    {
        private Guid _transactionDetailId1 = Guid.NewGuid();
        private Guid _transactionDetailId2 = Guid.NewGuid();
        private string _reference;
        private decimal _amount;
        private Guid? _productId;

        public string Reference
        {
            get
            {
                return _reference;
            }

            set
            {
                _reference = value;
                OnPropertyChanged(nameof(Reference));
            }
        }

        public decimal Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        public Guid TransactionDetailId1
        {
            get
            {
                return _transactionDetailId1;
            }

            set
            {
                _transactionDetailId1 = value;
                OnPropertyChanged(nameof(TransactionDetailId1));
            }
        }

        public Guid TransactionDetailId2
        {
            get
            {
                return _transactionDetailId2;
            }

            set
            {
                _transactionDetailId2 = value;
                OnPropertyChanged(nameof(TransactionDetailId2));
            }
        }

        public Guid? ProductId
        {
            get
            {
                return _productId;
            }

            set
            {
                _productId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }
    }
}
