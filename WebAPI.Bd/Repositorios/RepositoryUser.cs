
using System.Linq;
using WebAPI.Bd.Model;
using WebAPI.Bd.Repositories.Base;

namespace WebAPI.Bd.Repositories
{
    public class RepositoryUser : RepositoryUserBase, IRepositoryUser
	{
		public RepositoryUser (WebAPIContext dbContext) : base(dbContext)
		{

		}
    }
}
