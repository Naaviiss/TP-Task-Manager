using tp_test_task_manager.domain;

namespace tp_test_task_manager;

public class TodoTaskService : ITodoTaskService
{
    public IReadOnlyList<TodoTask> Tasks => tasks.AsReadOnly();
    private readonly List<TodoTask> tasks;
    private int nextTaskNumber = 0;

    public TodoTaskService()
    {
        tasks = new List<TodoTask>();
    }

    public TodoTask AddTask(string taskName)
    {
        var task = new TodoTask(++nextTaskNumber, taskName);
        tasks.Add(task);
        return task;
    }
}