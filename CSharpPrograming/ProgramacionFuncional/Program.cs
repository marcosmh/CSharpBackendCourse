Console.WriteLine(Sub(2, 1));

Console.WriteLine("**********************");

DateTime GetTomorrow(DateTime date)
{
    return date.AddDays(1);
}

DateTime date = DateTime.Now;
Console.WriteLine(GetTomorrow(date));

Console.WriteLine("**********************");

var beer = new Beer()
{
    Name = "guinness"
};

Console.WriteLine(ToUpper(beer).Name);
Console.WriteLine(beer.Name);

Console.WriteLine("**********************");

// Funcion de primera clase
var show = Show;
//show("HolaX");

var show2 = Show2;

// funcion de orden superior
Some(show, "Hola como estas");
Some2(show2, "Hola como estas");



void Show(string message)
{
    Console.WriteLine(message);
}

string Show2(string message)
{
    return message.ToUpper();
}



// Action recibe elementos
// pero no retorna nada
void Some(Action<string>fn, string message)
{
    Console.WriteLine("Hace algo al inicio");
    fn(message);
    Console.WriteLine("Hace algo al final");

}

void Some2(Func<string, string> fn, string message)
{
    Console.WriteLine("++++++++++++++++++++++");
    Console.WriteLine("Hace algo al inicio");
    Console.WriteLine(fn(message));
    Console.WriteLine("Hace algo al final");
    Console.WriteLine("++++++++++++++++++++++");

}



Console.WriteLine("**********************");



// Funcion Pura
int Sub(int a, int b)
{
    return a - b;
}


Beer ToUpper(Beer beer)
{
    var beer2 = new Beer()
    {
        Name = beer.Name.ToUpper()
    };
    return beer2;
}


class Beer
{
    public string Name { get; set; }

}



