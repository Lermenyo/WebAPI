
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Domain.Mapper.Base;


namespace WebAPI.Domain.Mapper
{
    using Entities = WebAPI.Bd.Model;
    using DTO = WebAPI.Domain.Entities;

    /// <summary>
    /// Clase User 
    /// </summary>
    public class MapperUser : MapperUserBase
	{
        public static DTO.User MapToRelated(Entities.User source, Type tipoRelacionado = null)
        {
            if(source == null)
                return null;
            DTO.User result = MapTo(source);
            return result;
        }

        public static Entities.User MapToRelated(DTO.User source, Type tipoRelacionado = null)
        {
            if(source == null)
                return null;
            Entities.User result = MapTo(source);
            return result;
        }


    }
}
