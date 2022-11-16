#nullable disable
namespace JuriTechV2.Controllers
{
    /* TERMINADO
     * GetTemas - Consultar temas existentes (by UserID)
     * PutTema - Editar determinado tema (by UserID)
     * PostTema - Inserir tema (by UserID)
     */

    [Route("api/[controller]")]
    [ApiController]
    public class TemaController : ControllerBase
    {
        private readonly Contexto _context;

        public TemaController(Contexto context)
        {
            _context = context;
        }

        #region verbos

        #region Consultar temas existentes (by UserID)
        // GET: api/Tema
        [HttpGet("{IdUtilizador}")]
        public async Task<ActionResult<IQueryable<Tema>>> GetTemas(int IdUtilizador)
        {
            var query = _context.Tema.AsQueryable();
            query = query.Where(tema => tema.IdUtilizador == IdUtilizador);
            var itens = await query.ToListAsync();

            return Ok(itens);
        }
        #endregion

        #region Consultar tema existente por ID (by UserID)
        // GET: api/Tema
        [HttpGet("{IdUtilizador}/{Id}")]
        public async Task<ActionResult<IQueryable<Tema>>> GetTema(int IdUtilizador, int Id)
        {
            var query = _context.Tema.AsQueryable();
            query = query.Where(tema => tema.IdUtilizador == IdUtilizador && tema.Id == Id);
            var itens = await query.ToListAsync();

            return Ok(itens);
        }
        #endregion

        #region Editar determinado tema (by UserID)
        // PUT: api/Tema/5
        [HttpPut("{IdUtilizador}/{IdTema}")]
        public async Task<IActionResult> PutTema(int IdUtilizador, int IdTema, Tema tema)
        {
            var aux = _context.Tema.AsNoTracking().SingleOrDefault(e => e.Id == IdTema && e.IdUtilizador == IdUtilizador);

            if (aux == default) { return BadRequest("Erro na edição do tema"); }

            tema.Id = IdTema;
            tema.IdUtilizador = IdUtilizador;

            _context.Entry(tema).State = EntityState.Modified;

            if (VerificaNulo(tema.Nome)) return BadRequest("Inserir tema!");
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemaExists(IdTema)) return NotFound();
                else throw;
            }

            return Ok(tema);
        }
        #endregion

        #region Inserir tema (by UserID)
        // POST: api/Tema
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{IdUtilizador}")]
        public async Task<ActionResult<Tema>> PostTema(Tema tema, int IdUtilizador)
        {
            tema.IdUtilizador = IdUtilizador;

            if (VerificaNulo(tema.Nome)) return BadRequest("Inserir tema!");
            else
            {
                _context.Tema.Add(tema);
                await _context.SaveChangesAsync();
                return Ok(tema);
            }
        }
        #endregion

        #endregion

        #region Functions
        private bool TemaExists(int id) { return _context.Tema.Any(e => e.Id == id); }
        private static bool VerificaNulo(string texto) { return (String.IsNullOrEmpty(texto)); }
        #endregion
    }
}
