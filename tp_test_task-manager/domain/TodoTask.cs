namespace tp_test_task_manager.domain;

public class TodoTask
{
    public int Number { get; set; }
    public string Name { get; set; }
    public bool IsDone { get; set; }

    public TodoTask(int number, string name)
    {
        Number = number;
        Name = name;
        IsDone = false;
    }
}