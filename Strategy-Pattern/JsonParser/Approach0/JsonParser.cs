using static System.Console;

class JsonParser {
    private string JsonData { get; set; }
    public JsonParser(string jsonData) {
        JsonData = jsonData;
    }

    public object Parse() {
        WriteLine("Parsing Json Data");
        // Parsing Logic
        return new { ParsedData = JsonData };
    }
}