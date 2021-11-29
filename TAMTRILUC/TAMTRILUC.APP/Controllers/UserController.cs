using Microsoft.AspNetCore.Mvc;

namespace TAMTRILUC.APP.Controllers
{
    using A00.Req;
    using A00.Rsp;
    using BLL;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserSvc _svc;

        public UserController()
        {
            _svc = new UserSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult GetUserById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("search-user")]
        public IActionResult SearchUser([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res.Data = _svc.SearchUser(userReq.Key, userReq.PageSize, userReq.PageNumber);
            return Ok(res);
        }

        [HttpPost("delete-user")]
        public IActionResult DeleteUser([FromBody] UserReq req)
        {
            var res = _svc.DeleteUser(req);
            return Ok(res);
        }

        [HttpPost("insert-user")]
        public IActionResult InsertUser([FromBody] UserReq userReq)
        {
            var res = _svc.InsertUSer(userReq);
            return Ok(res);
        }

        [HttpPost("update-user")]
        public IActionResult UpdateUser([FromBody] UserReq userReq)
        {
            var res = _svc.UpdateUser(userReq);
            return Ok(res);
        }
    }
}
