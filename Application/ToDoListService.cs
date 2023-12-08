using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Domain;
namespace Application;

public class ToDoListService
{
    private static List<ToDoList> ToDoLists = new List<ToDoList>();
    
   
    public class ToDoListPointServiceDto
    {
        public string Task { get; set; }
    }

    public List<ToDoList> Get()
    {
        return ToDoLists;
    }
    
   
    public ToDoList? FindBy(Guid id)
    {
        var point = ToDoLists.Find((x => x.Id == id));
        return point;
    }
    public List<ToDoList> CreateToDoList() { 
        ToDoLists.Add(ToDoList.Create());
        return ToDoLists;
    }

    public ToDoList? AddItem(Guid id, ToDoListPointServiceDto body)
    {
        var toDoList = ToDoLists.Find((x => x.Id == id));
        if (toDoList is null)
        {
            return null;
        }

        toDoList.AddPoint(body.Task);
        return toDoList;
    }

    public bool DeleteToDoList(Guid id)
    {
        var toDoList = ToDoLists.Find((x => x.Id == id));
        if (toDoList is null)
        {
            return false;
        }

        ToDoLists.Remove(toDoList);
        return true;
    }

}