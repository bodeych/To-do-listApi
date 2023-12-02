using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoListController : ControllerBase
{
    private static List<ToDoList> ToDoLists = new List<ToDoList>();

    [HttpGet]
    public async Task<ActionResult<List<ToDoList>>> GetAllToDoLists()
    {
        return Ok(ToDoLists);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<List<ToDoList>>> GetSingleToDoList(int id)
    {
        var point = ToDoLists.Find((x => x.Id == id));
        if (point is null)
        {
            return NotFound("Id doesn't exist.");
        }
        return Ok(point);
    }

    [HttpPost]
    public async Task<ActionResult<List<ToDoList>>> AddToDoList(ToDoList point)
    {
        ToDoLists.Add(point);
        return Ok(ToDoLists);
    }
    
    [HttpPost("{id}")]
    public async Task<ActionResult<List<ToDoList>>> AddToDoListItem(int id, ToDoListPoint point)
    {
        var toDoList = ToDoLists.Find((x => x.Id == id));
        if (toDoList is null)
        {
            return NotFound("Id doesn't exist.");
        }
        toDoList.Points.Add(point);
        return Ok(toDoList.Points);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<ToDoListPoint>>> DeleteToDoList(int id)
    {
        var toDoList = ToDoLists.Find((x => x.Id == id));
        if (toDoList is null)
        {
            return NotFound("Id doesn't exist.");
        }

        ToDoLists.Remove(toDoList);
        return Ok(ToDoLists);
    }  
}