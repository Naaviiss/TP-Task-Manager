using NUnit.Framework;

namespace tp_test_task_manager.Test;

public class Tests
{
    private ITodoTaskService taskService;

    [SetUp]
    public void Setup()
    {
        taskService = new TodoTaskService();
    }

    [Test]
    public void AddTask_WithValidTask_CreatesTask()
    {
        //Given
        string name = "Learn C#";

        //When
        var task = taskService.AddTask(name);

        //Then
        Assert.AreEqual(name, task.Name);
        Assert.AreEqual(false, task.IsDone);
        Assert.AreEqual(1, task.Number);
    }

    [Test]
    public void AddTask_WithSeveralTasks_IncreaseTaskNumber()
    {
        //Given
        string name = "Learn C#";
        string name2 = "Learn Java";

        //When
        var task = taskService.AddTask(name);
        var task2 = taskService.AddTask(name2);

        //Then
        Assert.AreEqual(1, task.Number);
        Assert.AreEqual(2, task2.Number);
    }
}