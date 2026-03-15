
var names = new List<string>()
{
    "Anakin","Him","Luke","Yoda","Mace","Obi Wan"
};

var namesResult = from n in names
                  where n.Length > 3 && n.Length < 4
                  orderby n descending
                  select n;

var namesResult2 = names.Where(n => n.Length > 3 && n.Length < 4)
    .OrderByDescending(n => n)
    .Select(d => d);

foreach( var name in namesResult)
{
    Console.WriteLine(name);
}

foreach (var name in namesResult2)
{
    Console.WriteLine(name);
}