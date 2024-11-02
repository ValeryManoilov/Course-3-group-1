using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Net.Http.Json;
using System.Net.Http;
using System;

namespace WebApplicationAsync.Controllers
{
    public class AsyncController : ControllerBase
    {
        private readonly HttpClient _client;

        public AsyncController(HttpClient client)
        {
            _client = client;
        }


        [HttpGet]
        [Route("api")]
        public async Task<IActionResult> GetTypicodeInfoAsync(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);

            return Ok(await response.Content.ReadAsStringAsync());

        }

        //[HttpGet]
        //[Route("api/catfacts")]
        //public async Task<IActionResult> GetCatFactsInfoAsync()
        //{
        //    HttpResponseMessage response = await _client.GetAsync("https://catfact.ninja/fact");


        //    return Ok(await response.Content.ReadAsStringAsync());

        //}

        //[HttpGet]
        //[Route("api/jokes")]
        //public async Task<IActionResult> GetJokesInfoAsync()
        //{
        //    HttpResponseMessage response = await _client.GetAsync("https://v2.jokeapi.dev/joke/Any");

        //    return Ok(await response.Content.ReadAsStringAsync());

        //}
    }
}
