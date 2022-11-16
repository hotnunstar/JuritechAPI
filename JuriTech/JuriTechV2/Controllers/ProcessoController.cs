#nullable disable
namespace JuriTechV2.Controllers
{
    /* TERMINADO
     * PosProcesso - Criar um processo (by UserID)
     * PutProcesso - Alterar um processo (by UserID)
     * GetAllProcessos - Consultar todos os processos (by UserID)
     */

    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {
        private readonly Contexto _context;

        public ProcessoController(Contexto context)
        {
            _context = context;
        }

        #region Criar Processo (by UserID)
        // POST: api/Processo
        [HttpPost("{IdUtilizador}")]
        public async Task<ActionResult<Processo>> PostProcesso(Processo processo, int IdUtilizador)
        {
            processo.IdUtilizador = IdUtilizador;
            if (VerificaNulo(processo.NrProcesso)) return BadRequest("Inserir número do processo!!");
            if (VerificaNulo(processo.Nome)) return BadRequest("Inserir nome!!");
            DateTime date = DateTime.Parse(processo.DataEntrada);
            processo.DataEntrada = date.ToString("d");

            _context.Processo.Add(processo);
            await _context.SaveChangesAsync();

            return Ok(processo);
        }
        #endregion

        #region Alterar Processo (by UserID)
        // PUT: api/Processo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{IdUtilizador}/{NrProcesso}")]
        public async Task<IActionResult> PutProcesso(string NrProcesso, int IdUtilizador, Processo processo)
        {
            string a = "/";
            string b = "%2F";
            NrProcesso = NrProcesso.Replace(b, a);

            processo.NrProcesso = NrProcesso;
            processo.IdUtilizador = IdUtilizador;
            DateTime date = DateTime.Parse(processo.DataEntrada);

            var aux = await _context.Processo.AsNoTracking().FirstOrDefaultAsync(e => e.NrProcesso == NrProcesso && e.IdUtilizador == IdUtilizador);
            if (aux == default) return BadRequest("Processo não encontrado");
            DateTime date1 = DateTime.Parse(aux.DataEntrada);
            _context.Entry(processo).State = EntityState.Modified;

            if (VerificaNulo(processo.Nome)) processo.Nome = aux.Nome;
            if (processo.Valor == 0) processo.Valor = aux.Valor;
            if (VerificaNulo(processo.Notas)) processo.Notas = aux.Notas;
            if (DateTime.Compare(date1, date) == 0) processo.DataEntrada = aux.DataEntrada;  
            if (processo.IdTipo == 0) processo.IdTipo = aux.IdTipo;

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessoExists(NrProcesso, IdUtilizador)) return NotFound();
                else throw;
            }
            return Ok(processo);
        }
        #endregion

        #region Consultar Processos do Utilizador
        // GET: api/Processo
        [HttpGet("{IdUtilizador}")]
        public async Task<ActionResult<IQueryable<Processo>>> GetAllProcessos(int IdUtilizador)
        {
            var query = _context.Processo.AsQueryable();
            query = query.Where(processo => processo.IdUtilizador == IdUtilizador);
            var itens = await query.ToListAsync();

            return Ok(itens);
        }
        #endregion

        #region Consultar Processos do Utilizador por NrProcesso
        // GET: api/Processo
        [HttpGet("{IdUtilizador}/{NrProcesso}")]
        public async Task<ActionResult<IQueryable<Processo>>> GetProcesso(int IdUtilizador, string NrProcesso)
        {
            var query = _context.Processo.AsQueryable();
            query = query.Where(processo => processo.IdUtilizador == IdUtilizador && processo.NrProcesso == NrProcesso);
            var itens = await query.ToListAsync();

            return Ok(itens);
        }
        #endregion

        #region Funções
        private bool ProcessoExists(string id, int utilizador) { return _context.Processo.Any(e => e.NrProcesso == id && e.IdUtilizador == utilizador); }

        private static bool VerificaNulo(string texto) { return (String.IsNullOrEmpty(texto)); }
        #endregion
    }
}
