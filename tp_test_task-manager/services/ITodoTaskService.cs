using tp_test_task_manager.domain;

namespace tp_test_task_manager;

public interface ITodoTaskService
{
    TodoTask AddTask(string taskName);
}