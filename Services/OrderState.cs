namespace BlazingPizza.Services;

// Clase que gestiona el estado de la orden, como el diálogo de configuración y la pizza actualmente en configuración
public class OrderState
{
    // Indica si el diálogo de configuración está visible
    public bool ShowingConfigureDialog { get; private set; }

    // La pizza que se está configurando actualmente
    public Pizza ConfiguringPizza { get; private set; }

    // La orden actual que se está creando
    public Order Order { get; private set; } = new Order();

    // Método para mostrar el diálogo de configuración de la pizza
    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        // Crea una nueva pizza para configurar con la especialidad proporcionada
        ConfiguringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<PizzaTopping>(),
        };

        // Establece el indicador de visualización del diálogo en verdadero
        ShowingConfigureDialog = true;
    }

    // Método para cancelar la configuración de la pizza
    public void CancelConfigurePizzaDialog()
    {
        // Elimina la pizza que se estaba configurando
        ConfiguringPizza = null;

        // Oculta el diálogo de configuración
        ShowingConfigureDialog = false;
    }

    // Método para confirmar la configuración de la pizza
    public void ConfirmConfigurePizzaDialog()
    {
        // Agrega la pizza configurada a la orden actual
        Order.Pizzas.Add(ConfiguringPizza);

        // Limpia la pizza en configuración
        ConfiguringPizza = null;

        // Oculta el diálogo de configuración
        ShowingConfigureDialog = false;
    }

    // Método para quitar pizzas de un pedido.
    public void RemoveConfiguredPizza(Pizza pizza)
    {
        Order.Pizzas.Remove(pizza);
    }
}
