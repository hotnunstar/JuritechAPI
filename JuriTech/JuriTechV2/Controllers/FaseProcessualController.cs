#nullable disable
using Microsoft.EntityFrameworkCore;

namespace JuriTechV2.Controllers
{
  
    /* (Em andamento - VITOR)
    * GetFasesProcessuais - Obtém lista de fases processuais existentes
     * GetFaseProcessual - Obtém determinada fase processual (Verificar condições de busca através das chaves primárias)
     * PutFaseProcessual - Alterar determinada fase processual (Verificar condições de busca através das chaves primárias | Verificar condições de edição)
     * PostFaseProcessual - Iserir uma fase processual (Fazer verificações na inserção) - OK
     * FaseProcessualExists - Verificar se a fase processual já existe (Verificar condições de procura através das chaves primárias!!)
     */
    /*NÃO OK - Inserir fase processual(por utilizador) // estafeito
    NÃO OK - Alterar fase processual(por utilizador) //feito
    NÃO OK - Consultar fase processual por NrProcesso(por utilizador) -- ta
    NÃO OK - Consultar fase processual por IdEstado(por utilizador) ---ta
    NÃO OK - Consultar fases processuais ativas(por utilizador) --- ta
    NÃO OK - Consultar fases processuais inativas(por utilizador)----ta*/


    [Route("api/[controller]")]
    [ApiController]
    public class FaseProcessualController : ControllerBase
    {
        private readonly Contexto _context;

        public FaseProcessualController(Contexto context)
        {
            _context = context;
        }

       /* [HttpGet("{IdUtilizador}/{IdEstado}")]
        public async Task<ActionResult<IQueryable<FaseProcessual>>> GetFaseProcessual(int IdUtilizador, int IdEstado)
        {
            var query = _context.FaseProcessual.AsQueryable();
            query = query.Where(faseProcessual => faseProcessual.IdEstado == IdEstado && faseProcessual.IdUtilizador == IdUtilizador);
            var itens = await query.ToListAsync();
            if(itens == null) return NotFound();
            return Ok(itens);
        }*/

