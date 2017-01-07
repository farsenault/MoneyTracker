using System;

namespace ClassLibrary.Models
{
    public class Account : ModelBase
    {
        #region fields

        private string _name;
        private string _type;
        private decimal _balance;
        private Address _address;
        private string _phone;
        private string _email;
        private string _website;
        private Guid? _parentAccountId;

        #endregion

        #region properties

        public string Name
        {
            get { return _name; }
            set
            {
                if (OnPropertyChanging(nameof(Name), _name, value))
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                if (OnPropertyChanging(nameof(Type), _type, value))
                {
                    _type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (OnPropertyChanging(nameof(Balance), _balance, value))
                {
                    _balance = value;
                    OnPropertyChanged(nameof(Balance));
                }
            }
        }

        public Address Address
        {
            get { return _address; }
            set
            {
                if (OnPropertyChanging(nameof(Address), _address, value))
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (OnPropertyChanging(nameof(Phone), _phone, value))
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (OnPropertyChanging(nameof(Email), _email, value))
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Website
        {
            get { return _website; }
            set
            {
                if (OnPropertyChanging(nameof(Website), _website, value))
                {
                    _website = value;
                    OnPropertyChanged(nameof(Website));
                }
            }
        }

        public Guid? ParentAccountId
        {
            get { return _parentAccountId; }
            set
            {
                if (OnPropertyChanging(nameof(ParentAccountId), _parentAccountId, value))
                {
                    _parentAccountId = value;
                    OnPropertyChanged(nameof(ParentAccountId));
                }
            }
        }

        #endregion
    }
}
