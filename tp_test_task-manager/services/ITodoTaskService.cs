using tp_test_task_manager.domain;

namespace tp_test_task_manager;

public interface ITodoTaskService
{
    IReadOnlyList<TodoTask> Tasks { get; }
    TodoTask AddTask(string taskName);
    void RemoveTask(int id);
    void SetTaskStatus(int id, bool status);
}