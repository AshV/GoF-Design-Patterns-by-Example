using static System.Console;

class SensorDataParseLogic : IJsonParseLogic {
    public object Parse(string jsonData) {
        WriteLine("Parsing Sensor Json Data");
        // Logic optimized for parsing Sensor Data
        return new { ParsedData = jsonData };
    }
}