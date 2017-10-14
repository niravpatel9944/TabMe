using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabMe.ViewModel.Enum;

namespace TabMe.ViewModel
{
	public class AddressViewModel
    {
		[DisplayName("AddressId")]
		public long AddressId { get; set; }
		[DisplayName("EntityType")]
		public int EntityType { get; set; }
        [DisplayName("EntityId")]
        public int EntityId { get; set; }
        [DisplayName("FlatNo")]
		public string FlatNo { get; set; }
		[DisplayName("BuildingName")]
		public string BuildingName { get; set; }
		[DisplayName("StreetName")]
		public string StreetName { get; set; }
		[DisplayName("Landmark")]
		public string Landmark { get; set; }
		[DisplayName("CountryId")]
		public int CountryId { get; set; }
		[DisplayName("StateId")]
		public int StateId { get; set; }
		[DisplayName("City")]
		public string City { get; set; }
		[DisplayName("Zipcode")]
		public string Zipcode { get; set; }

        [JsonIgnore]
        public Country Country
        {
            get
            {
                return (Country)this.CountryId;
            }
            set
            {
                this.CountryId = (short)value;
            }
        }
        [JsonIgnore]
        public State State
        {
            get
            {
                return (State)this.StateId;
            }
            set
            {
                this.StateId = (short)value;
            }
        }
        [JsonIgnore]
        public Entity Entity
        {
            get
            {
                return (Entity)this.EntityType;
            }
            set
            {
                this.EntityType = (short)value;
            }
        }
    }
	public class AddressListViewModel
    {
        public List<AddressViewModel> ListAddress { get; set; }

        public int Page { get; set; }
        public int PageRecord { get; set; }
        public string SortByColumn { get; set; }
        public string Orderby { get; set; }
    }

}