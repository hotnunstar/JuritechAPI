#nullable disable
namespace JuriTechV2.Controllers
{
    /* TERMINADO
     * GetPrazosCodigos - Consultar a lista de prazos pertencentes aos códigos 
     * 
     * Ligações existentes:
     * Prazo Procedimental - Código Procedimento Administrativo 
     * Prazo Caducidade - Código Processo Civil && Código Processo Penal
     * Prazo Processual - Código Processo Civil && Código Processo Penal
     * Prazo Prescrição - Código Processo Civil && Código Processo Penal && RIMOS
     */

    [Route("api/[controller]")]
    [ApiController]
    public class PrazoCodigoController : ControllerBase
    {
        private readonly Contexto _context;

        public PrazoCodigoController(Contexto context)
        {
            _context = context;
        }

        #region Consultar Prazos dos Códigos
        // GET: api/PrazoCodigo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrazoCodigo>>> GetPrazosCodigos()
        {
            return await _context.PrazoCodigo.ToListAsync();
        }
        #endregion
    }
}
