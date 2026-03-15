//Sale sale = new Sale();

var sale = new SaleWithTask(16,1.16m);
var message = sale.GetInfo();

Console.WriteLine(message);





class SaleWithTask : Sale
{
    public decimal Tax { get; set;  }

    public SaleWithTask(decimal total, decimal tax) : base(total)
    {
        Tax = tax;
    }

    public override string GetInfo()
    {
        return "El total es " + Total +  " Impuesto es : " + Tax;
    }

    public string GetInfo(string message)
    {
        return message;
    }

    public string GetInfo(int a)
    {
        return a.ToString();
    }
}



class Sale
{
    public decimal Total { get; set; }

    public Sale(decimal total)
    {
        Total = total;
    }

    public virtual string GetInfo()
    {
        return "El total es " + Total;
    }
}