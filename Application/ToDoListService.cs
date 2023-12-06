using Domain;
namespace Application;

public class ToDoListService
{
    private static List<ToDoList> ToDoLists = new List<ToDoList>();

    public ToDoList? FindBy(Guid id)
    {
        var point = ToDoLists.Find((x => x.Id == id));
        return point;
    }
    public void AddToDoList() { 
        ToDoLists.Add(ToDoList.Create());
    }

    public ToDoList? AddItem(Guid id,)
    {
        var toDoList = ToDoLists.Find((x => x.Id == id));
        if (toDoList is null)
        {
            return null;
        }

        return toDoList.AddPoint(body.Task);
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