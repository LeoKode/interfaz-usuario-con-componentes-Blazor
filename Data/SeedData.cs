namespace BlazingPizza.Data
{
    // La clase SeedData se usa para inicializar la base de datos con datos de prueba
    public static class SeedData
    {
        // Método para inicializar la base de datos con datos de ejemplo
        public static void Initialize(PizzaStoreContext db)
        {
            // Array de objetos PizzaSpecial para insertar en la base de datos
            var specials = new PizzaSpecial[]
            {
                new PizzaSpecial()
                {
                    Name = "Basic Cheese Pizza",
                    Description = "Es quesosa y deliciosa. ¿Por qué no querrías una?",
                    BasePrice = 9.99m,
                    ImageUrl = "img/pizzas/cheese.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 2,
                    Name = "The Baconatorizor",
                    Description = "Tiene TODOS los tipos de tocino",
                    BasePrice = 11.99m,
                    ImageUrl = "img/pizzas/bacon.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 3,
                    Name = "Pepperoni clásico",
                    Description = "Es la pizza con la que creciste, ¡pero muy picante!",
                    BasePrice = 10.50m,
                    ImageUrl = "img/pizzas/pepperoni.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 4,
                    Name = "Pollo búfalo",
                    Description = "Pollo picante, salsa picante y queso azul, garantizado para calentarte",
                    BasePrice = 12.75m,
                    ImageUrl = "img/pizzas/meaty.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 5,
                    Name = "Amantes de los champiñones",
                    Description = "Tiene champiñones. ¿No es obvio?",
                    BasePrice = 11.00m,
                    ImageUrl = "img/pizzas/mushroom.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 7,
                    Name = "Delicia vegetariana",
                    Description = "Es como una ensalada, pero en una pizza",
                    BasePrice = 11.50m,
                    ImageUrl = "img/pizzas/salad.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 8,
                    Name = "Margherita",
                    Description = "Pizza italiana tradicional con tomates y albahaca",
                    BasePrice = 9.99m,
                    ImageUrl = "img/pizzas/margherita.jpg",
                },
            };
            // Agrega los datos a la tabla Specials en la base de datos
            db.Specials.AddRange(specials);
            // Guarda los cambios en la base de datos
            db.SaveChanges();
        }
    }
}
// La clase usa un contexto de base de datos pasado, crea algunos objetos PizzaSpecial en una matriz y, a continuación, los guarda.