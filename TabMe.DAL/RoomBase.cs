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
    public class RoomBase
    {
        #region Class Level Variables

        private DatabaseHelper oDatabaseHelper = new DatabaseHelper();
        private int? _Id = null;
        private short? _RoomTypeId = null;
        private string _Code = null;
        private string _Name = null;
        private short? _Capacity = null;
        private decimal? _Rate = null;
        private int? _PackageId = null;
        private string _Description = null;
        private string _Remarks = null;
        private bool? _IsMinSpend = null;
        private decimal? _MinSpendRate = null;
        private bool? _IsPeak = null;
        private string _PeakOpenTime = null;
        private string _PeakCloseTime = null;
        private decimal? _PeakRate = null;
        private bool? _IsCustomRateTiming = null;
        private string _CRTOpenTime = null;
        private string _CRTCloseTime = null;
        private decimal? _CRTRate = null;
        private bool? _Status = null;

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
        public RoomBase() { }

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
            }
        }
        public short? RoomTypeId
        {
            get
            {
                return _RoomTypeId;
            }
            set
            {
                _RoomTypeId = value;
            }
        }
        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public short? Capacity
        {
            get
            {
                return _Capacity;
            }
            set
            {
                _Capacity = value;
            }
        }
        public decimal? Rate
        {
            get
            {
                return _Rate;
            }
            set
            {
                _Rate = value;
            }
        }
        public int? PackageId
        {
            get
            {
                return _PackageId;
            }
            set
            {
                _PackageId = value;
            }
        }
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        public string Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
            }
        }
        public bool? IsMinSpend
        {
            get
            {
                return _IsMinSpend;
            }
            set
            {
                _IsMinSpend = value;
            }
        }
        public decimal? MinSpendRate
        {
            get
            {
                return _MinSpendRate;
            }
            set
            {
                _MinSpendRate = value;
            }
        }
        public bool? IsPeak
        {
            get
            {
                return _IsPeak;
            }
            set
            {
                _IsPeak = value;
            }
        }
        public string PeakOpenTime
        {
            get
            {
                return _PeakOpenTime;
            }
            set
            {
                _PeakOpenTime = value;
            }
        }
        public string PeakCloseTime
        {
            get
            {
                return _PeakCloseTime;
            }
            set
            {
                _PeakCloseTime = value;
            }
        }
        public decimal? PeakRate
        {
            get
            {
                return _PeakRate;
            }
            set
            {
                _PeakRate = value;
            }
        }

        public bool? IsCustomRateTiming
        {
            get
            {
                return _IsCustomRateTiming;
            }
            set
            {
                _IsCustomRateTiming = value;
            }
        }
        public string CRTOpenTime
        {
            get
            {
                return _CRTOpenTime;
            }
            set
            {
                _CRTOpenTime = value;
            }
        }
        public string CRTCloseTime
        {
            get
            {
                return _CRTCloseTime;
            }
            set
            {
                _CRTCloseTime = value;
            }
        }
        public decimal? CRTRate
        {
            get
            {
                return _CRTRate;
            }
            set
            {
                _CRTRate = value;
            }
        }

        public bool? Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
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
            oDatabaseHelper.AddParameter("@RoomTypeId", _RoomTypeId);
            oDatabaseHelper.AddParameter("@Code", _Code);
            oDatabaseHelper.AddParameter("@Name", _Name);
            oDatabaseHelper.AddParameter("@Capacity", _Capacity);
            oDatabaseHelper.AddParameter("@Rate", _Rate);
            oDatabaseHelper.AddParameter("@PackageId", _PackageId);
            oDatabaseHelper.AddParameter("@Description", _Description);
            oDatabaseHelper.AddParameter("@Remarks", _Remarks);
            oDatabaseHelper.AddParameter("@IsMinSpend", _IsMinSpend);
            oDatabaseHelper.AddParameter("@MinSpendRate", _MinSpendRate);
            oDatabaseHelper.AddParameter("@IsPeak", _IsPeak);
            oDatabaseHelper.AddParameter("@PeakOpenTime", _PeakOpenTime);
            oDatabaseHelper.AddParameter("@PeakCloseTime", _PeakCloseTime);
            oDatabaseHelper.AddParameter("@PeakRate", _PeakRate);
            oDatabaseHelper.AddParameter("@IsCustomRateTiming", _IsCustomRateTiming);
            oDatabaseHelper.AddParameter("@CRTOpenTime", _CRTOpenTime);
            oDatabaseHelper.AddParameter("@CRTCloseTime", _CRTCloseTime);
            oDatabaseHelper.AddParameter("@CRTRate", _CRTRate);
            oDatabaseHelper.AddParameter("@Status", _Status);

            var Result = oDatabaseHelper.ExecuteScalar("Room_InsertUpdate", ref ExecutionState);
            oDatabaseHelper.Dispose();

            return Result;
        }
        public List<Room> SelectAllBase(System.Collections.Specialized.NameValueCollection nvc)
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

            IDataReader dr = oDatabaseHelper.ExecuteReader("Room_SelectAll", ref ExecutionState);

            return PopulateObjectsFromReader(dr);
        }
        public static Room GetById(RoomPrimaryKey pk)
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

            IDataReader dr = oDatabaseHelper.ExecuteReader("Room_GetById", ref ExecutionState);

            if (dr.Read())
            {
                Room obj = new Room();
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
            oDatabaseHelper.ExecuteScalar("Room_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
            return ExecutionState;
        }
        public static bool Delete(RoomPrimaryKey pk)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            oDatabaseHelper.ExecuteScalar("Room_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
            return ExecutionState;

        }
        #endregion

        #region Methods (Private)
        internal static void PopulateObjectFromReader(Room obj, IDataReader rdr)
        {
            if (!rdr.IsDBNull(rdr.GetOrdinal("Id")))
                obj.Id = rdr.GetInt32(rdr.GetOrdinal("Id"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("RoomTypeId")))
                obj.RoomTypeId = rdr.GetInt16(rdr.GetOrdinal("RoomTypeId"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("Code")))
                obj.Code = rdr.GetString(rdr.GetOrdinal("Code"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("Name")))
                obj.Name = rdr.GetString(rdr.GetOrdinal("Name"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("Capacity")))
                obj.Capacity = rdr.GetInt16(rdr.GetOrdinal("Capacity"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("Rate")))
                obj.Rate = rdr.GetDecimal(rdr.GetOrdinal("Rate"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("PackageId")))
                obj.PackageId = rdr.GetInt32(rdr.GetOrdinal("PackageId"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("Description")))
                obj.Description = rdr.GetString(rdr.GetOrdinal("Description"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("Remarks")))
                obj.Remarks = rdr.GetString(rdr.GetOrdinal("Remarks"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("IsMinSpend")))
                obj.IsMinSpend = rdr.GetBoolean(rdr.GetOrdinal("IsMinSpend"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("MinSpendRate")))
                obj.MinSpendRate = rdr.GetDecimal(rdr.GetOrdinal("MinSpendRate"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("IsPeak")))
                obj.IsPeak = rdr.GetBoolean(rdr.GetOrdinal("IsPeak"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("PeakOpenTime")))
                obj.PeakOpenTime = rdr.GetString(rdr.GetOrdinal("PeakOpenTime"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("PeakCloseTime")))
                obj.PeakCloseTime = rdr.GetString(rdr.GetOrdinal("PeakCloseTime"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("PeakRate")))
                obj.PeakRate = rdr.GetDecimal(rdr.GetOrdinal("PeakRate"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("IsCustomRateTiming")))
                obj.IsCustomRateTiming = rdr.GetBoolean(rdr.GetOrdinal("IsCustomRateTiming"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("CRTOpenTime")))
                obj.CRTOpenTime = rdr.GetString(rdr.GetOrdinal("CRTOpenTime"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("CRTCloseTime")))
                obj.CRTCloseTime = rdr.GetString(rdr.GetOrdinal("CRTCloseTime"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("CRTRate")))
                obj.CRTRate = rdr.GetDecimal(rdr.GetOrdinal("CRTRate"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("Status")))
                obj.Status = rdr.GetBoolean(rdr.GetOrdinal("Status"));


            Room.PopulateAdditionalObjectFromReader(obj, rdr);
        }
        internal static List<Room> PopulateObjectsFromReader(IDataReader rdr)
        {
            List<Room> list = new List<Room>();
            while (rdr.Read())
            {
                Room obj = new Room();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region Public AutoMapper
        // ViewModel -> ADO Model 
        public static Room FixBack(RoomViewModel from)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<RoomViewModel, Room>(); });
            var to = Mapper.Map<RoomViewModel, Room>(from);
            return to;
        }
        // ADO Model -> ViewModel
        public static RoomViewModel FixBack(Room from)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Room, RoomViewModel>(); });
            var to = Mapper.Map<Room, RoomViewModel>(from);
            return to;
        }
        // List<ADO Model> -> List<ViewModel>
        public static List<RoomViewModel> FixBack(List<Room> from)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Room, RoomViewModel>(); });
            var to = Mapper.Map<List<Room>, List<RoomViewModel>>(from);
            return to;
        }
        // List<ADO Model> -> List<ViewModel>
        public static List<Room> FixBack(List<RoomViewModel> from)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<RoomViewModel, Room>(); });
            var to = Mapper.Map<List<RoomViewModel>, List<Room>>(from);
            return to;
        }

        //// ListViewModel -> ADO Model
        //public static Room FixBackList(RoomListViewModel from)
        //{
        //    Mapper.CreateMap<RoomListViewModel, Room>();
        //    var to = Mapper.Map<RoomListViewModel, Room>(from);
        //    return to;
        //}
        //// ADO Model -> ListViewModel
        //public static RoomListViewModel FixBackList(Room from)
        //{
        //    Mapper.CreateMap<Room, RoomListViewModel>();
        //    var to = Mapper.Map<Room, RoomListViewModel>(from);
        //    return to;
        //}
        #endregion
    }
}