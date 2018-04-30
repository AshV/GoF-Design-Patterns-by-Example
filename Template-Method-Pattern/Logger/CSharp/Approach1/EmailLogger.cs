using static System.Console;

public class EmailLogger
{
    public void Log(object message) {
        string messageToLog = SerializeMessage(message);
        ConnectToMailServer();
        SendLogToEmail(messageToLog);
        DisposeConnection();
    }

    private string SerializeMessage(object message) {
        WriteLine("Serializing message");
        return message.ToString();
    }

    private void ConnectToMailServer() {
        WriteLine("Connecting to mail server and logging in");
    }

    private void SendLogToEmail(string message) {
        WriteLine("Sending Email with Log Message : " + message);
    }

    private void DisposeConnection() {
        WriteLine("Dispose Connection");
    }
}