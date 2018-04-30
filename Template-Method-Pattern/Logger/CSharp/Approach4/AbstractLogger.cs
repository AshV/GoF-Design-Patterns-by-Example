using static System.Console;

public abstract class AbstractLogger
{
    public bool ConsoleLogging { get; set; }

    protected string SerializeMessage(object message) {
        WriteLine("Serializing message");
        return message.ToString();
    }

    protected abstract void OpenDataStoreOperation();

    protected abstract void LogMessage(string messageToLog);

    protected abstract void CloseDataStoreOpreation();

    protected virtual void LogToConsole(string messageToLog) {
        WriteLine("Writing in Console : " + messageToLog);
    }

    public void Log(object message) {
        string messageToLog = SerializeMessage(message);
        OpenDataStoreOperation();
        LogMessage(messageToLog);
        CloseDataStoreOpreation();
        if (ConsoleLogging) {
            LogToConsole(messageToLog);
        }
    }
}