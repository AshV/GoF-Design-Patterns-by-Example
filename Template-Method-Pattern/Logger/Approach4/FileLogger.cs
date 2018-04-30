using static System.Console;

public class FileLogger : AbstractLogger
{
    protected override void OpenDataStoreOperation() {
        WriteLine("Opening File.");
    }

    protected override void LogMessage(string messageToLog) {
        WriteLine("Appending Log message to file : " + messageToLog);
    }

    protected override void CloseDataStoreOpreation() {
        WriteLine("Close File.");
    }
}