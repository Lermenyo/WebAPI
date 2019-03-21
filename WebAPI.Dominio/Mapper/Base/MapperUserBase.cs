
using System;
using System.Collections.Generic;


namespace WebAPI.Domain.Mapper.Base
{
    using Entities = WebAPI.Bd.Model;
    using DTO = WebAPI.Domain.Entities;

    /// <summary>
    /// Clase User 
    /// </summary>
    public class MapperUserBase
	{
        public static DTO.User MapTo(Entities.User source)
        {
            if(source == null)
                return null;
            return new DTO.User()
            {
                Id = source.Id,
                Name = source.Name,
                Birthdate = source.Birthdate
            };

        }

        public static Entities.User MapTo(DTO.User source)
        {
            if(source == null)
                return null;
            return new Entities.User()
            {
                Id = source.Id,
                Name = source.Name,
                Birthdate = source.Birthdate
            };
        }


    }
}
