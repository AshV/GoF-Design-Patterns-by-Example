using System;
using static System.Console;

class JsonParser {
    private string JsonData { get; set; }

    public JsonParser( string jsonData) {
        JsonData = jsonData;
    }

    private object ParseSensorData() {
        WriteLine("Parsing Sensor Json Data");
        // Logic optimized for parsing Sensor Data
        return new { ParsedData = JsonData };
    }

    private object ParseBlogData() {
        WriteLine("Parsing Blog Json Data");
        // Logic optimized for parsing Blog Data
        return new { ParsedData = JsonData };
    }


    public object Parse(string source) {
        switch (source) {
            case "sensor":
                return ParseSensorData();
            case "blog":
                return ParseBlogData();
            default:
                throw new Exception("parser not available for given type.");
        }
    }
}