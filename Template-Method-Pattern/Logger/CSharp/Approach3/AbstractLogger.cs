using static System.Console;

public abstract class AbstractLogger
{
    protected string SerializeMessage(object message) {
        WriteLine("Serializing message");
        return message.ToString();
    }

    protected abstract void OpenDataStoreOperation();

    protected abstract void LogMessage(string messageToLog);

    protected abstract void CloseDataStoreOpreation();

    public void Log(object message) {
        string messageToLog = SerializeMessage(message);
        OpenDataStoreOperation();
        LogMessage(messageToLog);
        CloseDataStoreOpreation();
    }
}