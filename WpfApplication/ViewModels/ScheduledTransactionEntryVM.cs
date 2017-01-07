using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfApplication.ViewModels
{
    public class ScheduledTransactionEntryVM : ViewModelBase<ScheduledTransaction>
    {
        #region fields
        
        private Guid _fromAccountId;
        private Guid _toAccountId;
        private decimal _total;

        #endregion

        #region properties

        public IEnumerable<Account> FromAccounts { get; private set; }

        public IEnumerable<Account> ToAccounts { get; private set; }

        public Guid FromAccountId
        {
            get
            {
                return _fromAccountId;
            }

            set
            {
                if (OnPropertyChanging(nameof(FromAccountId), _fromAccountId, value))
                {
                    _fromAccountId = value;
                    OnPropertyChanged(nameof(FromAccountId));
                }
            }
        }

        public Guid ToAccountId
        {
            get
            {
                return _toAccountId;
            }

            set
            {
                if (OnPropertyChanging(nameof(ToAccountId), _toAccountId, value))
                {
                    _toAccountId = value;
                    OnPropertyChanged(nameof(ToAccountId));
                }
            }
        }

        public ObservableCollection<ScheduledTransactionDetailEntryVM> ScheduledTransactionDetailEntryVMs { get; private set; } = new ObservableCollection<ScheduledTransactionDetailEntryVM>();

        public decimal Total
        {
            get
            {
                return _total;
            }

            set
            {                
                if (OnPropertyChanging(nameof(Total), _total, value))
                {
                    _total = value;
                    OnPropertyChanged(nameof(Total));
                }
            }
        }

        #endregion

        public ScheduledTransactionEntryVM(ScheduledTransaction model, IEnumerable<Account> fromAccounts, IEnumerable<Account> toAccounts)
            : base(model)
        {
            FromAccounts = fromAccounts;
            ToAccounts = toAccounts;
            _fromAccountId = model.FromAccountId;
            _toAccountId = model.ToAccountId;

            foreach (var detail in model.Details)
            {
                var vm = new ScheduledTransactionDetailEntryVM(detail);
                ScheduledTransactionDetailEntryVMs.Add(vm);
                Register(vm);
            }

            CalculateTotal();

            ScheduledTransactionDetailEntryVMs.CollectionChanged += ScheduledTransactionDetailEntryVMs_CollectionChanged;
        }

        private void ScheduledTransactionDetailEntryVMs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (ScheduledTransactionDetailEntryVM item in e.OldItems) 
                {
                    UnRegister(item);
                    Model.Details.Remove(item.Model);
                }
            }

            if (e.NewItems != null)
            {
                foreach (ScheduledTransactionDetailEntryVM item in e.NewItems)
                {
                    item.Model.ScheduledTransactionId = Model.Id;
                    Model.Details.Add(item.Model);
                    Register(item);
                }
            }
        }        

        private void Register(ScheduledTransactionDetailEntryVM vm)
        {
            vm.Model.PropertyChanged += ScheduledTransactionDetail_PropertyChanged;
        }

        private void UnRegister(ScheduledTransactionDetailEntryVM vm)
        {
            vm.Model.PropertyChanged -= ScheduledTransactionDetail_PropertyChanged;
        }

        private void ScheduledTransactionDetail_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            Total = Model.Details.Sum(t => t.Amount);
        }
    }
}
