namespace tp_test_task_manager.domain;

public class TodoTask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsDone { get; set; }

    public TodoTask(int id, string name)
    {
        Id = id;
        Name = name;
        IsDone = false;
    }
}