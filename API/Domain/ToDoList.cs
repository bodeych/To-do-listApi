namespace API;

public class ToDoList
{
    public int Id { get; set; }
    public List<ToDoListPoint> Points { get; set; }
}

public class ToDoListPoint
{
    public int Id { get; set; }
    public string Task { get; set; }
}