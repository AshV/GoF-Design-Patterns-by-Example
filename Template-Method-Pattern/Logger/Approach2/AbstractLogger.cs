using static System.Console;

public abstract class AbstractLogger
{
    protected string SerializeMessage(object message) {
        WriteLine("Serializing message");
        return message.ToString();
    }
}