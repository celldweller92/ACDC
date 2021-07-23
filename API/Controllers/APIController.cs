using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class APIController : ControllerBase
    {
        private readonly IAdapterInterface _repost;
        public APIController(IAdapterInterface repost)
        {
            _repost = repost;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> Create(Account1 account)
        {
            var res = await _repost.repos.InsertUser(account);
            return Ok(res);
        }

        [HttpGet("SelectUser")]
        public async Task<IActionResult> Select(string sid)
        {
            var acct = await _repost.repos.SelectUser(sid);
            return Ok(acct);
        }
  
        [HttpGet("DeleteUser")]
        public async Task<IActionResult> Delete(string sid)
        {  
            var res = await _repost.repos.DeleteUser(sid);
            return Ok(res);
        }

        [HttpGet("UpdateUser")]
        public async Task<IActionResult> Update(string sid, Account1 account)
        {
            var res = await _repost.repos.UpdateUser(sid, account);
            return Ok(res);
        }

        [HttpGet("SelectAll")]
        public async Task<IActionResult> ShowUser()
        {
            var res = await _repost.repos.ShowUser();
            return Ok(res);
        }

        [HttpPost("UserCredential")]
        public async Task<IActionResult> Credential(Login log)
        {
            var res = await _repost.repos.LoginCredential(log);
            return Ok(res);
        }
    }
}
