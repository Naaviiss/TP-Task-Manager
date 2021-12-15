using tp_test_task_manager.domain;

namespace tp_test_task_manager;

public class TodoTaskService : ITodoTaskService
{
    public IReadOnlyList<TodoTask> Tasks => tasks.AsReadOnly();
    private readonly List<TodoTask> tasks;
    private int nextTaskId = 0;

    public TodoTaskService()
    {
        tasks = new List<TodoTask>();
    }

    public void AddTask(string taskName)
    {
        var task = new TodoTask(++nextTaskId, taskName);
        tasks.Add(task);
    }

    public void RemoveTask(int id)
    {
        tasks.RemoveAll(task => task.Id.Equals(id));
    }

    public void SetTaskStatus(int id, bool status)
    {
        try
        {
            tasks.First(t => t.Id == id).IsDone = status;
        }
        catch (Exception)
        {
            throw new ArgumentException($"No Task with id: {id}");
        }
    }
}