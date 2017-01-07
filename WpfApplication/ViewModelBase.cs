using ClassLibrary;
using System.Windows;
using WpfApplication.ViewModels;

namespace WpfApplication
{
    public abstract class ViewModelBase : NotifyPropertyChangedBase
    {        
        public static MainWindowVM MainWindowVM { get; set; }      

        protected ViewModelBase()
        {            
        }

        public static bool PromptYesNoQuestion(string question)
        {
            var result = MessageBox.Show(question, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class ViewModelBase<T> : ViewModelBase
        where T : ModelBase
    {
        private T _model;

        public T Model
        {
            get
            {
                return _model;
            }

            set
            {
                if (OnPropertyChanging(nameof(Model), _model, value))
                {
                    _model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }
        }

        protected ViewModelBase(T model)
            : base()
        {
            _model = model;            
        }
    }
}
