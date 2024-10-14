using Microsoft.AspNetCore.Mvc;
using SaaS.Models;
using System.Diagnostics;

namespace SaaS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CalcoloViewModel calcoloViewModel = new CalcoloViewModel
            {
                Lordo = 0,
                Netto = 0,
                MeseLordo = 0,
                MeseNetto = 0
            };

            return View(calcoloViewModel);
        }
        [HttpPost]
        public IActionResult Calcolo([FromForm(Name = "lordo")] decimal lordo)
        {
            //Contributi Previdenziali e Previdenziali
            //vanno dal 9.19% al 9,49%
            decimal Previdenziali_Previdenziali = 9.19m;

            //IRPEF 
            //Fino a €15.000: 23 %
            //Da €15.001 a €28.000: 25 %
            //Da €28.001 a €50.000: 35 %
            //Oltre €50.000: 43 %
            decimal Irpef = 0.0m;

            decimal netto = lordo * 0.8m;
            decimal mesenetto = 0;
            decimal meselordo = 0;
            meselordo = lordo / 13;
            mesenetto = netto / 13;    
            decimal costodatore = lordo * 0.30m;
            CalcoloViewModel calcoloViewModel = new CalcoloViewModel
            {
                Lordo = lordo,
                Netto = netto ,
                MeseLordo = meselordo,
                MeseNetto = mesenetto
            };
            
            return View("Index" , calcoloViewModel);
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
