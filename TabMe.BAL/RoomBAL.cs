using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabMe.DAL;
using TabMe.ViewModel;
using TabMe.ViewModel.Enum;

namespace TabMe.BAL
{
    public class RoomBAL
    {
        public static ReturnResult GetAll()
        {
            ReturnResult obj = new ReturnResult();
            obj.ProcessingStatus = ProcessingStatus.Success;
            List<RoomViewModel> objList = new List<RoomViewModel>();
            Room objRoom = new Room();
            objRoom.Page = 0;
            objRoom.PageRecord = 20;
            objList = Room.FixBack(objRoom.SelectAll());
            obj.ReturnObject = objList;
            return obj;
        }
        public static ReturnResult GetById(int id)
        {
            ReturnResult obj = new ReturnResult();
            obj.ProcessingStatus = ProcessingStatus.Success;
            var room = Room.FixBack(Room.GetById(new RoomPrimaryKey(id)));
            obj.ReturnObject = room;
            return obj;
        }
        public static ReturnResult Insert(RoomViewModel item)
        {
            if (item.Id > 0)
                return Update(item.Id, item);
            ReturnResult obj = new ReturnResult();
            var room = Room.FixBack(item);
            var InsertedId = room.InsertUpdate();
            var returnRoom = Room.FixBack(Room.GetById(new RoomPrimaryKey(Convert.ToInt32(InsertedId))));
            obj.ReturnObject = returnRoom;
            return obj;
        }
        public static ReturnResult Update(int id, RoomViewModel item)
        {
            ReturnResult obj = new ReturnResult();
            if (item == null || id <= 0)
            {
                obj.ProcessingStatus = ProcessingStatus.ValidationFailed;
                return obj;
            }
            var room = Room.FixBack(item);
            room.Id = id;
            room.InsertUpdate();
            var updatedroom = Room.FixBack(Room.GetById(new RoomPrimaryKey(Convert.ToInt32(id))));
            obj.ReturnObject = updatedroom;
            return obj;
        }
        public static ReturnResult Delete(int id)
        {
            ReturnResult obj = new ReturnResult();
            obj.ProcessingStatus = ProcessingStatus.Success;
            var room = Room.FixBack(Room.GetById(new RoomPrimaryKey(id)));
            Room.Delete(new RoomPrimaryKey(id));
            obj.ReturnObject = room;
            return obj;
        }
    }
}
