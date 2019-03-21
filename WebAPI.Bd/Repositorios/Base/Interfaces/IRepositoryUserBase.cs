
using System;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Bd.Model;

namespace WebAPI.Bd.Repositories.Base
{
    public interface IRepositoryUserBase
	{
		/// <summary>
        /// Metodo para obtener todos los User 
        /// </summary>
        /// <returns>IQueryable con todos los User</returns>
		IQueryable<User> GetUser();
		
        
        /// <summary>
        /// Obtener un User por su clave primaria
        /// </summary>
				/// <param name="id">Id</param>
		        /// <returns>User   seleccionado por su clave primaria</returns>
		Task<User> GetUserByPrimaryKeyAsync(int id);
		
        /// <summary>
        /// Obtener un User por su clave primaria
        /// </summary>
				/// <param name="id">Id</param>
		        /// <returns>User  seleccionado por su clave primaria</returns>
		User GetUserByPrimaryKey(int id);


        


		/// <summary>
        /// Crea una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a crear</param>
        /// <returns>User creado</returns>
		Task<User> CreateUserAsync(User source);

		/// <summary>
        /// Crea una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a crear</param>
        /// <returns>User creado</returns>
		User CreateUser(User source);


		/// <summary>
        /// Modifica una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a modificar</param>
        /// <returns>Número de User modificados</returns>
		Task<int> UpdateUserAsync(User source);
		

		/// <summary>
        /// Modifica una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a modificar</param>
        /// <returns>Número de User modificados</returns>
		int UpdateUser(User source);

		/// <summary>
        /// Borra una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a borrar</param>
        /// <returns>Número de User borrados</returns>
		Task<int> DeleteUserAsync(User source);
		
		/// <summary>
        /// Borra una instancia de User en la base de datos
        /// </summary>
        /// <param name="source">User a borrar</param>
        /// <returns>Número de User borrados</returns>
		int DeleteUser(User source);
    }
}
