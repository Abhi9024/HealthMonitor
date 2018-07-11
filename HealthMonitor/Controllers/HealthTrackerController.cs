using HealthMonitor.Common.Model;
using HealthMonitor.DAC;
using HealthMonitor.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthMonitor.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/HealthTracker")]
    public class HealthTrackerController : Controller
    {
        private IDataProvider _dataProvider;
        private ILogger<HealthTrackerController> _logger;
        private SignInManager<UserCredential> _signInMgr;

        public HealthTrackerController(IDataProvider dataProvider,ILogger<HealthTrackerController> logger,SignInManager<UserCredential> signInManager)
        {
            _dataProvider = dataProvider;
            _logger = logger;
            _signInMgr = signInManager;
        }

        // GET: api/HealthTracker/Users
        [HttpGet]
        [Route("Users")]
        public List<User> GetUsers()
        {
            var users = new List<User>();
            try
            {
                users = _dataProvider.GetAllUsers();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(1000, ex.ToString());
            }
            return users;
        }

        // GET: api/HealthTracker/5
        [HttpGet]
        [Route("User")]
        public User Get(string name)
        {
            var user = new User();
            try
            {
                user = _dataProvider.GetUser(name);
            }
            catch (Exception ex)
            {
                _logger.LogError(1000, ex.ToString());
            }
            return user;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Auth")]
        public async Task AuthenticateUser([FromBody] UserAuthModel user)
        {
            var result = await _signInMgr.PasswordSignInAsync(user.UserName, user.Password, false, false);
            var status = result.Succeeded;
        }
        
        // POST: api/HealthTracker
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/HealthTracker/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