        #region Consultar Fases Processuais por parâmetros pré-definidos (by UserID)
        [HttpGet("{IdUtilizador}/Parametros/{AtivasNaoAtivas}/{Todas}/{id}")]
        public async Task<ActionResult<IQueryable<FaseProcessual>>> GetFaseProcessual(int IdUtilizador, bool AtivasNaoAtivas, bool Todas, int id)
        {
            if (id == 0)
            {
                var query = _context.FaseProcessual.AsQueryable();
                query = query.Where(faseProcessual => faseProcessual.IdUtilizador == IdUtilizador);
                var itens = await query.ToListAsync();
                List<FaseProcessual> listaAtivas = new List<FaseProcessual>();
                List<FaseProcessual> listaNaoAtivas = new List<FaseProcessual>();
                List<FaseProcessual> todas = new List<FaseProcessual>();


                if (Todas == true)
                {
                    todas = itens;
                    if (todas == null) return NotFound();
                    return Ok(itens);
                }
                if (AtivasNaoAtivas == true)
                {
                    foreach (var faseProcessual in itens)
                    {
                        if (faseProcessual.NrDias == null) listaAtivas.Add(faseProcessual);
                    }
                    itens = listaAtivas;
                }
                if (AtivasNaoAtivas == false)
                {
                    foreach (var faseProcessual in itens)
                    {
                        if (faseProcessual.NrDias != null) listaNaoAtivas.Add(faseProcessual);
                    }
                    itens = listaNaoAtivas;
                }
                if (itens == null) return NotFound();
                return Ok(itens);
            }
            if(id == 1)
            {
                var query = _context.FaseProcessual.AsQueryable();
                query = query.Where(faseProcessual => faseProcessual.IdUtilizador == IdUtilizador && faseProcessual.IdEstado == id);
                var itens = await query.ToListAsync();
                List<FaseProcessual> listaAtivas = new List<FaseProcessual>();
                List<FaseProcessual> listaNaoAtivas = new List<FaseProcessual>();
                List<FaseProcessual> todas = new List<FaseProcessual>();
                if (Todas == true)
                {
                    todas = itens;
                    if (todas == null) return NotFound();
                    return Ok(itens);
                }
                if (AtivasNaoAtivas == true)
                {
                    foreach (var faseProcessual in itens)
                    {
                        if (faseProcessual.NrDias == null) listaAtivas.Add(faseProcessual);
                    }
                    itens = listaAtivas;
                }
                if (AtivasNaoAtivas == false)
                {
                    foreach (var faseProcessual in itens)
                    {
                        if (faseProcessual.NrDias != null) listaNaoAtivas.Add(faseProcessual);
                    }
                    itens = listaNaoAtivas;
                }
                if (itens == null) return NotFound();
                return Ok(itens);

            }
            if(id == 2)
            {
                var query = _context.FaseProcessual.AsQueryable();
                query = query.Where(faseProcessual => faseProcessual.IdUtilizador == IdUtilizador && faseProcessual.IdEstado == id);
                var itens = await query.ToListAsync();
                List<FaseProcessual> listaAtivas = new List<FaseProcessual>();
                List<FaseProcessual> listaNaoAtivas = new List<FaseProcessual>();
                List<FaseProcessual> todas = new List<FaseProcessual>();
                if (Todas == true)
                {
                    todas = itens;
                    if (todas == null) return NotFound();
                    return Ok(itens);
                }
                if (AtivasNaoAtivas == true)
                {
                    foreach (var faseProcessual in itens)
                    {
                        if (faseProcessual.NrDias == null) listaAtivas.Add(faseProcessual);
                    }
                    itens = listaAtivas;
                }
                if (AtivasNaoAtivas == false)
                {
                    foreach (var faseProcessual in itens)
                    {
                        if (faseProcessual.NrDias != null) listaNaoAtivas.Add(faseProcessual);
                    }
                    itens = listaNaoAtivas;
                }
                if (itens == null) return NotFound();
                return Ok(itens);

            }
            if(id == 3)
            {
                var query = _context.FaseProcessual.AsQueryable();
                query = query.Where(faseProcessual => faseProcessual.IdUtilizador == IdUtilizador && faseProcessual.IdEstado == id);
                var itens = await query.ToListAsync();
                List<FaseProcessual> listaAtivas = new List<FaseProcessual>();
                List<FaseProcessual> listaNaoAtivas = new List<FaseProcessual>();
                List<FaseProcessual> todas = new List<FaseProcessual>();
                if (Todas == true)
                {
                    todas = itens;
                    if (todas == null) return NotFound();
                    return Ok(itens);
                }
                if (AtivasNaoAtivas == true)
                {
                    foreach (var faseProcessual in itens)
                    {
                        if (faseProcessual.NrDias == null) listaAtivas.Add(faseProcessual);
                    }
                    itens = listaAtivas;
                }
                if (AtivasNaoAtivas == false)
                {
                    foreach (var faseProcessual in itens)
                    {
                        if (faseProcessual.NrDias != null) listaNaoAtivas.Add(faseProcessual);
                    }
                    itens = listaNaoAtivas;
                }
                if (itens == null) return NotFound();
                return Ok(itens);

            }
            return NotFound("Fases processuais não encontradas");
        }
        #endregion

        #region Consultar Fases Processuais por nº processo (by UserID)
        [HttpGet("{IdUtilizador}/{NrProcesso}")]
        public async Task<ActionResult<IQueryable<FaseProcessual>>> GetFasessProcessual(int IdUtilizador, string NrProcesso)
        {
            string a = "/";
            string b = "%2F";
            NrProcesso = NrProcesso.Replace(b, a);

            var query = _context.FaseProcessual.AsQueryable();
            query = query.Where(faseProcessual => faseProcessual.IdUtilizador == IdUtilizador && faseProcessual.NrProcesso == NrProcesso);
            var itens = await query.ToListAsync();

            if (itens == null) return NotFound();

            return Ok(itens);
        }
        #endregion

        #region Consultar Fases Processuais por nº processo e idEstado (by UserID)
        [HttpGet("{IdUtilizador}/{NrProcesso}/{IdEstado}/{DataEntrada}")]
        public async Task<ActionResult<IQueryable<FaseProcessual>>> GetFaseProcessual(int IdUtilizador, string NrProcesso, int IdEstado, string DataEntrada)
        {
            string a = "/";
            string b = "%2F";
            NrProcesso = NrProcesso.Replace(b, a);

            var query = _context.FaseProcessual.AsQueryable();
            query = query.Where(faseProcessual => faseProcessual.IdUtilizador == IdUtilizador && faseProcessual.NrProcesso == NrProcesso && faseProcessual.IdEstado == IdEstado && faseProcessual.DataEntrada == DataEntrada);
            var itens = await query.ToListAsync();

            if (itens == null) return NotFound();

            return Ok(itens);
        }
        #endregion

