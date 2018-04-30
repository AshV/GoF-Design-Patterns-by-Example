using static System.Console;

class SensorDataParser : JsonParser {
    public SensorDataParser(string jsonData) : base(jsonData) {
    }

    public override object Parse() {
        WriteLine("Parsing Sensor Json Data");
        // Logic optimized for parsing Sensor Data
        return new { ParsedData = JsonData };
    }
}