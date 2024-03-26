using Microsoft.AspNetCore.Mvc;
using UMBIT.MicroService.Template.Contract;

namespace UMBIT.MicroService.Template.API.Controllers
{
    public class HelloWorldController : HelloWorldControllerBase
    {
        public async override Task<ActionResult<HelloWorldString>> GetHelloWorld()
        {
            return new HelloWorldString()
            {
                Summary = "Hello",
            };
        }
    }
}
