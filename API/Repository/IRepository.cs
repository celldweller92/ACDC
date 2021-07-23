using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.API
{
    public interface IRepository
    {
        Task<Response<dynamic>> InsertUser(Account1 account);
        Task<List<Account1>> SelectUser(string sid);
        Task<Response<dynamic>> DeleteUser(string sid);
        Task<Response<dynamic>> UpdateUser(string sid, Account1 account);
        Task<List<Account1>> ShowUser();
        Task<Response<dynamic>> LoginCredential(Login log);
    }
}
