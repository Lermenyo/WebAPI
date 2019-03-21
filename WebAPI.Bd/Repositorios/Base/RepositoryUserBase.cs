
using System;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Bd.Model;
using Graddo.Common.Db;

namespace WebAPI.Bd.Repositories.Base
{
    public class RepositoryUserBase : IRepositoryUserBase
	{
		protected readonly EFRepository _efRepository;

		/// <summary>
        /// Constructor de la clase User 
        /// </summary>
		public RepositoryUserBase(WebAPIContext dbContext)
		{
			_efRepository = new EFRepository(dbContext);
		}

		/// <summary>
        /// Metodo para obtener todos los User 
        /// </summary>
        /// <returns>IQueryable con todos los User</returns>
		public IQueryable<User> GetUser()
		{
			return _efRepository.All<User>();
		}

        
        /// <summary>
        /// Obtener un User por su clave primaria
        /// </summary>
		/// <param name="id">Id</param>
        /// <returns>User   seleccionado por su clave primaria</returns>
		public async Task<User> GetUserByPrimaryKeyAsync(int id)
		{
			return await _efRepository.FindAsync<User>(x=>x.Id == id);
		}

        /// <summary>
        /// Obtener un User por su clave primaria
        /// </summary>
		/// <param name="id">Id</param>
        /// <returns>User  seleccionado por su clave primaria</returns>
		public User GetUserByPrimaryKey(int id)
		{
			return _efRepository.Find<User>(x=>x.Id == id);
		}




		/// <summary>
        /// Crea una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a crear</param>
        /// <returns>User creado</returns>
		public async Task<User> CreateUserAsync(User source)
		{
			return await _efRepository.CreateAsync<User>(source);
		}

		/// <summary>
        /// Crea una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a crear</param>
        /// <returns>User creado</returns>
		public User CreateUser(User source)
		{
			return _efRepository.Create<User>(source);
		}


		/// <summary>
        /// Modifica una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a modificar</param>
        /// <returns>Número de User modificados</returns>
		public async Task<int> UpdateUserAsync(User source)
		{
			return await _efRepository.UpdateAsync<User>(source);
		}

		/// <summary>
        /// Modifica una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a modificar</param>
        /// <returns>Número de User modificados</returns>
		public int UpdateUser(User source)
		{
			return _efRepository.Update<User>(source);
		}

		/// <summary>
        /// Borra una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a borrar</param>
        /// <returns>Número de User borrados</returns>
		public async Task<int> DeleteUserAsync(User source)
		{
			return await _efRepository.DeleteAsync<User>(source);
		}

		/// <summary>
        /// Borra una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a borrar</param>
        /// <returns>Número de User borrados</returns>
		public int DeleteUser(User source)
		{
			return _efRepository.Delete<User>(source);
		}
    }
}
