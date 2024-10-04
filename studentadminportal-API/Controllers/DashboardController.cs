using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal_API.Helpers;

namespace studentadminportal_API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [AuthorizeAttribute]
    public class DashboardController : BaseApiController
    {

    }
}
