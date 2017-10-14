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
    public class PictureBAL
    {
        public static ReturnResult GetAll()
        {
            ReturnResult obj = new ReturnResult();
            obj.ProcessingStatus = ProcessingStatus.Success;
            List<PictureViewModel> objList = new List<PictureViewModel>();
            Picture objPicture = new Picture();
            objPicture.Page = 0;
            objPicture.PageRecord = 2;
            objList = Picture.FixBack(objPicture.SelectAll());
            obj.ReturnObject = objList;
            return obj;
        }
        public static ReturnResult GetById(int id)
        {
            ReturnResult obj = new ReturnResult();
            obj.ProcessingStatus = ProcessingStatus.Success;
            var skill = Picture.FixBack(Picture.GetById(new PicturePrimaryKey(id)));
            obj.ReturnObject = skill;
            return obj;
        }
        public static ReturnResult Insert(PictureViewModel item)
        {
            if (item.Id > 0)
                return Update(item.Id, item);
            ReturnResult obj = new ReturnResult();
            var skill = Picture.FixBack(item);
            var InsertedId = skill.InsertUpdate();
            var returnPicture = Picture.FixBack(Picture.GetById(new PicturePrimaryKey(Convert.ToInt32(InsertedId))));
            obj.ReturnObject = returnPicture;
            return obj;
        }
        public static ReturnResult Update(long id, PictureViewModel item)
        {
            ReturnResult obj = new ReturnResult();
            if (item == null || id <= 0)
            {
                obj.ProcessingStatus = ProcessingStatus.ValidationFailed;
                return obj;
            }
            var skill = Picture.FixBack(item);
            skill.Id = id;
            skill.InsertUpdate();
            var updatedSkill = Picture.FixBack(Picture.GetById(new PicturePrimaryKey(Convert.ToInt32(id))));
            obj.ReturnObject = updatedSkill;
            return obj;
        }
        public static ReturnResult Delete(int id)
        {
            ReturnResult obj = new ReturnResult();
            obj.ProcessingStatus = ProcessingStatus.Success;
            var skill = Picture.FixBack(Picture.GetById(new PicturePrimaryKey(id)));
            Picture.Delete(new PicturePrimaryKey(id));
            obj.ReturnObject = skill;
            return obj;
        }
    }
}
