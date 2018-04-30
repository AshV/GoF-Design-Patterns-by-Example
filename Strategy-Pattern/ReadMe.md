# Strategy Design Pattern by Example

![Strategy-Design-Pattern-by-Example](assets/Strategy-Design-Pattern-by-Example.jpeg)

To accomplish same type of task, different people might follow different strategies/approaches, one strategy could work best for one case whether another could prove best for other scenario.

 Let's take a real world example, In your office building your workstation is on first floor while your colleague has on 7th. Both of you are in hurry to reach their workstation(i.e same task), but if both of you take lift or take stairs(i.e follows same approach) will not be the best strategy. If you take stairs to reach 1st floor and your colleague takes lift to reach 7th floor(i.e different strategies) then this will be the best approach by both of you.

 In above scenario you can observe that problem is same but based on other parameters same approach will not prove best in every case. In our day to day code we face similar kind of problem, here **Strategy Design Pattern** comes to rescue, name itself suggests that it's about making strategies, it falls under behavioral design patterns.

### Code Example: JSON Parser

JSON is most popular data exchange format today, suppose there is one system which needs to parse JSON data coming from various sources. This system was working fine, until dev team realized that though all data is in JSON format but there's variety of data like, weather sensor data which has mostly numeric value, blog articles which has large text blocks, chat conversations which has smaller text blocks with emozis. Dev team sees opportunity to optimize the performance of system using different parser according to source of data. Let's see how they addressed the problem and refactored towards maintainable code.

Below is how our initial code looks like.

> Source Code : [Strategy Pattern / JsonParser / Approach0](/Strategy-Pattern/JsonParser/CSharp/Approach0)

```csharp
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

class MainClass {
    static void Main(string[] args) {
        var jsonParser = new JsonParser("{ 'temp' : '38' }");
        var parsedData = jsonParser.Parse();
    }
}
```

> Example are written in C#, but easily understandable for anyone who knows basic OOPS concept.

### Approach 1 : Seprate method for each parser 

For each type of parser, seprate methods are created in JsonParser Class. Inside Parse(), according to Source of data passed appropriate method in called.

> Source Code : [Strategy Pattern / JsonParser / Approach1](/Strategy-Pattern/JsonParser/CSharp/Approach1)

```csharp
class JsonParser {
    private string JsonData { get; set; }

    public JsonParser(string jsonData) {
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

class MainClass {
    static void Main(string[] args) {
        var jsonParser = new JsonParser("{ 'temp' : '38' }");
        var parsedData = jsonParser.Parse("sensor");
    }
}
```

#### Reviewing approach 1

Single class has multiple responsibilities, for adding a new parser, JsonParser class and Parse() has to be modified, Which is not a good practice.

### Approach 2 : Moving parsing logic to Child Classes

JsonParser class in made abstract with abstract Parse(), SensorDataParser and BlogDataParser are implementing Parse(). While consuming user can decide which Parser object to initialize.

> Source Code : [Strategy Pattern / JsonParser / Approach2](/Strategy-Pattern/JsonParser/CSharp/Approach2)

```csharp
public abstract class JsonParser {
    public string JsonData;

    public JsonParser(string jsonData) {
        JsonData = jsonData;
    }

    public abstract object Parse();
}

class SensorDataParser : JsonParser {
    public SensorDataParser(string jsonData) : base(jsonData) {
    }

    public override object Parse() {
        WriteLine("Parsing Sensor Json Data");
        // Logic optimized for parsing Sensor Data
        return new { ParsedData = JsonData };
    }
}

class BlogDataParser : JsonParser {
    public BlogDataParser(string jsonData) : base(jsonData) {
    }

    public override object Parse() {
        WriteLine("Parsing Blog Json Data");
        // Logic optimized for parsing Blog Data
        return new { ParsedData = JsonData };
    }
}

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
```

#### Reviewing approach 2

Parsing logic is tightly coupled with parser class and for each type we need to write whole parser class while we require to write only logic not whole class, it can be made more pluggable.

### Approach 3 : Making more pluggable with interface

Instead of making `JsonParser` class abstract we will have a proprty of type `IJsonParseLogic`, classes implementing this interface can be passed before calling Parse(). Here you can see `BlogDataParseLogic` & `SensorDataParseLogic` have implemented `IJsonParseLogic` and their object is set in `JsonParseLogic` in Main().

> Source Code : [Strategy Pattern / JsonParser / Approach3](/Strategy-Pattern/JsonParser/CSharp/Approach3)

```csharp
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

interface IJsonParseLogic {
    object Parse(string jsonData);
}

class BlogDataParseLogic : IJsonParseLogic {
    public object Parse(string jsonData) {
        WriteLine("Parsing Blog Json Data");
        // Logic optimized for parsing Blog Data
        return new { ParsedData = jsonData };
    }
}

class SensorDataParseLogic : IJsonParseLogic {
    public object Parse(string jsonData) {
        WriteLine("Parsing Sensor Json Data");
        // Logic optimized for parsing Sensor Data
        return new { ParsedData = jsonData };
    }
}

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
```

## Conclusion

As you can see in approach 3 algo/logic is decoupled, which makes code more maintainable. In scenarios like this Startegy pattern can be used.

> Complete Source Code : [Strategy Pattern / JsonParser](/Strategy-Pattern/JsonParser/)

> Thanks for reading, let the discussions/suggestions/queries go in comments.