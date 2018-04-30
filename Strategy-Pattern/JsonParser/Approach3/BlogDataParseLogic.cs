using static System.Console;

class BlogDataParseLogic : IJsonParseLogic {
    public object Parse(string jsonData) {
        WriteLine("Parsing Blog Json Data");
        // Logic optimized for parsing Blog Data
        return new { ParsedData = jsonData };
    }
}