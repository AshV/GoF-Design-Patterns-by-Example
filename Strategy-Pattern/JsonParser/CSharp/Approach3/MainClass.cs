class MainClass {
    static void Main(string[] args) {
        JsonParser jsonParser = new JsonParser(
            "{ 'temp' : '38' }");
        jsonParser.JsonParseLogic = new SensorDataParseLogic();
        var parsedData = jsonParser.Parse();

        jsonParser = new JsonParser(
            "{ 'title' : 'Strategy Design Pattern by Example' }");
        jsonParser.JsonParseLogic = new BlogDataParseLogic();
        parsedData = jsonParser.Parse();
    }
}