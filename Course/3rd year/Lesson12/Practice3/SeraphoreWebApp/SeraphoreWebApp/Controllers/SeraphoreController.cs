using Microsoft.AspNetCore.Mvc;

namespace SeraphoreWebApp.Controllers
{
    [ApiController]
    public class SeraphoreController : Controller
    {
        SemaphoreSlim semaphore = new SemaphoreSlim(2, 2);

        [HttpPost]
        [Route("/write/{newString}")]
        public async Task<IActionResult> AddNewString(string newString)
        {
            try
            {
                semaphore.Wait();

                string path = "data.txt";
                string data;
                if (!String.IsNullOrWhiteSpace(newString))
                {
                    using (var stream = new StreamWriter(path, true))
                    {
                        await stream.WriteLineAsync(newString);
                    }
                    using (var stream = new StreamReader(path, true))
                    {
                        data = await stream.ReadToEndAsync();
                    }

                    return Ok(data);
                }
                return BadRequest("Ошибка: ввод пустой строки невозможен");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка: {ex.Message}");
            }
            finally 
            { 
                semaphore.Release(); 
            }
        }
    }
}
