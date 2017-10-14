using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabMe.ViewModel.Enum;

namespace TabMe.ViewModel
{
    public class ReturnResult
    {
        public object ReturnObject { get; set; }
        public int ProcessingStatusId { get; set; }
        public string ProcessingError { get; set; }
        [JsonIgnore]
        public ProcessingStatus ProcessingStatus
        {
            get
            {
                return (ProcessingStatus)this.ProcessingStatusId;
            }
            set
            {
                this.ProcessingStatusId = (int)value;
            }
        }
    }
}
