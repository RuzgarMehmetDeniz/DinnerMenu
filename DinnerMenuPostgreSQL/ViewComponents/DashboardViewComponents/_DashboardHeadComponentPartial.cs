using Microsoft.AspNetCore.Mvc;

namespace DinnerMenuPostgreSQL.ViewComponents.DashboardViewComponents
{
    public class _DashboardHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
