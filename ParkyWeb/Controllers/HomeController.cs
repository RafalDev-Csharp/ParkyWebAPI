﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkyWeb.Models;
using ParkyWeb.Models.ViewModel;
using ParkyWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INationalParkRepository _npRepo;
        private readonly ITrailRepository _trialRepo;

        public HomeController(ILogger<HomeController> logger, INationalParkRepository npRepo,
            ITrailRepository trialRepo)
        {
            _logger = logger;
            _npRepo = npRepo;
            _trialRepo = trialRepo;
        }

        public async Task<IActionResult> Index()
        {
            IndexVM listOfParksAndTrials = new IndexVM()
            {
                NationalParkList = await _npRepo.GetAllAsync(SD.NationalParkAPIPath),
                TrailList = await _trialRepo.GetAllAsync(SD.TrailAPIPath)
            };
            return View(listOfParksAndTrials);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
