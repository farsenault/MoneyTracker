using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication.ViewModels
{
    public class SaveWindowVM : ViewModelBase
    {
        public event EventHandler Save;

        private bool _isSaveVisible = true;

        protected void OnSave()
        {
            Save?.Invoke(this, EventArgs.Empty);
        }

        public ICommand SaveCommand { get; private set; }

        public bool IsSaveVisible
        {
            get
            {
                return _isSaveVisible;
            }

            set
            {
                _isSaveVisible = value;
                OnPropertyChanged(nameof(IsSaveVisible));
            }
        }

        public SaveWindowVM()
        {
            SaveCommand = new Command((o) => OnSave());
        }
    }
}
