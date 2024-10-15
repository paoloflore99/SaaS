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
            decimal Previdenziali_Previdenziali = 9.19m;
            decimal contributiPrevidenziali = lordo * (Previdenziali_Previdenziali / 100);
            decimal redditoImponibile = lordo - contributiPrevidenziali;

            decimal Irpef = 0.0m;
            if (redditoImponibile <= 15000)
            {
                Irpef = redditoImponibile * 0.23m;
            }
            else if (redditoImponibile > 15000 && redditoImponibile <= 28000)
            {
                Irpef = (15000 * 0.23m) + ((redditoImponibile - 15000) * 0.25m);
            }
            else if (redditoImponibile > 28000 && redditoImponibile <= 50000)
            {
                Irpef = (15000 * 0.23m) + (13000 * 0.25m) + ((redditoImponibile - 28000) * 0.35m);
            }
            else
            {
                Irpef = (15000 * 0.23m) + (13000 * 0.25m) + (22000 * 0.35m) + ((redditoImponibile - 50000) * 0.43m);
            }

            decimal addizionaleRegionale = redditoImponibile * 0.02m; //2%
            decimal addizionaleComunale = redditoImponibile * 0.005m; //0.5%
            decimal totaleAddizionali = addizionaleRegionale + addizionaleComunale;

            decimal netto = lordo - contributiPrevidenziali - Irpef - totaleAddizionali;
            decimal meselordo = Math.Round(lordo / 12, 2);
            decimal mesenetto = Math.Round(netto / 12, 2);
            decimal meselordo13 = Math.Round(lordo / 13, 2);
            decimal mesenetto13 = Math.Round(netto / 13, 2);
            decimal meselordo14 = Math.Round(lordo / 14, 2);
            decimal mesenetto14 = Math.Round(netto / 14, 2);
            decimal costodatore = Math.Round(lordo * 0.30m, 2);

            CalcoloViewModel calcoloViewModel = new CalcoloViewModel
            {
                Lordo = Math.Round(lordo,2),
                Netto = Math.Round(netto,2),
                MeseLordo = meselordo,
                MeseNetto = mesenetto ,
                MeseLordo13 = meselordo13,
                MeseNetto13 = mesenetto13,
                MeseLordo14 = meselordo14,
                MeseNetto14 = mesenetto14,

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
