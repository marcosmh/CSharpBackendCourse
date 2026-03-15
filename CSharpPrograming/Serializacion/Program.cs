using System.Text.Json;


var anakin = new People()
{
    Name = "Anakin",
    Age = 40
};

People.Get();

string json = JsonSerializer.Serialize(anakin);

Console.WriteLine(json);

string myJson = @"{
  ""Name"":""Luke"",
  ""Age"":20
}";

People? luke = JsonSerializer.Deserialize<People>(myJson);
Console.WriteLine(luke?.Name + " "+luke?.Age);


public class People
{

    public string Name { get; set; }

    public int Age { get; set; }

    public static string Get() => "Que la Fuerza te acompañe";

}