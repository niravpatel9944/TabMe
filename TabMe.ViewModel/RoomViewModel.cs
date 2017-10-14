using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TabMe.ViewModel.Enum;

namespace TabMe.ViewModel
{
    public class RoomViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Room Type")]
        public short RoomTypeId { get; set; }
        [DisplayName("Code")]
        public string Code { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Capacity")]
        public short Capacity { get; set; }
        [DisplayName("Rate")]
        public decimal Rate { get; set; }
        [DisplayName("Package")]
        public int PackageId { get; set; }
        [AllowHtml]
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Remarks")]
        public string Remarks { get; set; }
        [DisplayName("IsMinSpend")]
        public bool IsMinSpend { get; set; }
        [DisplayName("MinSpend Rate")]
        public decimal MinSpendRate { get; set; }
        [DisplayName("IsPeak")]
        public bool IsPeak { get; set; }
        [DisplayName("Open Time")]
        public string PeakOpenTime { get; set; }
        [DisplayName("Close Time")]
        public string PeakCloseTime { get; set; }
        [DisplayName("Peak Rate")]
        public decimal PeakRate { get; set; }
        [DisplayName("IsCustomRateTiming")]
        public bool IsCustomRateTiming { get; set; }
        [DisplayName("Open Time")]
        public string CRTOpenTime { get; set; }
        [DisplayName("Close Time")]
        public string CRTCloseTime { get; set; }
        [DisplayName("Custom Rate Timing Rate")]
        public decimal CRTRate { get; set; }
        [DisplayName("Status")]
        public bool Status { get; set; }

        [JsonIgnore]
        public RoomType RoomType
        {
            get
            {
                return (RoomType)this.RoomTypeId;
            }
            set
            {
                this.RoomTypeId = (short)value;
            }
        }
        [JsonIgnore]
        public Package Package
        {
            get
            {
                return (Package)this.PackageId;
            }
            set
            {
                this.PackageId = (short)value;
            }
        }
        [JsonIgnore]
        [DisplayName("PictureIds")]
        public string PictureIds { get; set; }
    }
    public class RoomListViewModel
    {
        public List<RoomViewModel> ListRoom { get; set; }

        public int Page { get; set; }
        public int PageRecord { get; set; }
        public string SortByColumn { get; set; }
        public string Orderby { get; set; }
    }
    public class RoomModel
    {
        public RoomViewModel Room { get; set; }
        //public AddressViewModel Address { get; set; }
        public PictureViewModel Picture { get; set; }
    }
}