class JsonParser {
    public IJsonParseLogic JsonParseLogic { get; set; }
    private string JsonData { get; set; }

    public JsonParser(string jsonData) {
        JsonData = jsonData;
    }

    public object Parse() {
        return JsonParseLogic.Parse(JsonData);
    }
}