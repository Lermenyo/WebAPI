
using System;
using System.Collections.Generic;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Entities
{
    /// <summary>
    /// Clase User 
    /// </summary>
    public class User
	{
        /// <summary>
        /// Id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Birthdate 
        /// </summary>
        public DateTime Birthdate { get; set; }

    }
}
