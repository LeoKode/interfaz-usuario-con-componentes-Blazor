using BlazingPizza.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Controllers;
// Establece la ruta base para este controlador en "specials"
// y especifica que es un controlador API
[Route("specials")]
[ApiController]
public class SpecialsController : Controller
{
    // Campo privado para el contexto de la base de datos
    private readonly PizzaStoreContext _db;

    // Constructor que inicializa el contexto de la base de datos mediante inyección de dependencias
    public SpecialsController(PizzaStoreContext db)
    {
        _db = db;
    }

    // Método que maneja las solicitudes GET a "specials"
    // Devuelve una lista de PizzaSpecials ordenada por precio base en orden descendente
    [HttpGet]
    public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
    {
        return (await _db.Specials.ToListAsync()).OrderByDescending(s => s.BasePrice).ToList();
    }
}

// Esta clase crea un controlador que nos permitirá consultar en la base de datos las pizzas especiales
// y devolverlas como JSON en la dirección URL (http://localhost:5000/specials).