using static System.Console;

public class EmailLogger : AbstractLogger
{
    protected override void OpenDataStoreOperation() {
        WriteLine("Connecting to mail server and logging in");
    }

    protected override void LogMessage(string messageToLog) {
        WriteLine("Sending Email with Log Message : " + messageToLog);
    }

    protected override void CloseDataStoreOpreation() {
        WriteLine("Dispose Connection");
    }
}