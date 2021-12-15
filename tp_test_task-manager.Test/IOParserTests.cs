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
}