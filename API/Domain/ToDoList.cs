namespace API;

public class ToDoList
{
    public Guid Id { get; set; }
    public List<ToDoListPoint> Points { get; set; } = new();

    private ToDoList(Guid id)
    {
        Id = id;
    }

    public static ToDoList Create()
    {
        var list = new ToDoList(Guid.NewGuid());

        return list;
    }

    public void AddPoint(string task)
    {
        var point = new ToDoListPoint
        {
            Id = Guid.NewGuid(),
            Task = task
        };

        Points.Add(point);
    }

    public class ToDoListPoint
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
    }
}
