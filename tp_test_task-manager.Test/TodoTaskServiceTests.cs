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
        taskService.AddTask(name);

        //Then
        var task = taskService.Tasks.First(t => t.Id == 1);
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
        taskService.AddTask(name);
        taskService.AddTask(name2);

        //Then
        var task = taskService.Tasks.First(t => t.Id == 1);
        Assert.AreEqual(1, task.Id);
        var task2 = taskService.Tasks.First(t => t.Id == 2);
        Assert.AreEqual(2, task2.Id);
    }

    [Test]
    public void AddTask_WithSeveralTasks_InsertMultipleTasks()
    {
        //Given
        string name = "Learn C#";
        string name2 = "Learn Java";

        //When
        taskService.AddTask(name);
        taskService.AddTask(name2);

        //Then
        Assert.AreEqual(2, taskService.Tasks.Count);
    }

    [Test]
    public void RemoveTask_WithExistingId_RemoveTask()
    {
        //Given
        string name = "Learn Java";
        taskService.AddTask(name);

        //When
        taskService.RemoveTask(1);

        //Then
        Assert.AreEqual(0, taskService.Tasks.Count);
    }

    [Test]
    public void SetTaskStatus_DoWithExistingId_TaskIsDone()
    {
        //Given
        string name = "Learn Java";
        taskService.AddTask(name);

        //When
        taskService.SetTaskStatus(1, true);

        //Then
        var task = taskService.Tasks.First(t => t.Id == 1);
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
        taskService.AddTask(name);

        //When
        taskService.SetTaskStatus(1, false);

        //Then
        var task = taskService.Tasks.First(t => t.Id == 1);
        Assert.AreEqual(false, task.IsDone);
    }

    [Test]
    public void SetTaskStatus_UndoWithUnExistingId_ThrowsException()
    {
        //Given
        var id = 999;

        //When & Then
        Assert.Throws<ArgumentException>(() => taskService.SetTaskStatus(id, false));
    }
}