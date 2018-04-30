using static System.Console;

public class DatabaseLogger
{
    public void Log(string message) {
        string messageToLog = SerializeMessage(message);
        ConnectToDatabase();
        InsertLogMessageToTable(messageToLog);
        CloseDbConnection();
    }

    private string SerializeMessage(object message) {
        WriteLine("Serializing message");
        return message.ToString();
    }

    private void ConnectToDatabase() {
        WriteLine("Connecting to Database.");
    }

    private void InsertLogMessageToTable(string message) {
        WriteLine("Inserting Log Message to DB table : " + message);
    }

    private void CloseDbConnection() {
        WriteLine("Closing DB connection.");
    }
}