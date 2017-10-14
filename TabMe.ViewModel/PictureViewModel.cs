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
	public class PictureViewModel
    {
		[DisplayName("Id")]
		public long Id { get; set; }
		[DisplayName("EntityType")]
		public int EntityType { get; set; }
        [DisplayName("EntityId")]
        public int EntityId { get; set; }
        [DisplayName("File Name")]
		public string FileExtension { get; set; }
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
	public class PictureListViewModel
    {
        public List<PictureViewModel> ListPicture { get; set; }

        public int Page { get; set; }
        public int PageRecord { get; set; }
        public string SortByColumn { get; set; }
        public string Orderby { get; set; }
    }

}