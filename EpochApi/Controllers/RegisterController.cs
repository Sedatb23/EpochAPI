using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using EpochApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpochApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]/[action]")]
    public class RegisterController : BaseController
    {
        private RegisterService _registerService;

        public RegisterController([FromServices] DbContexts.AccountDbContext context)
        { 
            _registerService = new Services.RegisterService(context);
        }

        [HttpPost]
        public async Task<object> DoRegister([FromServices] IHttpContextAccessor accessor, Models.Account account)
        {
            //await Task.Delay(1);
            if (ModelState.IsValid == false) {
                return new
                {
                    success = ModelState.IsValid,
                    errors = GetModelErrors()
                };

            }

            var accountExists = _registerService.AccountExists(account.Name);

            if(accountExists)
            {
                ModelState.AddModelError("Username", "Pick another username!"); 

                return new
                {
                    success = false,
                    errors = GetModelErrors()
                };
            } 
            account.IP = accessor.HttpContext.Connection.RemoteIpAddress.ToString();

            await _registerService.SaveAccount(account);

            return new { success = true };
        }  
    }
}
