// Importa el espacio de nombres para Entity Framework Core
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Data;

// Define la clase PizzaStoreContext que hereda de DbContext
public class PizzaStoreContext : DbContext
{   // Constructor que recibe opciones de configuración para el contexto y las pasa al constructor base
    public PizzaStoreContext(DbContextOptions options) : base(options)
    {
    }
    // Define una propiedad DbSet para manejar las entidades PizzaSpecial
    public DbSet<PizzaSpecial> Specials { get; set; }
}

/* Esta clase crea un contexto de base de datos que se puede usar para registrar un servicio de base de datos.
El contexto también nos permite tener un controlador que accede a la base de datos. */
