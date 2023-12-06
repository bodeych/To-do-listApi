using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Domain;
namespace Application;

public class ToDoListService
{
    private static List<ToDoList> ToDoLists = new List<ToDoList>();

    [DataContract]
    public class ToDoListServiceDto
    {
        public string Task { get; set; }
    }
    public ToDoList? FindBy(Guid id)
    {
        var point = ToDoLists.Find((x => x.Id == id));
        return point;
    }
    public void AddToDoList() { 
        ToDoLists.Add(ToDoList.Create());
    }

    public List<ToDoList>? AddItem(Guid id, ToDoListServiceDto body)
    {
        var toDoList = ToDoLists.Find((x => x.Id == id));
        if (toDoList is null)
        {
            return null;
        }

        toDoList.AddPoint(body.Task);
        return ToDoLists;
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