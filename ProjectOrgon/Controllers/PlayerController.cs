using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectOrgon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [Route("GenerateName")]
        [HttpGet]
        public ActionResult<string> GenerateName()
        {
            return Ok(OrgonClass.Player.nameGenerator());
        }
    }
}
