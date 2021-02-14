namespace Actividades.Web.Data
{
    using Activity.Web.Data.Entidades;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        private readonly DataContext context;

        public ActivityRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Activity>> GetActivityForUser(string userName)
        {
            return await context.Activities.Where(a => a.User.Email == userName).ToListAsync();
        }
    }

}
