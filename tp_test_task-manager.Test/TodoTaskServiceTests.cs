using System;
using System.Linq;
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
        Assert.AreEqual(1, task.Id);
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
        Assert.AreEqual(1, task.Id);
        Assert.AreEqual(2, task2.Id);
    }

    [Test]
    public void AddTask_WithSeveralTasks_InsertMultipleTasks()
    {
        //Given
        string name = "Learn C#";
        string name2 = "Learn Java";

        //When
        _ = taskService.AddTask(name);
        _ = taskService.AddTask(name2);

        //Then
        Assert.AreEqual(2, taskService.Tasks.Count);
    }

    [Test]
    public void RemoveTask_WithExistingId_RemoveTask()
    {
        //Given
        string name = "Learn Java";
        var id = taskService.AddTask(name).Id;

        //When
        taskService.RemoveTask(id);

        //Then
        Assert.AreEqual(0, taskService.Tasks.Count);
    }

    [Test]
    public void SetTaskStatus_DoWithExistingId_TaskIsDone()
    {
        //Given
        string name = "Learn Java";
        var id = taskService.AddTask(name).Id;

        //When
        taskService.SetTaskStatus(id, true);

        //Then
        var task = taskService.Tasks.First(t => t.Id == id);
        Assert.AreEqual(true, task.IsDone);
    }

    [Test]
    public void SetTaskStatus_DoWithUnExistingId_ThrowsException()
    {
        //Given
        var id = 999;

        //When & Then
        Assert.Throws<ArgumentException>(() => taskService.SetTaskStatus(id, true));
    }

    [Test]
    public void SetTaskStatus_UndoWithExistingId_TaskIsNotDone()
    {
        //Given
        string name = "Learn Java";
        var id = taskService.AddTask(name).Id;

        //When
        taskService.SetTaskStatus(id, false);

        //Then
        var task = taskService.Tasks.First(t => t.Id == id);
        Assert.AreEqual(false, task.IsDone);
    }
}