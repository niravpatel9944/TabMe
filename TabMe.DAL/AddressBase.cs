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
    public class AddressBase
    {
        #region Class Level Variables

        private DatabaseHelper oDatabaseHelper = new DatabaseHelper();
        private long? _AddressId = null;
        private int? _EntityType = null;
        private int? _EntityId = null;
        private string _FlatNo = null;
        private string _BuildingName = null;
        private string _StreetName = null;
        private string _Landmark = null;
        private int? _CountryId = null;
        private int? _StateId = null;
        private string _City = null;
        private string _Zipcode = null;

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
        public AddressBase() { }

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
        public string FlatNo
        {
            get
            {
                return _FlatNo;
            }
            set
            {
                _FlatNo = value;
            }
        }
        public string BuildingName
        {
            get
            {
                return _BuildingName;
            }
            set
            {
                _BuildingName = value;
            }
        }
        public string StreetName
        {
            get
            {
                return _StreetName;
            }
            set
            {
                _StreetName = value;
            }
        }
        public string Landmark
        {
            get
            {
                return _Landmark;
            }
            set
            {
                _Landmark = value;
            }
        }
        public int? CountryId
        {
            get
            {
                return _CountryId;
            }
            set
            {
                _CountryId = value;
            }
        }
        public int? StateId
        {
            get
            {
                return _StateId;
            }
            set
            {
                _StateId = value;
            }
        }
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }
        public string Zipcode
        {
            get
            {
                return _Zipcode;
            }
            set
            {
                _Zipcode = value;
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
            oDatabaseHelper.AddParameter("@AddressId", _AddressId);
            oDatabaseHelper.AddParameter("@EntityType", _EntityType);
            oDatabaseHelper.AddParameter("@EntityId", _EntityId);
            oDatabaseHelper.AddParameter("@FlatNo", _FlatNo);
            oDatabaseHelper.AddParameter("@BuildingName", _BuildingName);
            oDatabaseHelper.AddParameter("@StreetName", _StreetName);
            oDatabaseHelper.AddParameter("@Landmark", _Landmark);
            oDatabaseHelper.AddParameter("@CountryId", _CountryId);
            oDatabaseHelper.AddParameter("@StateId", _StateId);
            oDatabaseHelper.AddParameter("@City", _City);
            oDatabaseHelper.AddParameter("@Zipcode", _Zipcode);

            var Result = oDatabaseHelper.ExecuteScalar("Address_InsertUpdate", ref ExecutionState);
            oDatabaseHelper.Dispose();

            return Result;
        }
        public List<Address> SelectAllBase(System.Collections.Specialized.NameValueCollection nvc)
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

            IDataReader dr = oDatabaseHelper.ExecuteReader("Address_SelectAll", ref ExecutionState);

            return PopulateObjectsFromReader(dr);
        }
        public static Address GetById(AddressPrimaryKey pk)
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

            IDataReader dr = oDatabaseHelper.ExecuteReader("Address_GetById", ref ExecutionState);

            if (dr.Read())
            {
                Address obj = new Address();
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
        public static Address GetByEntityType_Id(int EntityType, int EntityId)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            
            oDatabaseHelper.AddParameter("@EntityType", EntityType);
            oDatabaseHelper.AddParameter("@EntityId", EntityId);

            IDataReader dr = oDatabaseHelper.ExecuteReader("Address_GetByEntityType_Id", ref ExecutionState);

            if (dr.Read())
            {
                Address obj = new Address();
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

            oDatabaseHelper.AddParameter("@AddressId", _AddressId);
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
            oDatabaseHelper.ExecuteScalar("Address_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
            return ExecutionState;
        }
        public static bool Delete(AddressPrimaryKey pk)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            oDatabaseHelper.ExecuteScalar("Address_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
            return ExecutionState;

        }
        #endregion

        #region Methods (Private)
        internal static void PopulateObjectFromReader(Address obj, IDataReader rdr)
        {
            if (!rdr.IsDBNull(rdr.GetOrdinal("AddressId")))
                obj.AddressId = rdr.GetInt64(rdr.GetOrdinal("AddressId"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("EntityType")))
                obj.EntityType = rdr.GetInt32(rdr.GetOrdinal("EntityType"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("EntityId")))
                obj.EntityId = rdr.GetInt32(rdr.GetOrdinal("EntityId"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("FlatNo")))
                obj.FlatNo = rdr.GetString(rdr.GetOrdinal("FlatNo"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("BuildingName")))
                obj.BuildingName = rdr.GetString(rdr.GetOrdinal("BuildingName"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("StreetName")))
                obj.StreetName = rdr.GetString(rdr.GetOrdinal("StreetName"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("Landmark")))
                obj.Landmark = rdr.GetString(rdr.GetOrdinal("Landmark"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("CountryId")))
                obj.CountryId = rdr.GetInt32(rdr.GetOrdinal("CountryId"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("StateId")))
                obj.StateId = rdr.GetInt32(rdr.GetOrdinal("StateId"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("City")))
                obj.City = rdr.GetString(rdr.GetOrdinal("City"));
            if (!rdr.IsDBNull(rdr.GetOrdinal("Zipcode")))
                obj.Zipcode = rdr.GetString(rdr.GetOrdinal("Zipcode"));


            Address.PopulateAdditionalObjectFromReader(obj, rdr);
        }
        internal static List<Address> PopulateObjectsFromReader(IDataReader rdr)
        {
            List<Address> list = new List<Address>();
            while (rdr.Read())
            {
                Address obj = new Address();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region Public AutoMapper
        // ViewModel -> ADO Model 
        public static Address FixBack(AddressViewModel from)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<AddressViewModel, Address>(); });
            var to = Mapper.Map<AddressViewModel, Address>(from);
            return to;
        }
        // ADO Model -> ViewModel
        public static AddressViewModel FixBack(Address from)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Address, AddressViewModel>(); });
            var to = Mapper.Map<Address, AddressViewModel>(from);
            return to;
        }
        // List<ADO Model> -> List<ViewModel>
        public static List<AddressViewModel> FixBack(List<Address> from)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Address, AddressViewModel>(); });
            var to = Mapper.Map<List<Address>, List<AddressViewModel>>(from);
            return to;
        }
        // List<ADO Model> -> List<ViewModel>
        public static List<Address> FixBack(List<AddressViewModel> from)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<AddressViewModel, Address>(); });
            var to = Mapper.Map<List<AddressViewModel>, List<Address>>(from);
            return to;
        }

        //// ListViewModel -> ADO Model
        //public static Address FixBackList(AddressListViewModel from)
        //{
        //    Mapper.CreateMap<AddressListViewModel, Address>();
        //    var to = Mapper.Map<AddressListViewModel, Address>(from);
        //    return to;
        //}
        //// ADO Model -> ListViewModel
        //public static AddressListViewModel FixBackList(Address from)
        //{
        //    Mapper.CreateMap<Address, AddressListViewModel>();
        //    var to = Mapper.Map<Address, AddressListViewModel>(from);
        //    return to;
        //}
        #endregion
    }
}