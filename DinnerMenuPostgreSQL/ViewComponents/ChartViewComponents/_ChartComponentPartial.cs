using Microsoft.AspNetCore.Mvc;

namespace DinnerMenuPostgreSQL.ViewComponents.ChartViewComponents
{
    public class _ChartComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}