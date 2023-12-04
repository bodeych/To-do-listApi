using System.Data.Common;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoListController : ControllerBase
{
    private static List<ToDoList> ToDoLists = new List<ToDoList>();
    [DataContract]
    public class ToDoListPointDto
    {
        [DataMember(Name = "task")]
        [JsonPropertyName("task")]
        public string Task { get; set; }
    }

    

    [HttpGet]
    public async Task<ActionResult<List<ToDoList>>> GetAllToDoLists()
    {
        return Ok(ToDoLists);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<List<ToDoList>>> GetSingleToDoList([FromRoute]Guid id, [FromBody]ToDoListPointDto body)
    {
        var point = ToDoLists.Find((x => x.Id == id));
        if (point is null)
        {
            return NotFound("Id doesn't exist.");
        }
        return Ok(point);
    }

    [HttpPost]
    public async Task<ActionResult<List<ToDoList>>> AddToDoList()
    {

        ToDoLists.Add(ToDoList.Create());
        
        return Ok(ToDoLists);
    }
    
    [HttpPost("{id}")]
    public async Task<ActionResult<List<ToDoList>>> AddToDoListItem([FromRoute]Guid id, [FromBody]ToDoListPointDto body)
    {
        var toDoList = ToDoLists.Find((x => x.Id == id));
        if (toDoList is null)
        {
            return NotFound("Id doesn't exist.");
        }

        toDoList.AddPoint(body.Task);
    
        return Ok(toDoList.Points);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<ToDoList.ToDoListPoint>>> DeleteToDoList([FromRoute]Guid id, [FromBody]ToDoListPointDto body)
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

