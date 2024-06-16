using final_project_aspdotnet_web_api.Data;
using final_project_aspdotnet_web_api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace final_project_aspdotnet_web_api.Controllers
{
    [Route("api/[controller]")] //This is the URL Endpoint and the [controller] refers to the NAME of the controller that will be used at that URL Endpoint --> It is the controlller name that precedes the ": ControllerBase", so in this case it is the "TodosController"
    [ApiController] //This attribute helps provide our Controllers with ability to serve HTTP API Responses
    public class TodosController : ControllerBase
    {
        private readonly DataContext _context;

        public TodosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        //Line 13 is the syntax to be able to see the Schema and Expected reponse values with data types after a successfull HTTP Request/Response async operation in Swagger UI
        public async Task<ActionResult<List<Todos>>> GetAllTodos()
        {
            var todos = await _context.Todos.ToListAsync();

            return Ok(todos);
        }

        [HttpGet("{id}")] //Find SINGLE todo --> We need to specify in the HTTP method that we want to FIND the todo by ID, so we assign the ID as a route paramater
        public async Task<ActionResult<Todos>> GetTodo(int id)
        {
            var todos = await _context.Todos.FindAsync(id);
            if (todos == null)
                return BadRequest("Todo not found");

            return Ok(todos);
        }

        [HttpPost]
        public async Task<ActionResult<List<Todos>>> AddTodo(Todos todo)
        {
            _context.Todos.Add(todo); //This begins the tracking of newly created todo, but we still need to SAVE newly creation to Database
            await _context.SaveChangesAsync(); //Here, we SAVE the newly created todo in the Database

            return Ok(await _context.Todos.ToListAsync());//Return the entire list of todos
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Todos>>> UpdateTodo(Todos updatedtodo, int id)
        {
            var dbtodo = await _context.Todos.FindAsync(id);
            if (dbtodo == null)
                return BadRequest("Todo not found");

            dbtodo.Name = updatedtodo.Name;
            dbtodo.Description = updatedtodo.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.Todos.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Todos>>> DeleteTodo(int id)
        {
            var dbtodo = await _context.Todos.FindAsync(id);
            if (dbtodo == null)
                return BadRequest("Todo not found");

            _context.Todos.Remove(dbtodo); //Here, we are using the Remove() method to DELETE item from Database

            await _context.SaveChangesAsync();

            return Ok(await _context.Todos.ToListAsync());
        }
    }
}
