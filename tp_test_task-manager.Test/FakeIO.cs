using System.Collections.Generic;
using System.Threading.Tasks;

namespace tp_test_task_manager.Test;

public class FakeIO : IO
{
    private readonly List<string> outputtedStrings;
    private readonly Queue<string> stringsToInput;

    public IReadOnlyList<string> Output => outputtedStrings.AsReadOnly();

    public bool HandleExitCalled { get; private set; }

    public FakeIO(Queue<string> stringsToInput)
    {
        this.stringsToInput = stringsToInput;
        this.outputtedStrings = new List<string>();
    }

    public FakeIO()
    {
        this.stringsToInput = new Queue<string>();
        this.outputtedStrings = new List<string>();
    }

    public Task OutPutStringAsync(string outPut)
    {
        outputtedStrings.Add(outPut);
        return Task.CompletedTask;
    }

    public Task<string> GetInputStringAsync()
    {
        return Task.FromResult(this.stringsToInput.Dequeue());
    }

    public Task HandleExitAsync()
    {
        this.HandleExitCalled = true;
        return Task.CompletedTask;
    }

}