        #region Alterar fase processual
        // PUT: api/FaseProcessual/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{IdUtilizador}/{NrProcesso}/{IdEstado}/{DataEntrada}")]
        public async Task<IActionResult> PutFaseProcessual(string NrProcesso, int IdUtilizador,string DataEntrada,int IdEstado, FaseProcessual faseProcessual)
        {
            string a = "/";
            string b = "%2F";
            NrProcesso = NrProcesso.Replace(b, a);

            DateTime dateEntrada = DateTime.Parse(DataEntrada);
            DateTime dateSaida = DateTime.Parse(faseProcessual.DataSaida);

            var fase = await _context.FaseProcessual.AsNoTracking().FirstOrDefaultAsync(x => x.IdEstado == IdEstado && x.NrProcesso == NrProcesso && x.DataEntrada == DataEntrada && x.IdUtilizador == IdUtilizador);
            //if (fase == default) return BadRequest("o processo não tem nenhuma fase para ser alterada");

            faseProcessual.NrProcesso = NrProcesso;
            faseProcessual.IdUtilizador = IdUtilizador;
            faseProcessual.DataEntrada = DataEntrada;
            faseProcessual.IdEstado = IdEstado;

            _context.Entry(faseProcessual).State = EntityState.Modified;

            if (dateEntrada > dateSaida) return BadRequest("Data de Entrada Maior que Data de Saída");

            if (faseProcessual.DataSaida != null) faseProcessual.NrDias = dateSaida.Subtract(dateEntrada).Days;
            else faseProcessual.NrDias = null;
            
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { throw; }
            return Ok(faseProcessual);
        }
        #endregion

        #region Inserir Fase Processual
        // POST: api/FaseProcessual
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{IdUtilizador}/{NrProcesso}")]
        public async Task<ActionResult<IQueryable<FaseProcessual>>> PostFaseProcessual(int IdUtilizador, string NrProcesso, FaseProcessual faseProcessual)
        {
            string a = "/";
            string b = "%2F";
            faseProcessual.NrProcesso = faseProcessual.NrProcesso.Replace(b, a);

            DateTime? dateSaida = new DateTime();
            DateTime dataAux = new();
            DateTime dateEntrada = DateTime.Parse(faseProcessual.DataEntrada);

            if (!DateTime.TryParse(faseProcessual.DataSaida, out dataAux)) dateSaida = null;
            else dateSaida = dataAux;

            var query = _context.FaseProcessual.AsQueryable();
            query = query.Where(faseProcessual => faseProcessual.IdUtilizador == IdUtilizador && faseProcessual.NrProcesso == NrProcesso);
            var listaFases = await query.ToListAsync();

            faseProcessual.IdUtilizador = IdUtilizador;

            if (VerificaNulo(faseProcessual.NrProcesso)) return BadRequest("Sem NrProcesso");
            if (FaseADecorrer(faseProcessual.NrProcesso))
            {
                foreach (var fase in listaFases)
                {
                    if (string.IsNullOrEmpty(fase.DataSaida)) return BadRequest("Processo encontra-se a decorrer numa fase");
                    if (fase.IdEstado == faseProcessual.IdEstado) return BadRequest("Processo já tem essa fase associada");
                }
            }

            if (dateSaida != null)
            {
                DateTime date = dateSaida.Value;
                faseProcessual.NrDias = date.Subtract(dateEntrada).Days;
            }
            else faseProcessual.NrDias = null;


            _context.FaseProcessual.Add(faseProcessual);
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateException) { throw; }

            return Ok(faseProcessual);
        }
        #endregion

        #region Functions
        private bool FaseProcessualExists(int id, string nrProcesso, int idUtilizador)
        {
            return _context.FaseProcessual.Any(e => e.IdEstado == id && e.NrProcesso == nrProcesso && e.IdUtilizador == idUtilizador);
        }
        private bool FaseADecorrer(string nrProcesso)
        {
            return _context.FaseProcessual.Any(e => e.NrProcesso == nrProcesso);
        }
        private static bool VerificaNulo(string texto) { return (String.IsNullOrEmpty(texto)); }
        #endregion
    }
}
