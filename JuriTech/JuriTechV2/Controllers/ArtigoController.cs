#nullable disable
namespace JuriTechV2.Controllers
{
    /* Terminado
     * PostArtigo - Inserir um artigo (by UserID)
     * DeleteArtigo - Eliminar um artigo (by UserID)
     * PutArtigo - Alterar um artigo (by UserID)
     * GetArtigos - Consultar artigos (by UserID)
     * GetArtigosByCodigoProcessual - Consultar artigos por código processual (by UserID)
     */

    [Route("api/[controller]")]
    [ApiController]
    public class ArtigoController : ControllerBase
    {
        private readonly Contexto _context;
        public ArtigoController(Contexto context)
        {
            _context = context;
        }
      

        #region Inserir artigo (by UserID)
        // POST: api/Artigo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{IdUtilizador}")]
        public async Task<ActionResult<Artigo>> PostArtigo(Artigo artigo, int IdUtilizador)
        {
            artigo.IdUtilizador = IdUtilizador;
            bool pa = true, pc = true, pp = true, rimos = true;
            if (artigo.IdCodigo == 1) pa = ConfirmaProcedimentoAdministrativo(artigo);
            if (artigo.IdCodigo == 2) pc = ConfirmaProcessoCivil(artigo);
            if (artigo.IdCodigo == 3) pp = ConfirmaProcessoPenal(artigo);
            if (artigo.IdCodigo == 4) rimos = ConfirmaProcessoRimos(artigo);
            if (!pa || !pc || !pp || !rimos) return BadRequest("O artigo não está coerente com a lei");

            _context.Artigo.Add(artigo);

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateException)
            {
                if (ArtigoExists(artigo.IdCodigo, artigo.NrArtigo, artigo.IdUtilizador)) return BadRequest("O artigo já existe!");
                else throw;
            }

            return Ok(artigo);
        }
        #endregion

        #region Eliminar artigo (by UserID) 
        // DELETE: api/Artigo/5 
        [HttpDelete("{IdUtilizador}/{IdCodigo}/{NrArtigo}")]
        public async Task<IActionResult> DeleteArtigo(int IdCodigo, int NrArtigo, int IdUtilizador)
        {
            var artigo = await _context.Artigo.FindAsync(IdCodigo, NrArtigo, IdUtilizador);

            if (artigo == null) return NotFound();

            _context.Artigo.Remove(artigo);
            await _context.SaveChangesAsync();

            return Ok(artigo);
        }
        #endregion

        #region Alterar artigo (by UserID)
        // PUT: api/Artigo/5
        [HttpPut("{IdUtilizador}/{IdCodigo}/{NrArtigo}")]
        public async Task<IActionResult> PutArtigo(int IdCodigo, int NrArtigo, int IdUtilizador, Artigo artigo)
        {
            bool pa = true, pc = true, pp = true, rimos = true;

            artigo.NrArtigo = NrArtigo;
            artigo.IdCodigo = IdCodigo;
            artigo.IdUtilizador = IdUtilizador;

            var aux = await _context.Artigo.AsNoTracking().FirstOrDefaultAsync(e => e.NrArtigo == NrArtigo && e.IdCodigo == IdCodigo && e.IdUtilizador == IdUtilizador);
            if (aux == default) return BadRequest("Artigo não encontrado");

            _context.Entry(artigo).State = EntityState.Modified;

            if (VerificaNulo(artigo.Nome)) artigo.Nome = aux.Nome;
            if (artigo.Dias == 0) artigo.Dias = aux.Dias;
            if (artigo.Meses == 0) artigo.Meses = aux.Meses;
            if (artigo.Anos == 0) artigo.Anos = aux.Anos;
            if (artigo.DiasNaoUteis != aux.DiasNaoUteis || artigo.Ferias != aux.Ferias)
            {
                if (artigo.IdCodigo == 1) pa = ConfirmaProcedimentoAdministrativo(artigo);
                if (artigo.IdCodigo == 2) pc = ConfirmaProcessoCivil(artigo);
                if (artigo.IdCodigo == 3) pp = ConfirmaProcessoPenal(artigo);
                if (artigo.IdCodigo == 4) rimos = ConfirmaProcessoRimos(artigo);
            }
            if (pa == false || pc == false || pp == false || rimos == false)
            {
                return BadRequest("Por favor retifique as permissoes das ferias e dos dias, seja coerente com a legislação");
            }



            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtigoExists(IdCodigo, aux.NrArtigo, IdUtilizador)) return NotFound();
                else throw;
            }

            return Ok(artigo);
        }
        #endregion

        #region Consultar artigos (by UserID)
        // GET: api/Artigo
        [HttpGet("{IdUtilizador}")]
        public async Task<ActionResult<IQueryable<Artigo>>> GetArtigos(int IdUtilizador)
        {
            var query = _context.Artigo.AsQueryable();
            query = query.Where(artigo => artigo.IdUtilizador == IdUtilizador);
            var itens = await query.ToListAsync();

            return Ok(itens);
        }

        [HttpGet("{IdUtilizador}/{IdCodigo}/{NrArtigo}")]
        public async Task<ActionResult<IQueryable<Artigo>>> GetArtigo(int IdCodigo, int IdUtilizador, int NrArtigo)
        {
            var query = _context.Artigo.AsQueryable();
            query = query.Where(artigo => artigo.IdUtilizador == IdUtilizador && artigo.IdCodigo == IdCodigo && artigo.NrArtigo == NrArtigo);
            var itens = await query.ToListAsync();

            return Ok(itens);
        }
        #endregion

        #region Consultar artigos por código processual (by UserID)
        // GET: api/Artigo
        [HttpGet("{IdUtilizador}/{IdCodigo}")]
        public async Task<ActionResult<IQueryable<Artigo>>> GetArtigosByCodigoProcessual(int IdUtilizador, int IdCodigo)
        {
            var query = _context.Artigo.AsQueryable();
            query = query.Where(artigo => artigo.IdUtilizador == IdUtilizador && artigo.IdCodigo == IdCodigo);
            var itens = await query.ToListAsync();

            return Ok(itens);
        }
        #endregion

        #region Funções
        private bool ArtigoExists(int id, int nArtigo, int utilizador)
        {
            return _context.Artigo.Any(g => g.IdCodigo == id && g.IdUtilizador == utilizador && g.NrArtigo == nArtigo);
        }
        private bool ConfirmaProcedimentoAdministrativo(Artigo g)
        {
            if (g.Ferias == false && g.DiasNaoUteis == true) return true;
            return false;
        }
        private bool ConfirmaProcessoCivil(Artigo g)
        {
            if (g.Ferias == true && g.DiasNaoUteis == false || g.Ferias == false && g.DiasNaoUteis == false) return true;
            return false;
        }
        private bool ConfirmaProcessoPenal(Artigo g)
        {
            if (g.Ferias == false && g.DiasNaoUteis == true) return true;
            return false;
        }
        private bool ConfirmaProcessoRimos(Artigo g)
        {
            if (g.Ferias == false && g.DiasNaoUteis == false) return true;
            return false;
        }
        private Artigo GetRegisto(int idUtilizador, int nrArtigo, int idCodigo)
        {
            return _context.Artigo.AsNoTracking().SingleOrDefault(e => e.IdUtilizador == idUtilizador && e.NrArtigo == nrArtigo && e.IdCodigo == idCodigo);
            
        }

        private static bool VerificaNulo(string texto) { return (String.IsNullOrEmpty(texto)); }
        #endregion
    }

}
