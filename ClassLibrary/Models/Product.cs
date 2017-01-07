using System;

namespace ClassLibrary.Models
{
    public class Product : ModelBase
    {
        #region fields

        private string _name;
        private string _description;
        private Guid _categoryId;

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

        public string Description
        {
            get { return _description; }
            set
            {
                if (OnPropertyChanging(nameof(Description), _description, value))
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public Guid CategoryId
        {
            get { return _categoryId; }
            set
            {
                if (OnPropertyChanging(nameof(CategoryId), _categoryId, value))
                {
                    _categoryId = value;
                    OnPropertyChanged(nameof(CategoryId));
                }
            }
        }

        #endregion
    }
}
