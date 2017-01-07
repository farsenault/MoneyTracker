using System;

namespace ClassLibrary.Models
{
    public class Category : ModelBase
    {
        #region fields

        private string _name;
        private Guid? _parentCategoryId;        

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

        public Guid? ParentCategoryId
        {
            get { return _parentCategoryId; }
            set
            {
                if (OnPropertyChanging(nameof(ParentCategoryId), _parentCategoryId, value))
                {
                    _parentCategoryId = value;
                    OnPropertyChanged(nameof(ParentCategoryId));
                }
            }
        }

        #endregion
    }
}
