using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLog;
using WebAPI.Service.Application;
using WebAPI.Domain.Entities;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Swashbuckle.Swagger.Annotations;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        protected static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly UserAppService _userAppService;

        public UserController() {
            _userAppService = new UserAppService();
        }

        [HttpGet]
        [Route("User/Get")]
        public IEnumerable<User> Get()
        {
            try
            {
                _logger.Trace("User/Get");

                return _userAppService.All();
            }
            catch (Exception ex)
            {
                _logger.Error(ex,"ERROR: User/Get");
                throw;
            }
        }

        [HttpGet]
        [Route("User/Get")]
        public User Get(int id)
        {
            try
            {
                _logger.Trace("User/Get - {0}", id);
                return _userAppService.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex,String.Format("ERROR: User/Get id: {0}", id));
                throw;
            }
        }

        [HttpPost]
        [Route("User/Post")]
        public User Post([FromBody]User user)
        {
            try
            {
                if (_logger.IsTraceEnabled)
                _logger.Trace("User/Post - {0}", JsonConvert.SerializeObject(user));

                return _userAppService.Create(user);
            }
            catch (Exception ex)
            {
                _logger.Error(ex,String.Format("ERROR: User/Post user: {0}", JsonConvert.SerializeObject(user)));
                throw;
            }
        }

        [HttpPut]
        [Route("User/Put")]
        public int Put(int id, [FromBody]User user)
        {
            try
            {
                if (_logger.IsTraceEnabled)
                    _logger.Trace("User/Put - {0}", JsonConvert.SerializeObject(user));

                return _userAppService.Edit(id, user);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, String.Format("ERROR: User/Put id:{0} user: {1}", id , JsonConvert.SerializeObject(user)));
                throw;
            }
        }

        [HttpDelete]
        [Route("User/Delete")]
        public int Delete(int id)
        {
            try
            {
                return _userAppService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, String.Format("ERROR: User/Delete id: {0}", id));
                throw;
            }
        }
    }
}
