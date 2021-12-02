using System;
using TAMTRILUC.A00.BLL;
using TAMTRILUC.A00.Req;
using TAMTRILUC.A00.Rsp;
using TAMTRILUC.DAL;
using TAMTRILUC.DAL.Models;
using System.Linq;
using System.Collections.Generic;

namespace TAMTRILUC.BLL
{
    public class UserSvc : GenericSvc<UserRep, User>
    {
        public override SingleRsp Read(string id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public List<User> SearchUser(string key, int pageSize, int pageNumber)
        {
            var users = All.Where(x => x.UserId.Contains(key) || x.UserName.Contains(key)).OrderByDescending(x=>x.UserId);

            //var offset = (pageNumber - 1) * pageSize;

            //var totalUser = users.Count();

            //var totalPages = (totalUser % pageSize) == 0 ? (int)(totalUser / pageSize) : (int)(totalUser / pageSize) + 1;

            //var data = users.Skip(offset).Take(pageSize).ToList();

            var res = new
            {
                Data = users.ToList(),
                //Data = data,
                //PageSize = pageSize,
                //PageNumber = pageNumber,
                //TotalRecord = totalUser,
                //TotalPages = totalPages,
            };

            return users.ToList();
        }

        public SingleRsp InsertUSer(UserReq userReq)
        {
            User user = new User()
            {
                Apk = Guid.NewGuid(),
                UserId = userReq.UserId,
                UserName = userReq.UserName,
                Gender = userReq.Gender,
                Address = userReq.Address,
                Phone = userReq.Phone,
                Age = userReq.Age,
                Disabled = 0,
                CreateDate = DateTime.Now,
                CreateUserId = "Admin",
            };

            return _rep.CreateUser(user);
        }

        public SingleRsp UpdateUser(UserReq userReq)
        {
            User user = new User()
            {
                Apk = Guid.NewGuid(),
                UserId = userReq.UserId,
                UserName = userReq.UserName,
                Gender = userReq.Gender,
                Address = userReq.Address,
                Phone = userReq.Phone,
                Age = userReq.Age,
                Disabled = 0,
                CreateDate = DateTime.Now,
                CreateUserId = "Admin",
            };

            return _rep.UpdateUser(user);
        }

        public SingleRsp DeleteUser(string userId)
        {
            return _rep.DeleteUser(userId);
        }
    }
}
