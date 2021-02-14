namespace Actividades.Web.Data
{
    using Activity.Web.Data.Entidades;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IActivityRepository : IGenericRepository<Activity>
    {

        Task<List<Activity>> GetActivityForUser(string userName);

    }

}
