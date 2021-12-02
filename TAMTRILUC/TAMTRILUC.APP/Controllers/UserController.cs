using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace TAMTRILUC.APP.Controllers
{
    using A00.Req;
    using A00.Rsp;
    using BLL;
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Linq;
    using TAMTRILUC.DAL.Models;

    //[Route("api/[controller]")]
    //[ApiController]
    public class UserController : Controller
    {
        private readonly UserSvc _svc;

        public UserController()
        {
            _svc = new UserSvc();
        }

        public IActionResult SearchUser([FromBody] DataManagerRequest dm)
        {
            IEnumerable DataSource = _svc.SearchUser(string.Empty, 0, 0);
            DataOperations operation = new DataOperations();
            int count = DataSource.Cast<User>().Count();
            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);   //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);
        }

        public ActionResult InsertUser([FromBody] CRUDModel<UserReq> value)
        {
            var res = _svc.InsertUSer(value.Value);
            return Json(value.Value);
        }

        public ActionResult UpdateUser([FromBody] CRUDModel<UserReq> value)
        {
            var res = _svc.UpdateUser(value.Value);
            return Json(value.Value);
        }

        public ActionResult DeleteUser([FromBody] CRUDModel<UserReq> value)
        {
            var res = _svc.DeleteUser(value.Key.ToString());
            return Json(value);
        }


        //[HttpPost("get-by-id")]
        //public IActionResult GetUserById([FromBody] SimpleReq req)
        //{
        //    var res = new SingleRsp();
        //    res = _svc.Read(req.Id);
        //    return Ok(res);
        //}

        //[HttpPost("search-user")]
        //public IActionResult SearchUser([FromBody] UserReq userReq)
        //{
        //    var res = new SingleRsp();
        //    //res.Data = _svc.SearchUser(userReq.Key, userReq.PageSize, userReq.PageNumber);
        //    object data = _svc.SearchUser(userReq.Key, userReq.PageSize, userReq.PageNumber);
        //    return Ok(data);
        //}

        //[HttpPost("delete-user")]
        //public IActionResult DeleteUser([FromBody] UserReq req)
        //{
        //    var res = _svc.DeleteUser(req);
        //    return Ok(res);
        //}

        //[HttpPost("insert-user")]
        //public IActionResult InsertUser([FromBody] UserReq userReq)
        //{
        //    var res = _svc.InsertUSer(userReq);
        //    return Ok(res);
        //}

        //[HttpPost("update-user")]
        //public IActionResult UpdateUser([FromBody] UserReq userReq)
        //{
        //    var res = _svc.UpdateUser(userReq);
        //    return Ok(res);
        //}
    }
}
