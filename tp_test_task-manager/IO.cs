namespace tp_test_task_manager;

public interface IO
{
    Task OutPutStringAsync(string outPut);
    Task<string> GetInputStringAsync();
    Task HandleExitAsync();
}