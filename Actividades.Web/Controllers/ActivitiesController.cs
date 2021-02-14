namespace Activities.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Activity.Web.Data.Entidades;
    using System.Collections.Generic;
    using Actividades.Web.Data;
    using Actividades.Web.Helpers;
    using Actividades.Web.Models;

    public class ActivitiesController : Controller
    {
        private readonly IActivityRepository activityRepository;
        private readonly IUserHelper userHelper;


        public ActivitiesController(
            IActivityRepository activityRepository,
            IUserHelper userHelper)
        {

            this.activityRepository = activityRepository;
            this.userHelper = userHelper;
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
          List<Activity> model = await activityRepository.GetActivityForUser(this.User.Identity.Name);
            return View(model);
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Activity activity = await this.activityRepository.GetByIdAsync(id.Value);

            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Activity model)
        {
            if (ModelState.IsValid)
            {
                model.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                model.CreationDate = System.DateTime.Now;
                await this.activityRepository.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Activity activity = await this.activityRepository.GetByIdAsync(id.Value);

            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Activity model)
        {
            if (ModelState.IsValid)
            {
                await this.activityRepository.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Activity activity = await this.activityRepository.GetByIdAsync(id.Value);

            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Activity activity = await this.activityRepository.GetByIdAsync(id);
                await activityRepository.DeleteAsync(activity);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }

}
