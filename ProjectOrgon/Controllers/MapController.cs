using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrgonClass;

namespace ProjectOrgon.Controllers
{
    /// <summary>
    /// Controlador del mapa
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {

        /// <summary>
        /// Genera un mapa
        /// </summary>
        /// <param name="w">ancho del mapa</param>
        /// <param name="h">alto del mapa</param>
        /// <returns>retorno true siempre porque si</returns>
        [Route("Generate/{w}/{h}/{i}/{isz}")]
        [HttpGet]
        public ActionResult<Map> Generate(int w, int h, int i, int isz)
        {
            Map M = OrgonPrimary.GenerateMap(w, h, i, isz);
            return Ok(M);
        }
        /// <summary>
        /// Obtiene una parte del mapa (no esta implementado aun)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [Route("Get/{x}/{y}")]
        [HttpGet]
        public ActionResult<List<List<Room>>> Get(int x, int y) 
        {
            return Ok(OrgonPrimary.GetMap());
        }

       
        /// <summary>
        /// borra el mapa
        /// </summary>
        /// <returns></returns>
        [Route("Delete")]
        [HttpGet]
        public ActionResult<bool> Delete()
        {
            OrgonPrimary.DeleteMap();
            return Ok(true);
        }



    }
}
