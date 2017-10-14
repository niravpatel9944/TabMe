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
    public class AddressBAL
    {
        public static ReturnResult GetAll()
        {
            ReturnResult obj = new ReturnResult();
            obj.ProcessingStatus = ProcessingStatus.Success;
            List<AddressViewModel> objList = new List<AddressViewModel>();
            Address objAddress = new Address();
            objAddress.Page = 0;
            objAddress.PageRecord = 2;
            objList = Address.FixBack(objAddress.SelectAll());
            obj.ReturnObject = objList;
            return obj;
        }
        public static ReturnResult GetById(int id)
        {
            ReturnResult obj = new ReturnResult();
            obj.ProcessingStatus = ProcessingStatus.Success;
            var address = Address.FixBack(Address.GetById(new AddressPrimaryKey(id)));
            obj.ReturnObject = address;
            return obj;
        }
        public static ReturnResult Insert(AddressViewModel item)
        {
            if (item.AddressId > 0)
                return Update(item.AddressId, item);
            ReturnResult obj = new ReturnResult();
            var address = Address.FixBack(item);
            var InsertedId = address.InsertUpdate();
            var returnAddress = Address.FixBack(Address.GetById(new AddressPrimaryKey(Convert.ToInt32(InsertedId))));
            obj.ReturnObject = returnAddress;
            return obj;
        }
        public static ReturnResult Update(long id, AddressViewModel item)
        {
            ReturnResult obj = new ReturnResult();
            if (item == null || id <= 0)
            {
                obj.ProcessingStatus = ProcessingStatus.ValidationFailed;
                return obj;
            }
            var address = Address.FixBack(item);
            address.AddressId = id;
            address.InsertUpdate();
            var updatedaddress = Address.FixBack(Address.GetById(new AddressPrimaryKey(Convert.ToInt32(id))));
            obj.ReturnObject = updatedaddress;
            return obj;
        }
        public static ReturnResult Delete(int id)
        {
            ReturnResult obj = new ReturnResult();
            obj.ProcessingStatus = ProcessingStatus.Success;
            var address = Address.FixBack(Address.GetById(new AddressPrimaryKey(id)));
            Address.Delete(new AddressPrimaryKey(id));
            obj.ReturnObject = address;
            return obj;
        }
    }
}
