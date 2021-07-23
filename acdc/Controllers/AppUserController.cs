using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ACDC.Models;
using ACDC.Class;
using ACDC.Models.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace ACDC.Controllers
{
    public class AppUserController : Controller
    {
        private readonly ApplicationUser _app;
        APIClass api = new APIClass();

        public AppUserController(ApplicationUser app)
        {
            _app = app;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserAccount user1)
        {
            var _msg = string.Empty;
            bool _isSuccess = false;
            int _resCode = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    var res = api.InsertUser(user1);
                    var retval = JsonConvert.DeserializeObject<Response<DataTable>>(res);
                    var result = retval.data.Rows[0]["Result"].ToString();
                    var msg = retval.data.Rows[0]["Message"].ToString();

                    if (result.Equals("10"))
                    {
                        _msg =  msg ;
                        _isSuccess = true;
                        _resCode =  1;
                    }
                    else
                    {
                        _msg = msg;
                        _isSuccess = false;
                        _resCode = 0;
                    }
                }
            }
            catch (Exception ee)
            {
                _msg = ee.Message;
                _isSuccess = false;
                _resCode = 500;
            }
            return Json(new { msg = _msg, isSuccess = _isSuccess, resCode = _resCode });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginCredential(Login acct)
        {
            var _msg = string.Empty;
            bool _isSuccess = false;
            int _resCode = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    var res = api.AccountCredential(acct);
                    var retval = JsonConvert.DeserializeObject<Response<DataTable>>(res);
                }
            }
            catch (Exception ee)
            {
                _msg = ee.Message;
                _isSuccess = false;
                _resCode = 500;
            }
            return Json(new { msg = _msg, isSuccess = _isSuccess, resCode = _resCode });
        }
    }
}
