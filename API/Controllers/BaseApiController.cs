using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract  class BaseApiController : ControllerBase
    {
        protected readonly DataContext _context;        

        protected BaseApiController(DataContext context)
        {
            _context = context;
        }
    }
}
