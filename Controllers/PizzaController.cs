using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    // Retorna uma instância de ActionResult do tipo List<Pizza>. 
    // O tipo ActionResult é a classe base para todos os resultados da ação no ASP.NET Core.
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    // O cliente também pode querer solicitar informações sobre uma pizza específica em vez de toda a lista. 
    // Você pode implementar outra ação GET que requer um parâmetro id
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if(pizza == null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {            
        PizzaService.Add(pizza);

        return CreatedAtAction(
        nameof(Get),
        new { id = pizza.Id },
        pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        var existingPizza = PizzaService.Get(id);

        if (existingPizza == null)
            return NotFound();

        pizza.Id = id;
        PizzaService.Update(pizza);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingPizza = PizzaService.Get(id);

        if (existingPizza == null)
            return NotFound();

        PizzaService.Delete(id);
        return NoContent();
    }
}