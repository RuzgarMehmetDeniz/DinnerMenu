using Microsoft.AspNetCore.Mvc;

namespace DinnerMenuPostgreSQL.ViewComponents.DashboardViewComponents
{
    public class _DashboardHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
