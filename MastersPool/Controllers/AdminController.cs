using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MastersPool.Services.Interfaces;
using MastersPool.Models;

namespace MastersPool.Controllers
{
    public class AdminController : Controller
    {
        public AdminController(IConfigurationService cs, IGolferService gs)
        {
            this.configService = cs;
            this.golferService = gs;
        }
        //
        // GET: /Admin/
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            AdminViewModelBuilder builder = 
                new AdminViewModelBuilder(this.configService, this.golferService);
            
            ViewData.Model = builder.Build();
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult ConvertYear()
        {
            this.configService.ConvertYear();

            AdminViewModelBuilder builder = 
                new AdminViewModelBuilder(this.configService, this.golferService);
            AdminViewModel viewModel = builder.Build();
            viewModel.Message = "Pool converted. . .";
            ViewData.Model = viewModel;
            return View("Index");
        }

        private IConfigurationService configService = null;
        private IGolferService golferService = null;
    }
}
