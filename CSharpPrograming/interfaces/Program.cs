

var sale = new SSale();
var beer = new Beer();

Some(sale);
Some(beer);


void Some(ISave save)
{
    save.Save();
}

interface ISale
{
    decimal Total { get; set; }
}

interface ISave
{
    public void Save();
}

public class SSale : ISale, ISave
{

    public decimal Total { get; set; }

    public void Save()
    {
        Console.WriteLine("Se guardo en BD");
    }
}

public class Beer : ISave
{
    public void Save()
    {
        Console.WriteLine("Se guardo en Servicio");
    }
}


