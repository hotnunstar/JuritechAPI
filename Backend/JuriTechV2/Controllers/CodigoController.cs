#nullable disable
namespace JuriTechV2.Controllers
{
    /* TERMINADO
     * GetCodigos - Consultar a lista de códigos existentes (Procedimento administrativo | Processo civil | Processo penal | Regime IMOS)
     */

    [Route("api/[controller]")]
    [ApiController]
    public class CodigoController : ControllerBase
    {
        private readonly Contexto _context;

        public CodigoController(Contexto context)
        {
            _context = context;
        }

        #region Consultar Códigos de Processo
        // GET: api/Codigo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Codigo>>> GetCodigos()
        {
            var itens = await _context.Codigo.ToListAsync();
            return Ok(itens);
        }
        #endregion
    }

}
