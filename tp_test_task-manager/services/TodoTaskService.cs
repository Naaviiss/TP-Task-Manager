using tp_test_task_manager.domain;

namespace tp_test_task_manager;

public class TodoTaskService : ITodoTaskService
{
    private int count = 0;

    public TodoTask AddTask(string taskName)
    {
        var task = new TodoTask(++count, taskName);
        return task;
    }
}