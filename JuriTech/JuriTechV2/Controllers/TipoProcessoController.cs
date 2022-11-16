#nullable disable
namespace JuriTechV2.Controllers
{
    /* TERMINADO
     * PostTipoProcesso - Inserir tipo de processo (by UserID)
     * PutTipoProcesso - Editar tipo de processo (by UserID)
     * GetTiposProcesso - Consultar tipos de processo (by UserID)
     */

    [Route("api/[controller]")]
    [ApiController]
    public class TipoProcessoController : ControllerBase
    {
        private readonly Contexto _context;

        public TipoProcessoController(Contexto context)
        {
            _context = context;
        }

        #region verbos
        #region Inserir tipo de processo (by UserID)
        // POST: api/TipoProcesso
        [HttpPost("{IdUtilizador}")]
        public async Task<ActionResult<TipoProcesso>> PostTipoProcesso(TipoProcesso tipoProcesso, int IdUtilizador)
        {
            tipoProcesso.IdUtilizador = IdUtilizador;

            if (VerificaNulo(tipoProcesso.Nome)) return BadRequest("Inserir Tipo Processo");

            if (NomeExists(tipoProcesso.Nome, IdUtilizador) && IdTemaExists(tipoProcesso.IdTema, IdUtilizador)) return BadRequest("Tipo Processo já registado");
            else
            {
                _context.TipoProcesso.Add(tipoProcesso);
                await _context.SaveChangesAsync();
                return Ok(tipoProcesso);
            }
        }
        #endregion

        #region Editar tipo de processo (by UserID)
        // PUT: api/TipoProcesso/5
        [HttpPut("{IdUtilizador}/{IdTipoProcesso}")]
        public async Task<IActionResult> PutTipoProcesso(int IdUtilizador, int IdTipoProcesso, TipoProcesso tipoProcesso)
        {
            var aux = _context.TipoProcesso.AsNoTracking().SingleOrDefault(e => e.Id == IdTipoProcesso && e.IdUtilizador == IdUtilizador);

            if (aux == default) { return BadRequest("Erro na edição do tipo de processo"); }

            tipoProcesso.Id = IdTipoProcesso;
            tipoProcesso.IdUtilizador = IdUtilizador;

            if (VerificaNulo(tipoProcesso.Nome)) return BadRequest("Inserir Tipo Processo");

            if (tipoProcesso.Nome.ToString().Length < 2) return BadRequest("Formato tipo processo incorreto");

            if (NomeExists(tipoProcesso.Nome, IdUtilizador) && tipoProcesso.Id != IdTipoProcesso && IdTemaExists(tipoProcesso.IdTema, IdUtilizador)) return BadRequest("Tipo Processo já registado");
            
            _context.Entry(tipoProcesso).State = EntityState.Modified;
            
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoProcessoExists(IdTipoProcesso, IdUtilizador)) return NotFound("Tipo de processo não encontrado");
                else throw;
            }
            return Ok(tipoProcesso);
        }
        #endregion

        #region Consultar tipos de processo (by UserID)
        // GET: api/Tema
        [HttpGet("{IdUtilizador}/{IdTipoProcesso}")]
        public async Task<ActionResult<IQueryable<TipoProcesso>>> GetTiposProcesso(int IdUtilizador, int IdTipoProcesso)
        {
            var query = _context.TipoProcesso.AsQueryable();
            query = query.Where(tipo => tipo.IdUtilizador == IdUtilizador && tipo.Id == IdTipoProcesso);
            var itens = await query.ToListAsync();

            return Ok(itens);
        }
        #endregion

        #region Consultar tipos de processo (by UserID)
        // GET: api/Tema
        [HttpGet("{IdUtilizador}")]
        public async Task<ActionResult<IQueryable<TipoProcesso>>> GetTipoProcesso(int IdUtilizador)
        {
            var query = _context.TipoProcesso.AsQueryable();
            query = query.Where(tipo => tipo.IdUtilizador == IdUtilizador);
            var itens = await query.ToListAsync();

            return Ok(itens);
        }
        #endregion
        #endregion

        #region Functions
        private bool TipoProcessoExists(int id, int IdUtilizador) { return _context.TipoProcesso.Any(e => e.Id == id && e.IdUtilizador == IdUtilizador); }
        private bool NomeExists(string nome, int IdUtilizador) { return _context.TipoProcesso.Any(e => e.Nome == nome && e.IdUtilizador == IdUtilizador); }
        private bool IdTemaExists(int idTema, int IdUtilizador) { return _context.TipoProcesso.Any(e => e.IdTema == idTema && e.IdUtilizador == IdUtilizador); }
        private static bool VerificaNulo(string texto) { return (String.IsNullOrEmpty(texto)); }
        #endregion
    }
}
