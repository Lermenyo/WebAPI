
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using WebAPI.Bd.Repositories;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Mapper;

namespace WebAPI.Domain.Services.Base
{
    public abstract class ServiceUserBase
	{
		protected readonly IRepositoryUser _RepositoryUser;

		/// <summary>
        /// Constructor de la clase User 
        /// </summary>
		public ServiceUserBase()
		{
			_RepositoryUser = new RepositoryUser(new WebAPI.Bd.Model.WebAPIContext());
		}

		/// <summary>
        /// Metodo para obtener todos los User 
        /// </summary>
        /// <returns>IQueryable con todos los User</returns>
		public IEnumerable<Entities.User> ObtenerUser()
		{
			return _RepositoryUser.GetUser().ToList().Select(x=>MapperUser.MapTo(x));
		}

		/// <summary>
        /// Metodo para obtener todos los User asincronamente
        /// </summary>
        /// <returns>IQueryable con todos los User</returns>
		public async Task<IEnumerable<Entities.User>> ObtenerUserAsync()
		{
			return (await _RepositoryUser.GetUser().ToListAsync()).Select(x=>MapperUser.MapTo(x));
		}

        
        /// <summary>
        /// Obtener un User por su clave primaria
        /// </summary>
		/// <param name="id">Id</param>
        /// <returns>User  seleccionado por su clave primaria</returns>
		public async Task<Entities.User> ObtenerUserPorClavePrimariaAsync(int id)
		{
			return MapperUser.MapTo(await _RepositoryUser.GetUserByPrimaryKeyAsync(id));
		}

        /// <summary>
        /// Obtener un User por su clave primaria
        /// </summary>
		/// <param name="id">Id</param>
        /// <returns>User  seleccionado por su clave primaria</returns>
		public Entities.User ObtenerUserPorClavePrimaria(int id)
		{
			return MapperUser.MapTo(_RepositoryUser.GetUserByPrimaryKey(id));
		}

		/// <summary>
        /// Crea una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a crear</param>
        /// <returns>User creado</returns>
		public virtual async Task<Entities.User> CrearUserAsync(Entities.User source)
		{
			return MapperUser.MapToRelated(await _RepositoryUser.CreateUserAsync(MapperUser.MapTo(source)));
		}

		/// <summary>
        /// Crea una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a crear</param>
        /// <returns>User creado</returns>
		public virtual Entities.User CrearUser(Entities.User source)
		{
			return MapperUser.MapToRelated(_RepositoryUser.CreateUser(MapperUser.MapTo(source)));
		}


		/// <summary>
        /// Modifica una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a modificar</param>
        /// <returns>Número de User modificados</returns>
		public virtual async Task<int> ActualizarUserAsync(Entities.User source)
		{
			return await _RepositoryUser.UpdateUserAsync(MapperUser.MapTo(source));
		}

		/// <summary>
        /// Modifica una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a modificar</param>
        /// <returns>Número de User modificados</returns>
		public virtual int ActualizarUser(Entities.User source)
		{
			return _RepositoryUser.UpdateUser(MapperUser.MapTo(source));
		}

		/// <summary>
        /// Borra una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a borrar</param>
        /// <returns>Número de User borrados</returns>
		public virtual async Task<int> BorrarUserAsync(Entities.User source)
		{
			return await _RepositoryUser.DeleteUserAsync(MapperUser.MapTo(source));
		}

		/// <summary>
        /// Borra una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a borrar</param>
        /// <returns>Número de User borrados</returns>
		public virtual int BorrarUser(Entities.User source)
		{
			return _RepositoryUser.DeleteUser(MapperUser.MapTo(source));
		}
    }
}
