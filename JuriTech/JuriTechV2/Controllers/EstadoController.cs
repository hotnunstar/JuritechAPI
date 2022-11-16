#nullable disable
namespace JuriTechV2.Controllers
{
    /* TERMINADO
     * GetEstados - Consultar a lista de estados existentes (Fase articulados | Fase instrução | Fase decisória)
     */

    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly Contexto _context;

        public EstadoController(Contexto context)
        {
            _context = context;
        }

        #region Consultar Estados de Processo
        // GET: api/Estado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
            return await _context.Estado.ToListAsync();
        }
        #endregion
    }
}
