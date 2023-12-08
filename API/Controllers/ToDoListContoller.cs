using System.Data.Common;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Application;


namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoListController : ControllerBase
{
    private readonly ToDoListService _service;
    public ToDoListController(ToDoListService service)
    {
        _service = service;
    }
    
    [DataContract]
    public class ToDoListDto
    {
        public Guid Id { get; set; }
    }
    [DataContract]
    public class ToDoListPointDto
    {
        [DataMember(Name = "task")]
        [JsonPropertyName("task")]
        public string Task { get; set; }
        public Guid Id { get; set; }
    }
    [DataContract]
    public class ToDoListResponseDto
    {
        [DataMember(Name = "id")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [DataMember(Name = "task")] 
        [JsonPropertyName("task")]
        public string Task { get; set; }
    }


    [HttpGet]
    public async Task<ActionResult<List<ToDoListResponseDto>>> GetAllToDoLists()
    {
        return Ok(_service.Get());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<List<ToDoListResponseDto>>> GetSingleToDoList([FromRoute]Guid id)
    {
        var point = _service.FindBy(id);
        return Ok(point);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<ToDoListResponseDto>>> AddToDoList()
    {
        var list = _service.CreateToDoList();
        return Ok(list);
    }
    
    [HttpPost("{id}")]
    public async Task<ActionResult<List<ToDoListResponseDto>>> AddToDoListItem([FromRoute]Guid id, [FromBody]ToDoListPointDto body)
    {
        var servicePointDto = new ToDoListService.ToDoListPointServiceDto
        {
            Task = body.Task
        };
        var toDoList = _service.AddItem(id, servicePointDto);
        if (toDoList == null)
        {
            return NotFound(); 
        }
        var response = new ToDoListResponseDto
        {
            Id = toDoList.Id,
            Task = toDoList
        };
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<ToDoListResponseDto>>> DeleteList([FromRoute]Guid id)
    {
        _service.DeleteToDoList(id);
        return NoContent();
    } 
}

