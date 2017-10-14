using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabMe.DAL
{
    public class RoomPrimaryKey
    {

        #region Class Level Variables

private int? _Id = null;
private int? _IdNonDefault     	= null;
        #endregion

        #region Constants

        #endregion
        #region Constructors / Destructors

        public RoomPrimaryKey( int Id)
        {
			
			this._Id = Id;
			this._IdNonDefault = Id;
			
        }

        #endregion

        #region Properties

            public int? Id 
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