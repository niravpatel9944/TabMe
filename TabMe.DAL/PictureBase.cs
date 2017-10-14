using AutoMapper;
using TabMe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PMS.DAL;

namespace TabMe.DAL
{
    public class PictureBase
    {
        #region Class Level Variables

        private DatabaseHelper oDatabaseHelper = new DatabaseHelper();
        private long? _Id = null;
        private int? _EntityType = null;
        private int? _EntityId = null;
        private string _FileExtension = null;

        private int _Page = 1;
        private int _PageRecord = 20;
        private string _SortByColumn = "";
        private string _Orderby = "";
        private int _TotalRecords = 0;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

        /// <summary>
        /// Class Constructor
        ///</summary>
        public PictureBase() { }

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
            }
        }
        public int? EntityType
        {
            get
            {
                return _EntityType;
            }
            set
            {
                _EntityType = value;
            }
        }
        public int? EntityId
        {
            get
            {
                return _EntityId;
            }
            set
            {
                _EntityId = value;
            }
        }
        public string FileExtension
        {
            get
            {
                return _FileExtension;
            }
            set
            {
                _FileExtension = value;
            }
        }
        public int Page
        {
            get
            {
                return _Page;
            }
            set
            {
                if (value == null)
                    _Page = 1;
                else if (value == 0)
                    _Page = 1;
                else
                    _Page = value;
            }
        }
        public int PageRecord
        {
            get
            {
                return _PageRecord;
            }
            set
            {
                if (value == null)
                    _PageRecord = 20;
                else if (value == 0)
                    _PageRecord = 20;
                else
                    _PageRecord = value;
            }
        }
        public string SortByColumn
        {
            get
            {
                return _SortByColumn;
            }
            set
            {
                _SortByColumn = value;
            }
        }
        public string Orderby
        {
            get
            {
                return _Orderby;
            }
            set
            {
                _Orderby = value;
            }
        }
        public int TotalRecords
        {
            get
            {
                return _TotalRecords;
            }
            set
            {
                _TotalRecords = value;
            }
        }
        #endregion
        //-----------------------------
        #region Methods (Public)
        public object InsertUpdate()
        {
            bool ExecutionState = false;
            oDatabaseHelper = new DatabaseHelper();
            oDatabaseHelper.AddParameter("@Id", _Id);
            oDatabaseHelper.AddParameter("@EntityType", _EntityType);
            oDatabaseHelper.AddParameter("@EntityId", _EntityId);
            oDatabaseHelper.AddParameter("@FileExtension", _FileExtension);

            var Result = oDatabaseHelper.ExecuteScalar("Picture_InsertUpdate", ref ExecutionState);
            oDatabaseHelper.Dispose();

            return Result;
        }
        public List<Picture> SelectAllBase(System.Collections.Specialized.NameValueCollection nvc)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            //Default Parameter
            oDatabaseHelper.AddParameter("@Page", Page);
            oDatabaseHelper.AddParameter("@PageRecord", PageRecord);
            oDatabaseHelper.AddParameter("@SortByColumn", SortByColumn);
            oDatabaseHelper.AddParameter("@Orderby", Orderby);
            //Default Parameter

            //This will add additional parameters which are added in child class of this class
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }

            IDataReader dr = oDatabaseHelper.ExecuteReader("Picture_SelectAll", ref ExecutionState);

            return PopulateObjectsFromReader(dr);
        }
        public static Picture GetById(PicturePrimaryKey pk)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("Picture_GetById", ref ExecutionState);

            if (dr.Read())
            {
                Picture obj = new Picture();
                PopulateObjectFromReader(obj, dr);
                dr.Close();
                oDatabaseHelper.Dispose();
                return obj;
            }
            else
            {
                dr.Close();
                oDatabaseHelper.Dispose();
                return null;
            }
        }
        public bool Delete()
        {
            bool ExecutionState = false;
            oDatabaseHelper = new DatabaseHelper();

            oDatabaseHelper.AddParameter("@Id", _Id);
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
            oDatabaseHelper.ExecuteScalar("Picture_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
            return ExecutionState;
        }
        public static bool Delete(PicturePrimaryKey pk)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            oDatabaseHelper.ExecuteScalar("Picture_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
            return ExecutionState;

        }
        #endregion

        #region Methods (Private)
        internal static void PopulateObjectFromReader(Picture obj, IDataReader rdr)
        {
            if (!rdr.IsDBNull(rdr.GetOrdinal("Id")))
                obj.Id = rdr.GetInt64(rdr.GetOrdinal("Id"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("EntityType")))
                obj.EntityType = rdr.GetInt32(rdr.GetOrdinal("EntityType"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("EntityId")))
                obj.EntityId = rdr.GetInt32(rdr.GetOrdinal("EntityId"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("FileExtension")))
                obj.FileExtension = rdr.GetString(rdr.GetOrdinal("FileExtension"));


            Picture.PopulateAdditionalObjectFromReader(obj, rdr);
        }
        internal static List<Picture> PopulateObjectsFromReader(IDataReader rdr)
        {
            List<Picture> list = new List<Picture>();
            while (rdr.Read())
            {
                Picture obj = new Picture();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region Public AutoMapper
        // ViewModel -> ADO Model 
        public static Picture FixBack(PictureViewModel from)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<PictureViewModel, Picture>(); });
            var to = Mapper.Map<PictureViewModel, Picture>(from);
            return to;
        }
        // ADO Model -> ViewModel
        public static PictureViewModel FixBack(Picture from)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Picture, PictureViewModel>(); });
            var to = Mapper.Map<Picture, PictureViewModel>(from);
            return to;
        }
        // List<ADO Model> -> List<ViewModel>
        public static List<PictureViewModel> FixBack(List<Picture> from)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Picture, PictureViewModel>(); });
            var to = Mapper.Map<List<Picture>, List<PictureViewModel>>(from);
            return to;
        }
        // List<ADO Model> -> List<ViewModel>
        public static List<Picture> FixBack(List<PictureViewModel> from)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<PictureViewModel, Picture>(); });
            var to = Mapper.Map<List<PictureViewModel>, List<Picture>>(from);
            return to;
        }

        //// ListViewModel -> ADO Model
        //public static Picture FixBackList(PictureListViewModel from)
        //{
        //    Mapper.CreateMap<PictureListViewModel, Picture>();
        //    var to = Mapper.Map<PictureListViewModel, Picture>(from);
        //    return to;
        //}
        //// ADO Model -> ListViewModel
        //public static PictureListViewModel FixBackList(Picture from)
        //{
        //    Mapper.CreateMap<Picture, PictureListViewModel>();
        //    var to = Mapper.Map<Picture, PictureListViewModel>(from);
        //    return to;
        //}
        #endregion
    }
}