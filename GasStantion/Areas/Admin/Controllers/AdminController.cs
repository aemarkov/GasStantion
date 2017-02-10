using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasStantion.Models;

namespace GasStantion.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleNames.Admin+","+RoleNames.Moderator)]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}