namespace tp_test_task_manager;

public class IOParser
{
    private readonly IO io;
    private readonly ITodoTaskService todoTaskService;

    public IOParser(IO io, ITodoTaskService todoTaskService)
    {
        this.io = io;
        this.todoTaskService = todoTaskService;
    }

    public async Task Run()
    {
        var qBreak = false;
        while (!qBreak)
        {
            var line = await io.GetInputStringAsync();
            var tokens = line.Split(" ");
            switch (tokens[0])
            {
                case "q":
                    await io.HandleExitAsync();
                    qBreak = true;
                    break;
                default:
                    break;
            }
        }
    }
}