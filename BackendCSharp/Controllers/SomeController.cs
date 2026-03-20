
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;




namespace BackendCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();


            Thread.Sleep(1000);
            Console.WriteLine("Conexion a base de datos conectada.");

            Thread.Sleep(1000);
            Console.WriteLine("Envio de mail terminado.");

            Console.WriteLine("Todo ha terminado");

            stopwatch.Stop();

            return Ok(stopwatch.Elapsed);
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Conexion de base datos terminada.");
                return 1;
            });

            var task2 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envío de Email terminado.");
                return 2;
            });

            task1.Start();
            task2.Start();

            Console.WriteLine("Hago otro cosa");

            var result = await task1;
            var result2 = await task2;

            Console.WriteLine("Todo ha terminado");

            stopwatch.Stop();

            return Ok(result + " --- " + result2 +" --- "+ stopwatch.Elapsed);
        }
    }
}

