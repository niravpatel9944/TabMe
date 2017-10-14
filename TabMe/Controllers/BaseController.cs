using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TabMe.ViewModel;
using TabMe.ViewModel.Enum;

namespace TabMe.Controllers
{
    public class BaseController : Controller
    {
        public object ProcessRequestResult(ReturnResult returnResult)
        {
            if (returnResult.ProcessingStatus == ProcessingStatus.Success)
                return returnResult.ReturnObject;
            return returnResult;
        }
    }
}