using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabMe.ViewModel.Enum
{
    public enum ProcessingStatus
    {
        Success = 10,
        Warning = 11,
        Error = 12,
        ValidationFailed = 13,
        BadRequest = 31
    }
    public enum RoomType
    {
        Normal = 1,
        Luxury = 2,
        Platinum = 3
    }
    public enum Entity
    {
        Room = 1
    }


    #region Temp Enums
    public enum Package
    {
        Package1 = 1,
        Package2 = 2,
        Package3 = 3
    }
    public enum Country
    {
        USA = 1,
        India = 2
    }
    public enum State
    {
        Alaska = 1,
        California = 2,
        Florida = 3,
        Gujarat = 4,
        Delhi = 5
    }
    #endregion
}
