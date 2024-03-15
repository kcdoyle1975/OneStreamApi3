using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi3.Controllers
{
    [Route("api/superman/runner")]
    [ApiController]
    public class SupermanRunnerController : ControllerBase
    {
        private IMemoryCache _cache;

        public SupermanRunnerController(IMemoryCache cache)
        {
            _cache = cache;
        }

        // GET: api/<RunnerController>
        [HttpGet]
        public long Get()
        {
            if (!_cache.TryGetValue(true, out int delay))
            {
                delay = 0;
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < 100; i++)
            {
                Task.Delay(delay).Wait();
            }
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        // GET api/<RunnerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RunnerController>
        [HttpPost]
        public void Post([FromBody] int delay)
        {
            //if (_cache.TryGetValue(true, out string data))
            //{
            //    return data;
            //}
            _cache.Set<int>(true, delay);
        }

        // PUT api/<RunnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RunnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
