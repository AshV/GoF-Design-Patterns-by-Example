using static System.Console;

class BlogDataParser : JsonParser {
    public BlogDataParser(string jsonData) : base(jsonData) {
    }

    public override object Parse() {
        WriteLine("Parsing Blog Json Data");
        // Logic optimized for parsing Blog Data
        return new { ParsedData = JsonData };
    }
}