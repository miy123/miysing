using eip.Models;
using Microsoft.AspNetCore.Mvc;
using miysing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace miysing.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            Db = new UnitOfWork(new MiySongDbContext());
        }
        public IUnitOfWork Db;
    }
}