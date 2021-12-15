using tp_test_task_manager.domain;

namespace tp_test_task_manager;

public class TodoTaskService : ITodoTaskService
{
    public TodoTask AddTask(string taskName)
    {
        var task = new TodoTask(1, taskName);
        return task;
    }
}