class MainClass {
    static void Main(string[] args) {
        JsonParser jsonParser = new SensorDataParser(
            "{ 'temp' : '38' }");
        var parsedData = jsonParser.Parse();

        jsonParser = new SensorDataParser(
            "{ 'title' : 'Strategy Design Pattern by Example' }");
        parsedData = jsonParser.Parse();
    }
}