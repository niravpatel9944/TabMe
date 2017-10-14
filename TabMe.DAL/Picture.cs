using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AutoMapper;

namespace TabMe.DAL
{
    public class Picture : PictureBase
    {

        #region Class Level Variables

        #endregion

        #region Constants

        #endregion
        #region Constructors / Destructors

        public Picture()
            : base()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods (Public)
		/// <summary>
        /// Here you can add additional parameters
        /// </summary>
        /// <returns></returns>
		public List<Picture> SelectAll()
        {
            System.Collections.Specialized.NameValueCollection nvc = new System.Collections.Specialized.NameValueCollection();
			//Example
			//nvc.Add("SQL Parameter Name", Public property of Base class or this class);
			//Do not include @ because it already included in Base class method
            return SelectAllBase(nvc);
        }
        #endregion
		#region Public AutoMapper

		#endregion
        #region Methods (Private)
		//This method is called from base method PopulateObjectFromReader
		//Here you can add additional fields
		internal static void PopulateAdditionalObjectFromReader(Picture obj,IDataReader rdr) 
		{
			// example
			try
			{
				if (!rdr.IsDBNull(rdr.GetOrdinal("TotalRecords")))
					obj.TotalRecords = rdr.GetInt32(rdr.GetOrdinal("TotalRecords"));
			}
			catch { }

			
		}
        #endregion
    }
}