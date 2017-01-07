using System;
using System.Collections.ObjectModel;

namespace ClassLibrary.Models
{
    public class Transaction : ModelBase
    {
        #region fields

        private DateTime _date = DateTime.Now.Date;
        private string _memo;
        private Guid? _receiptId;
        private ObservableCollection<TransactionDetail> _details = new ObservableCollection<TransactionDetail>();
        private Guid? _scheduledTransactionId;
        private ScheduledTransaction _scheduledTransaction;

        #endregion

        #region properties

        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (OnPropertyChanging(nameof(Date), _date, value))
                {
                    _date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        public string Memo
        {
            get { return _memo; }
            set
            {
                if (OnPropertyChanging(nameof(Memo), _memo, value))
                {
                    _memo = value;
                    OnPropertyChanged(nameof(Memo));
                }
            }
        }

        public Guid? ReceiptId
        {
            get { return _receiptId; }
            set
            {
                if (OnPropertyChanging(nameof(ReceiptId), _receiptId, value))
                {
                    _receiptId = value;
                    OnPropertyChanged(nameof(ReceiptId));
                }
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public ObservableCollection<TransactionDetail> Details
        {
            get { return _details; }
            set
            {
                if (OnPropertyChanging(nameof(Details), _details, value))
                {
                    _details = value;
                    OnPropertyChanged(nameof(Details));
                }
            }
        }

        public Guid? ScheduledTransactionId
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

        [System.Xml.Serialization.XmlIgnore]
        public ScheduledTransaction ScheduledTransaction
        {
            get { return _scheduledTransaction; }
            set
            {
                if (OnPropertyChanging(nameof(ScheduledTransaction), _scheduledTransaction, value))
                {
                    _scheduledTransaction = value;
                    OnPropertyChanged(nameof(ScheduledTransaction));
                }
            }
        }

        #endregion
    }
}
