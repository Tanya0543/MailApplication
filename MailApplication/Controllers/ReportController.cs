using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DevExpressMvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Add the report to a view data.
            ViewData["Report"] = new DevExpressMvcApplication1.Reports.XtraReport1();
            return View();
        }

        public ActionResult ReportViewerPartial()
        {
            ViewData["Report"] = new DevExpressMvcApplication1.Reports.XtraReport1();
            return PartialView("ReportViewerPartial");
        }

        public ActionResult ExportReportViewer()
        {
            return DevExpress.Web.Mvc.ReportViewerExtension.ExportTo(
                new DevExpressMvcApplication1.Reports.XtraReport1());
        }
    }
}