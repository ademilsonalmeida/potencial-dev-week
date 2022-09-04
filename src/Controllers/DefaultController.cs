using dev_week.src.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace dev_week.src.Controllers
{       
    [ApiController]
    [Route("api")]
    public class DefaultController : ControllerBase
    {
        protected readonly DataContext _context; 

        public DefaultController(DataContext context)
        {
            _context = context;
        }
    }
}