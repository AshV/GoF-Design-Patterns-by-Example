class MainClass {
    static void Main(string[] args) {
        var jsonParser = new JsonParser("{ 'temp' : '38' }");
        var parsedData = jsonParser.Parse();
    }
}