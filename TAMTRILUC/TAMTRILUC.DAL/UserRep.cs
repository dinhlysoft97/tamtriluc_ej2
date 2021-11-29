using TAMTRILUC.A00.DAL;

namespace TAMTRILUC.DAL
{
    using Models;
    using System;
    using System.Linq;
    using TAMTRILUC.A00.Rsp;

    public class UserRep : GenericRep<TAMTRILUCContext, User>
    {
        public override User Read(string id)
        {
            var res = All.FirstOrDefault(p => p.UserId == id);
            return res;
        }

        public SingleRsp DeleteUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new TAMTRILUCContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var data = context.Users.Remove(user);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.Message);
                    }
                }
            }

            var resData = new
            {
                Data = user,
            };

            res.Data = resData;

            return res;
        }

        public SingleRsp CreateUser(User user)
        {
            var res = new SingleRsp();
            using(var context = new TAMTRILUCContext())
            {
                using(var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var data = context.Users.Add(user);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.Message);
                    }
                }
            }

            var resData = new
            {
                Data = user,
            };

            res.Data = resData;

            return res;
        }

        public SingleRsp UpdateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new TAMTRILUCContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var data = context.Users.Update(user);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.Message);
                    }
                }
            }

            var resData = new
            {
                Data = user,
            };

            res.Data = resData;

            return res;
        }

    }
}
