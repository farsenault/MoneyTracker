using System;

namespace ClassLibrary.Models
{
    public class TransactionDetail : ModelBase
    {
        #region fields

        private Guid _transactionId;
        private decimal _debitAmount;
        private decimal _creditAmount;
        private string _reference;
        private Guid _accountId;
        private Guid? _productId;

        #endregion

        #region properties

        public Guid TransactionId
        {
            get { return _transactionId; }
            set
            {
                if (OnPropertyChanging(nameof(TransactionId), _transactionId, value))
                {
                    _transactionId = value;
                    OnPropertyChanged(nameof(TransactionId));
                }
            }
        }

        public decimal DebitAmount
        {
            get { return _debitAmount; }
            set
            {
                if (OnPropertyChanging(nameof(DebitAmount), _debitAmount, value))
                {
                    _debitAmount = value;
                    OnPropertyChanged(nameof(DebitAmount));
                }
            }
        }

        public decimal CreditAmount
        {
            get { return _creditAmount; }
            set
            {
                if (OnPropertyChanging(nameof(CreditAmount), _creditAmount, value))
                {
                    _creditAmount = value;
                    OnPropertyChanged(nameof(CreditAmount));
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

        public Guid AccountId
        {
            get { return _accountId; }
            set
            {
                if (OnPropertyChanging(nameof(AccountId), _accountId, value))
                {
                    _accountId = value;
                    OnPropertyChanged(nameof(AccountId));
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
