﻿using Microsoft.AspNetCore.Mvc;

namespace MyRemember.WebApi.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}