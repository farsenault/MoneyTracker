using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfApplication.ViewModels
{
    public class TransactionEntryVM : ViewModelBase<Transaction>
    {
        #region fields

        private Guid _fromAccountId;
        private Guid _toAccountId;        
        private decimal _total;                               

        #endregion

        #region properties
        
        public Guid FromAccountId
        {
            get
            {
                return _fromAccountId;
            }

            set
            {
                OnPropertyChanging(nameof(FromAccountId), _fromAccountId, value);
                _fromAccountId = value;
                OnPropertyChanged(nameof(FromAccountId));
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
                OnPropertyChanging(nameof(ToAccountId), _toAccountId, value);
                _toAccountId = value;
                OnPropertyChanged(nameof(ToAccountId));
            }
        }
       
        public decimal Total
        {
            get
            {
                return _total;
            }

            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }              
     
        public ObservableCollection<TransactionEntryLineItemVM> TransactionEntryLineItemVMs { get; private set; } = new ObservableCollection<TransactionEntryLineItemVM>();

        public IEnumerable<Account> FromAccounts { get; private set; }

        public IEnumerable<Account> ToAccounts { get; private set; }

        #endregion

        public TransactionEntryVM(Transaction model, IEnumerable<Account> fromAccounts, IEnumerable<Account> toAccounts)
            : base(model)
        {
            FromAccounts = fromAccounts;
            ToAccounts = toAccounts;

            var trans = Model;

            var payToAccount = trans.Details.Where(t => t.CreditAmount > 0).FirstOrDefault();
            var payFromAccount = trans.Details.Where(t => t.DebitAmount > 0).FirstOrDefault();

            if (payToAccount != null)
            {
                ToAccountId = payToAccount.AccountId;
            }

            if (payFromAccount != null)
            {
                FromAccountId = payFromAccount.AccountId;
            }

            var payFromDetails = trans.Details.Where(t => t.AccountId == FromAccountId).ToArray();
            var payToDetails = trans.Details.Where(t => t.AccountId == ToAccountId).ToArray();

            for (int i = 0; i < payFromDetails.Length; i++)
            {
                var lineItemVM = new TransactionEntryLineItemVM()
                {                    
                    Amount = payToDetails[i].CreditAmount,
                    Reference = payToDetails[i].Reference,
                    TransactionDetailId1 = payFromDetails[i].Id,
                    TransactionDetailId2 = payToDetails[i].Id
                };

                lineItemVM.PropertyChanged += LineItemVM_PropertyChanged;

                TransactionEntryLineItemVMs.Add(lineItemVM);
            }

            TransactionEntryLineItemVMs.CollectionChanged += LineItems_CollectionChanged1;
            ReCalculateTotals();

            PropertyChanging += ReceiptEntryVM_PropertyChanging;
        }

        private void ReceiptEntryVM_PropertyChanging(object sender, ClassLibrary.PropertyChangingEventArgs e)
        {
            if (e.PropertyName == nameof(FromAccountId))
            {
                foreach (var transDetail in Model.Details.Where(t => t.AccountId == (Guid)e.OldValue))
                {
                    transDetail.AccountId = (Guid)e.NewValue;
                }
            }
            else if (e.PropertyName == nameof(ToAccountId))
            {
                foreach (var transDetail in Model.Details.Where(t => t.AccountId == (Guid)e.OldValue))
                {
                    transDetail.AccountId = (Guid)e.NewValue;
                }
            }
        }              

        private void LineItemVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var vm = sender as TransactionEntryLineItemVM;
            var transDetail1 = Model.Details.First(t => t.Id == vm.TransactionDetailId1);
            var transDetail2 = Model.Details.First(t => t.Id == vm.TransactionDetailId2);

            if (e.PropertyName == nameof(vm.Amount))
            {                
                if (transDetail1.AccountId == ToAccountId)
                {
                    transDetail1.CreditAmount = vm.Amount;
                    transDetail2.DebitAmount = vm.Amount;
                }
                else
                {
                    transDetail2.CreditAmount = vm.Amount;
                    transDetail1.DebitAmount = vm.Amount;
                }

                ReCalculateTotals();
            }
            else if (e.PropertyName == nameof(vm.Reference))
            {
                transDetail1.Reference = vm.Reference;
                transDetail2.Reference = vm.Reference;
            }
            else if (e.PropertyName == nameof(vm.ProductId))
            {
                transDetail1.ProductId = vm.ProductId;
                transDetail2.ProductId = vm.ProductId;
            }
        }

        private void LineItems_CollectionChanged1(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (TransactionEntryLineItemVM vm in e.OldItems)
                {
                    UnRegister(vm);                   
                }
            }

            if (e.NewItems != null)
            {
                foreach (TransactionEntryLineItemVM vm in e.NewItems)
                {                   
                    Register(vm);                   
                }
            }
        }       
     
        private void ReCalculateTotals()
        {
            Total = TransactionEntryLineItemVMs.Sum(t => t.Amount);           
        }

        private void Register(TransactionEntryLineItemVM vm)
        {
            var transDetail1 = new TransactionDetail() { Id = vm.TransactionDetailId1, AccountId = ToAccountId, TransactionId = Model.Id };
            var transDetail2 = new TransactionDetail() { Id = vm.TransactionDetailId2, AccountId = FromAccountId, TransactionId = Model.Id };

            Model.Details.Add(transDetail1);
            Model.Details.Add(transDetail2);

            vm.TransactionDetailId1 = transDetail1.Id;
            vm.TransactionDetailId2 = transDetail2.Id;

            vm.PropertyChanged += LineItemVM_PropertyChanged;
        }

        private void UnRegister(TransactionEntryLineItemVM vm)
        {
            Model.Details.Remove(Model.Details.FirstOrDefault(t => t.Id == vm.TransactionDetailId1));
            Model.Details.Remove(Model.Details.FirstOrDefault(t => t.Id == vm.TransactionDetailId2));

            vm.PropertyChanged -= LineItemVM_PropertyChanged;
        }       
    }
}
