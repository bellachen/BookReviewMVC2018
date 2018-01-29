using System.Web;
using System.Web.Mvc;

namespace BookReviewMVC2018_VersionB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
