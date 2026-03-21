using System;
namespace BackendCSharp.DTOs
{
	public class BeerUpdateDTO
	{

        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }

        public decimal Alcohol { get; set; }

    }
}

