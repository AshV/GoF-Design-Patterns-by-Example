using static System.Console;

public class DatabaseLogger : AbstractLogger
{
    protected override void OpenDataStoreOperation() {
        WriteLine("Connecting to Database.");
    }

    protected override void LogMessage(string messageToLog) {
        WriteLine("Inserting Log Message to DB table : " + messageToLog);
    }

    protected override void CloseDataStoreOpreation() {
        WriteLine("Closing DB connection.");
    }
}