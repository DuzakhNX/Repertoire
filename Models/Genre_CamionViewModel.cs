using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyApp.Models;

public class Genre_CamionViewModel
{
    public List<Chauffeur>? Chauffeurs { get; set; }
    public SelectList? Genres { get; set; }
    public string? GenreCamion { get; set; }
    public string? SearchString { get; set; }
}