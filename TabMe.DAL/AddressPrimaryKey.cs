using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabMe.DAL
{
    public class AddressPrimaryKey
    {

        #region Class Level Variables

        private long? _AddressId = null;
        private long? _IdNonDefault = null;
        #endregion

        #region Constants

        #endregion
        #region Constructors / Destructors

        public AddressPrimaryKey(long AddressId)
        {

            this._AddressId = AddressId;
            this._IdNonDefault = AddressId;

        }

        #endregion

        #region Properties

        public long? AddressId
        {
            get
            {
                return _AddressId;
            }
            set
            {
                _AddressId = value;
                _IdNonDefault = value;
            }
        }
        #endregion

        #region Methods (Public)
        public System.Collections.Specialized.NameValueCollection GetKeysAndValues()
        {

            System.Collections.Specialized.NameValueCollection nvc = new System.Collections.Specialized.NameValueCollection();

            nvc.Add("AddressId", _AddressId.ToString());

            return nvc;
        }
        #endregion
        #region Methods (Private)

        #endregion
    }
}