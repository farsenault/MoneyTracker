using System;

namespace ClassLibrary
{
    public abstract class ModelBase : NotifyPropertyChangedBase
    {
        #region fields
           
        private Guid _id = Guid.NewGuid();

        #endregion

        #region properties

        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (OnPropertyChanging(nameof(Id), _id, value))
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        #endregion

        #region constructors

        protected ModelBase()
            : base()
        {

        }

        //protected ModelBase(Guid id)
        //{
        //    Id = id;
        //}

        #endregion
    }
}
