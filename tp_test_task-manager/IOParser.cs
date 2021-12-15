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
            var operand = line.ToCharArray()[0];
            int id = 0;
            switch (operand)
            {
                case '+':
                    var taskName = line.Substring(2);
                    todoTaskService.AddTask(taskName);
                    DisplayTasks();
                    break;
                case '-':
                    id = Int32.Parse(line.Substring(2));
                    todoTaskService.RemoveTask(id);
                    DisplayTasks();
                    break;
                case 'x':
                case 'o':
                    id = Int32.Parse(line.Substring(2));
                    todoTaskService.SetTaskStatus(id, operand == 'x');
                    DisplayTasks();
                    break;
                case 'q':
                    await io.HandleExitAsync();
                    qBreak = true;
                    break;
                default:
                    throw new ArgumentException($"Operand {operand} is invalid");
            }
        }
    }

    private void DisplayTasks()
    {
        todoTaskService.Tasks.ToList().ForEach(async task => await io.OutPutStringAsync($"{task.Id} [{(task.IsDone ? 'x': ' ')}] {task.Name}"));
    }
}