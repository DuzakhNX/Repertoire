using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MyApp.Controllers;

public class ChauffeurController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }
}