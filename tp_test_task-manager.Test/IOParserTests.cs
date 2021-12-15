using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace tp_test_task_manager.Test;

public class IOParserTests
{
    private IOParser ioParser;
    private ITodoTaskService taskService;

    [SetUp]
    public void SetUp()
    {
        taskService = new TodoTaskService();
    }

    [Test]
    public async Task Run_HandleQuitCommand_QuitProgram()
    {
        //Given
        var inputs = new Queue<string>();
        inputs.Enqueue("q");
        var fakeIO = new FakeIO(inputs);
        ioParser = new IOParser(fakeIO, taskService);

        //When
        await ioParser.Run();

        //Then
        Assert.AreEqual(true, fakeIO.HandleExitCalled);
    }

    [Test]
    public async Task Run_HandleCreation_CreateTask()
    {
        //Given
        var inputs = new Queue<string>();
        var taskName = "Learn C#";
        inputs.Enqueue($"+ {taskName}");
        inputs.Enqueue($"q");
        var fakeIO = new FakeIO(inputs);
        ioParser = new IOParser(fakeIO, taskService);

        //When
        await ioParser.Run();

        //Then
        Assert.AreEqual(1, taskService.Tasks.Count);
        var task = taskService.Tasks.First(t => t.Id == 1);
        Assert.AreEqual(taskName, task.Name);
        Assert.AreEqual(1, fakeIO.Output.Count);
        Assert.AreEqual($"1 [ ] {taskName}", fakeIO.Output[0]);
    }

    [Test]
    public async Task Run_HandleSeveralCreations_CreateTasks()
    {
        //Given
        var inputs = new Queue<string>();
        var taskName = "Learn C#";
        var taskName2 = "Learn Java";
        var taskName3 = "Learn Python";
        inputs.Enqueue($"+ {taskName}");
        inputs.Enqueue($"+ {taskName2}");
        inputs.Enqueue($"+ {taskName3}");
        inputs.Enqueue($"q");
        var fakeIO = new FakeIO(inputs);
        ioParser = new IOParser(fakeIO, taskService);

        //When
        await ioParser.Run();

        //Then
        Assert.AreEqual(3, taskService.Tasks.Count);
        Assert.AreEqual(6, fakeIO.Output.Count);
        Assert.AreEqual($"1 [ ] {taskName}", fakeIO.Output[0]);
        Assert.AreEqual($"1 [ ] {taskName}", fakeIO.Output[1]);
        Assert.AreEqual($"2 [ ] {taskName2}", fakeIO.Output[2]);
        Assert.AreEqual($"1 [ ] {taskName}", fakeIO.Output[3]);
        Assert.AreEqual($"2 [ ] {taskName2}", fakeIO.Output[4]);
        Assert.AreEqual($"3 [ ] {taskName3}", fakeIO.Output[5]);
    }

    [Test]
    public async Task Run_HandleDeletion_DeleteTask()
    {
        //Given
        var inputs = new Queue<string>();
        var taskName = "Learn C#";
        taskService.AddTask(taskName);
        inputs.Enqueue($"- 1");
        inputs.Enqueue($"q");
        var fakeIO = new FakeIO(inputs);
        ioParser = new IOParser(fakeIO, taskService);

        //When
        await ioParser.Run();

        //Then
        Assert.AreEqual(0, taskService.Tasks.Count);
        Assert.AreEqual(0, fakeIO.Output.Count);
    }

    [Test]
    public async Task Run_HandleDoTask_DoTask()
    {
        //Given
        var inputs = new Queue<string>();
        var taskName = "Learn C#";
        taskService.AddTask(taskName);
        inputs.Enqueue($"x 1");
        inputs.Enqueue($"q");
        var fakeIO = new FakeIO(inputs);
        ioParser = new IOParser(fakeIO, taskService);

        //When
        await ioParser.Run();

        //Then
        Assert.AreEqual(1, fakeIO.Output.Count);
        Assert.AreEqual($"1 [x] {taskName}", fakeIO.Output[0]);
    }

    [Test]
    public async Task Run_HandleUndoTask_UndoTask()
    {
        //Given
        var inputs = new Queue<string>();
        var taskName = "Learn C#";
        taskService.AddTask(taskName);
        taskService.SetTaskStatus(1, true);
        inputs.Enqueue($"o 1");
        inputs.Enqueue($"q");
        var fakeIO = new FakeIO(inputs);
        ioParser = new IOParser(fakeIO, taskService);

        //When
        await ioParser.Run();

        //Then
        Assert.AreEqual(1, fakeIO.Output.Count);
        Assert.AreEqual($"1 [ ] {taskName}", fakeIO.Output[0]);
    }
}