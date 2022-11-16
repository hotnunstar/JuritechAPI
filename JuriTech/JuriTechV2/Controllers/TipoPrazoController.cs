#nullable disable
namespace JuriTechV2.Controllers
{
    /* TERMINADO
     * GetTiposPrazo - Consultar tipos de prazo existentes ( Procedimental | Caducidade | Processual | Prescrição)
     */

    [Route("api/[controller]")]
    [ApiController]
    public class TipoPrazoController : ControllerBase
    {
        private readonly Contexto _context;

        public TipoPrazoController(Contexto context)
        {
            _context = context;
        }

        #region Consultar tipos de prazo
        // GET: api/TipoPrazo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPrazo>>> GetTiposPrazo()
        {
            return await _context.TipoPrazo.ToListAsync();
        }
        #endregion
    }
}
