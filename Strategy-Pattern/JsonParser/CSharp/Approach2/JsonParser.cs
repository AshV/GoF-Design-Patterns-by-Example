public abstract class JsonParser {
    public string JsonData;

    public JsonParser(string jsonData) {
        JsonData = jsonData;
    }

    public abstract object Parse();
}