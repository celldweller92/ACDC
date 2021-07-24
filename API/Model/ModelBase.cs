using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using AutoMapper;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Repository.API;

namespace API.Model
{
    public class ModelBase : IRepository
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private SqlConnection _connection;
        public ModelBase(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
            _connection = new SqlConnection(_configuration["ConnectionStrings:DataConnection"]);
        }

        #region Create User Account
        public async Task<Response<dynamic>> InsertUser(Account1 account)
        {
            var res = new Response<dynamic>();

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("type", "Create");
                var objects = account.GetType().GetProperties();

                foreach(var item in objects)
                {
                    var name = item.Name;
                    var value = item.GetValue(account);
                    param.Add(name, value);
                }
                var response = await _connection.QueryAsync<ResponseLog>("InsertUser", param, commandType: CommandType.StoredProcedure);
                var gets = response.ToList();
                   
                if (gets[0].Result.ToString().Equals("10"))
                {
                    res.message = "Successfully Created!";
                    res.Code = 200;
                    res.Data = response;
                }
                else
                {
                    res.message = "Failed to Create User";
                    res.Code = 101;
                    res.Data = response;
                }
            }
            catch (SqlException sql)
            {
                res.Code = 501;
                res.message = "SqlException Error!";
                res.Data = sql.Message;
            }
            catch (Exception error)
            {
                res.Code = 500;
                res.message = "Exception Error!";
                res.Data = error.Message;
            }
            return res;
        }
        #endregion

        #region Update User Account
        public async Task<Response<dynamic>> UpdateUser(string sid, Account1 account)
        {
            var res = new Response<dynamic>();

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("sid", sid);
                param.Add("type", "Update");
                var obj = account.GetType().GetProperties();

                foreach (var item in obj)
                {
                    var name = item.Name;
                    var value = item.GetValue(account);
                    param.Add(name, value);
                }
                var response = await _connection.QueryAsync("InsertUser", param, commandType: CommandType.StoredProcedure);
                res.Data = response;
                res.message = "Successfully Updated!";
                res.Code = 200;
            }
            catch (SqlException sql)
            {
                res.Code = 501;
                res.Data = sql.Data;
                res.message = "SqlException Error!";
            }
            catch (Exception ex)
            {
                res.Code = 500;
                res.Data = ex.Data;
                res.message = "Exception Error!";
            }
            return res;
        }
        #endregion

        #region Delete User Account
        public async Task<Response<dynamic>> DeleteUser(string id)
        {
            var res = new Response<dynamic>();

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("sid", id);
                param.Add("type", "Delete");
                var response = await _connection.QueryAsync("InsertUser", param, commandType:CommandType.StoredProcedure);
                res.Code = 200;
                res.Data = response;
                res.message = "Successfully Deleted!";
            }
            catch(SqlException sql)
            {
                res.Code = 501;
                res.Data = sql.Data;
                res.message = "SqlException Error!";
            }
            catch (Exception ex)
            {
                res.Code = 500;
                res.Data = ex.Data;
                res.message = "Exception Error!";
            }
            return res;
        }
        #endregion

        #region Select User Account
        public async Task<List<Account1>> SelectUser(string id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@id", id);
                var ss = _connection.Query<Account>("InsertUser", param, commandType: CommandType.StoredProcedure).ToList();
                var acct = await Task.Run(() => _mapper.Map<List<Account1>>(ss).ToList());
                return acct;
            }
            catch (Exception)
            {
                return new List<Account1>();
            }
        }
        #endregion

        #region Select All User
        public async Task<List<Account1>> ShowUser()
        {
            try
            {
                var show = _connection.Query<Account>("InsertUser", commandType: CommandType.StoredProcedure).ToList();
                var acct = await Task.Run(() => _mapper.Map<List<Account1>>(show).ToList());
                return acct;
            }
            catch (Exception)
            {
                return new List<Account1>();
            }
        }
        #endregion

        #region Login Credential 
        public async Task<Response<dynamic>> LoginCredential(Login log)
        {
            var res = new Response<dynamic>();

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("type", "Login");
                var obj = log.GetType().GetProperties();

                foreach (var item in obj)
                {
                    var name = item.Name;
                    var value = item.GetValue(log);
                    param.Add(name, value);
                }
                var response = await _connection.QueryAsync<ResponseLog>("InsertUser", param, commandType: CommandType.StoredProcedure);
                var queryList = response.ToList();

                if (queryList[0].Result.ToString().Equals("10"))
                {
                    res.Code = 200;
                    res.Data = response;
                    res.message = "Successfully Login";
                }
                else
                {
                    res.Code = 200;
                    res.Data = response;
                    res.message = "Failed to Login";
                }
            }
            catch(SqlException sql)
            {
                res.Code = 501;
                res.message = "SqlException Error!";
                res.Data = sql.Message;
            }
            catch (Exception ex)
            {   
                res.Code = 500;
                res.message = "Exception Error!";
                res.Data = ex.Message;
            }
            return res;
        }
        #endregion
    }
}
