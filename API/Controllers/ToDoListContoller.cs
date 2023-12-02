using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoListController : ControllerBase
{
    private static List<ToDoListPoint> ToDoList = new List<ToDoListPoint>
    {
        new ToDoListPoint { Id = 1, Task = "Shopping" },
        new ToDoListPoint { Id = 2, Task = "Gym" },
    };

    [HttpGet]
    public async Task<ActionResult<List<ToDoListPoint>>> GetAllPoints()
    {
        return Ok(ToDoList);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<List<ToDoListPoint>>> GetSinglePoint(int id)
    {
        var point = ToDoList.Find((x => x.Id == id));
        if (point is null)
        {
            return NotFound("Id doesn't exist.");
        }
        return Ok(point);
    }

    [HttpPost]
    public async Task<ActionResult<List<ToDoListPoint>>> AddPoint(ToDoListPoint task)
    {
        ToDoList.Add(task);
        return Ok(ToDoList);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<ToDoListPoint>>> DeletePoint(int id)
    {
        var point = ToDoList.Find((x => x.Id == id));
        if (point is null)
        {
            return NotFound("Id doesn't exist.");
        }

        ToDoList.Remove(point);
        return Ok(ToDoList);
    }  
}