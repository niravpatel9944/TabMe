using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabMe.DAL
{
    public class PicturePrimaryKey
    {

        #region Class Level Variables

private long? _Id = null;
private long? _IdNonDefault     	= null;
        #endregion

        #region Constants

        #endregion
        #region Constructors / Destructors

        public PicturePrimaryKey( long Id)
        {
			
			this._Id = Id;
			this._IdNonDefault = Id;
			
        }

        #endregion

        #region Properties

            public long? Id 
            {
                get 
			{ 
				return _Id; 
			}
			set 
			{
				_Id = value;
				_IdNonDefault = value;
			}
           }
		#endregion

        #region Methods (Public)
		public System.Collections.Specialized.NameValueCollection GetKeysAndValues() 
		{

			System.Collections.Specialized.NameValueCollection nvc=new System.Collections.Specialized.NameValueCollection();
			
			nvc.Add("Id",_Id.ToString());
			
			return nvc;
		}
        #endregion
        #region Methods (Private)

        #endregion
    }
}