using brk.Framework.Base.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace brk.Endpoints.WebApi.Controllers.v1.Base
{
    [ApiController]
    [Route("/api/[controller]")]
    public abstract class BaseApiController : BaseController
    {
    }
}
