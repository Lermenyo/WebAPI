using WebAPI.Domain.Services;
using WebAPI.Service;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;

namespace WebAPI.Service.Application
{
    public class UserAppService
    {
        protected static Logger _logger = LogManager.GetCurrentClassLogger();

        private Object _lock = new Object();
        
        private readonly ServiceUser _serviceUser;

        public UserAppService()
        {
            _serviceUser = new ServiceUser();
        }

        public IEnumerable<User> All()
        {
            return _serviceUser.ObtenerUser();
        }

        public User GetById(int id)
        {
            return _serviceUser.ObtenerUserPorClavePrimaria(id);
        }

        public User Create(User value)
        {
            return _serviceUser.CrearUser(value);
        }

        public int Edit(int id, User value)
        {
            var user = _serviceUser.ObtenerUserPorClavePrimaria(id);
            user.Birthdate = value.Birthdate;
            user.Name = value.Name;
            return _serviceUser.ActualizarUser(user);
        }

        public int Delete(int id)
        {
            //var user = _serviceUser.ObtenerUserPorClavePrimaria(id);
            return _serviceUser.BorrarUser(new User() {
                Id = id
            });
        }
    }
}
