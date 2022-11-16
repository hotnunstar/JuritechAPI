#nullable disable
using Microsoft.EntityFrameworkCore;

namespace JuriTechV2.Controllers
{
    /* TERMINADO
     * GetPrazos - Obter todos os prazos existentes (feito)
     * GetPrazo - Obter um prazo da lista (Fazer verificações tendo em conta as chaves primárias) (feito)
     * PostPrazo - Cria um novo prazo  (feito)
     *
     * PrazoExists - Verificar se determinado prazo existe (Fazer verificações tendo em conta as chaves primárias) (feito)
     */

    [Route("api/[controller]")]
    [ApiController]
    public class PrazoController : ControllerBase
    {
        private readonly Contexto _context;


        public PrazoController(Contexto context)
        {
            _context = context;
        }

        #region Criar / Adicionar um prazo (by UserID)
        // POST: api/Prazo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{IdUtilizador}/parametros/{IdCodigo}/{NrArtigo}/{NrProcesso}/{TipoPrazo}/{DataInicial}")]
        public async Task<ActionResult<Prazo>> PostPrazo(int IdCodigo, int IdUtilizador, int NrArtigo, string NrProcesso, int TipoPrazo, string DataInicial, Prazo prazo)
        {

            var item = await _context.PrazoCodigo.FirstOrDefaultAsync(x => x.IdCodigo == IdCodigo && x.IdTipoPrazo == TipoPrazo);
            if (item == default) return BadRequest("Código ou Tipo de Prazo incorreto!");
            else prazo.IdPrazoCodigo = item.Id;

            DateTime aux = new DateTime();
            string a = "/";
            string b = "%2F";
            NrProcesso = NrProcesso.Replace(b, a);
            
            int days;
            prazo.IdCodigo = IdCodigo;
            prazo.IdUtilizador = IdUtilizador;
            prazo.NrArtigo = NrArtigo;
            prazo.NrProcesso = NrProcesso;
            prazo.DataInicial = DataInicial;
            DateTime aux1 = DateTime.Parse(prazo.DataInicial);

            var artigo = await _context.Artigo.FirstOrDefaultAsync(x => x.IdCodigo == IdCodigo && x.IdUtilizador == IdUtilizador && x.NrArtigo == NrArtigo);
            if (artigo == default) return NotFound("Artigo não encontrado");
            else days = artigo.Dias;

            var processo = await _context.Processo.FirstOrDefaultAsync(x => x.NrProcesso == NrProcesso && x.IdUtilizador == IdUtilizador);
            if (processo == default) return NotFound("Processo não encontrado");

            if (artigo.Anos != 0) artigo.Dias += (artigo.diasAno(aux1.Year, artigo.Anos));
            if (artigo.Meses != 0) artigo.Dias += (artigo.diasMes(aux1.Month, aux1.Year, artigo.Meses));
            if (TipoPrazo == 1)
            {
                aux = prazo.RetornaCalculoDiasProcedimental(artigo, prazo.DataInicial);
                prazo.DataFinal = aux.ToString("yyyy-MM-dd");
            }
            if (TipoPrazo == 2)
            {
                aux = prazo.RetornaCalculoDiasCaducidade(artigo, prazo.DataInicial);
                prazo.DataFinal = aux.ToString("yyyy-MM-dd");
            }
            
            if (TipoPrazo == 3 && artigo.Ferias == true)
            {
                aux = prazo.RetornaCalculoDiasProcessualSos(artigo, prazo.DataInicial);
                prazo.DataFinal = aux.ToString("yyyy-MM-dd");
            }
            if (TipoPrazo == 3 && artigo.Ferias == false)
            {
                aux = prazo.RetornaCalculoDiasProcessual(artigo, prazo.DataInicial);
                prazo.DataFinal = aux.ToString("yyyy-MM-dd");
            }
            if (TipoPrazo == 4)
            {
                aux = prazo.RetornaCalculoDiasPrescricao(artigo, prazo.DataInicial);
                prazo.DataFinal = aux.ToString("yyyy/MM/dd");
            }

            artigo.Dias = days;

            _context.Prazo.Add(prazo);

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateException)
            {
                if (PrazoExists(prazo.IdPrazoCodigo, prazo.NrProcesso, prazo.IdUtilizador)) return Conflict("Já existe um prazo igual inserido!");
                else throw;
            }
            return Ok(prazo);
        }
        #endregion

        #region Apagar um prazo (by UserID)
        // DELETE: api/Prazo/5
        [HttpDelete("{IdUtilizador}/{NrProcesso}/{IdPrazoCodigo}")]
        public async Task<IActionResult> DeletePrazo(int IdPrazoCodigo, int IdUtilizador, string NrProcesso)
        {
            string a = "/";
            string b = "%2F";
            NrProcesso = NrProcesso.Replace(b, a);

            var prazo = await _context.Prazo.FindAsync(IdPrazoCodigo, IdUtilizador, NrProcesso);

            if (prazo == null) return NotFound("Prazo não encontrado");

            _context.Prazo.Remove(prazo);
            await _context.SaveChangesAsync();

            return Ok(prazo);
        }
        #endregion

        #region Obter prazos (by UserId e NrProcesso)
        // GET: api/Prazo/5 obtem o prazo de um dado processo associado a um utilizador
        [HttpGet("{IdUtilizador}/{NrProcesso}")]
        public async Task<ActionResult<Prazo>> GetPrazo(int IdUtilizador, string NrProcesso) 
        {
            string a = "/";
            string b = "%2F";
            NrProcesso = NrProcesso.Replace(b, a);

            var query = _context.Prazo.AsQueryable();
            query = query.Where(prazo => prazo.IdUtilizador == IdUtilizador && prazo.NrProcesso == NrProcesso);
            var itens = await query.ToListAsync();

            if (itens.Count() == 0) return NotFound("Prazo não encontrado");

            return Ok(itens);
        }

        // GET: api/Prazo/5 obtem o prazo de um dado processo e idPrazoCodigo associado a um utilizador
        [HttpGet("{IdUtilizador}/{NrProcesso}/{IdPrazoCodigo}")]
        public async Task<ActionResult<Prazo>> GetPrazo(int IdUtilizador, string NrProcesso, int IdPrazoCodigo)
        {
            string a = "/";
            string b = "%2F";
            NrProcesso = NrProcesso.Replace(b, a);

            var query = _context.Prazo.AsQueryable();
            query = query.Where(prazo => prazo.IdUtilizador == IdUtilizador && prazo.NrProcesso == NrProcesso && prazo.IdPrazoCodigo == IdPrazoCodigo);
            var itens = await query.ToListAsync();

            if (itens.Count() == 0) return NotFound("Prazo não encontrado");

            return Ok(itens);
        }

        //GET:api/Prazo/ obtem todos os prazos associados a um utilizador
        [HttpGet("{IdUtilizador}/parametros/{prioritarios}/{num}")]
        public async Task<ActionResult<Prazo>> GetPrazoUtilizador(int IdUtilizador, bool prioritarios, int num)
        {
            var query = _context.Prazo.AsQueryable();
            query = query.Where(prazo => prazo.IdUtilizador == IdUtilizador);
            var itens = await query.ToArrayAsync();
            int i = 0, dias,diasAux, cont =0;
            Prazo prazoMenor = new Prazo();
            DateTime aux = new DateTime();
            List<Prazo> prazoList = new List<Prazo>();
            List<Prazo> prazoListAux = new List<Prazo>();
            if(prioritarios)
            {
                switch (num)
                {
                    case 1:
                        if (itens.Length == 0) return BadRequest("Nao tem esse numero de prazos associados");
                        prazoMenor = itens[i];
                            aux = DateTime.Parse(itens[i].DataFinal);
                            dias = (int)aux.Subtract(DateTime.Today).TotalDays;

                            for (int x =1; x<itens.Length; x++)
                            { aux = DateTime.Parse(itens[x].DataFinal);
                                diasAux = (int)aux.Subtract(DateTime.Today).TotalDays;
                                if (dias > diasAux) prazoMenor = itens[x];
                            }
                            return prazoMenor;

                    case 2:
                        while(cont < 2)
                        {
                            if (itens.Length == 0) return BadRequest("Nao tem esse numero de prazos associados");
                            prazoMenor = itens[i];
                            aux = DateTime.Parse(itens[i].DataFinal);
                            dias = (int)aux.Subtract(DateTime.Today).TotalDays;

                            for (int x = 1; x < itens.Length; x++)
                            {
                                aux = DateTime.Parse(itens[x].DataFinal);
                                diasAux = (int)aux.Subtract(DateTime.Today).TotalDays;
                                if (dias > diasAux) prazoMenor = itens[x];
                            }
                            prazoList.Add(prazoMenor);
                            prazoListAux = itens.ToList();
                            prazoListAux.Remove(prazoMenor);
                            itens = prazoListAux.ToArray();
                            cont++;
                        }
                        return Ok(prazoList);
                    case 3:
                        while (cont < 3)
                        {
                            if (itens.Length == 0) return BadRequest("Nao tem esse numero de prazos associados");
                            prazoMenor = itens[i];
                            aux = DateTime.Parse(itens[i].DataFinal);
                            dias = (int)aux.Subtract(DateTime.Today).TotalDays;

                            for (int x = 1; x < itens.Length; x++)
                            {
                                aux = DateTime.Parse(itens[x].DataFinal);
                                diasAux = (int)aux.Subtract(DateTime.Today).TotalDays;
                                if (dias > diasAux) prazoMenor = itens[x];
                            }
                            prazoList.Add(prazoMenor);
                            prazoListAux = itens.ToList();
                            prazoListAux.Remove(prazoMenor);
                            itens = prazoListAux.ToArray();
                            cont++;
                        }
                        return Ok(prazoList);
                    case 4:
                        while (cont < 4)
                        {
                            if (itens.Length == 0) return BadRequest("Nao tem esse numero de prazos associados");
                            prazoMenor = itens[i];
                            aux = DateTime.Parse(itens[i].DataFinal);
                            dias = (int)aux.Subtract(DateTime.Today).TotalDays;

                            for (int x = 1; x < itens.Length; x++)
                            {
                                aux = DateTime.Parse(itens[x].DataFinal);
                                diasAux = (int)aux.Subtract(DateTime.Today).TotalDays;
                                if (dias > diasAux) prazoMenor = itens[x];
                            }
                            prazoList.Add(prazoMenor);
                            prazoListAux = itens.ToList();
                            prazoListAux.Remove(prazoMenor);
                            itens = prazoListAux.ToArray();
                            cont++;
                        }
                        return Ok(prazoList);
                    case 5:
                        while (cont < 5)
                        {
                            if (itens.Length == 0) return BadRequest("Nao tem esse numero de prazos associados");
                            prazoMenor = itens[i];
                            aux = DateTime.Parse(itens[i].DataFinal);
                            dias = (int)aux.Subtract(DateTime.Today).TotalDays;

                            for (int x = 1; x < itens.Length; x++)
                            {
                                aux = DateTime.Parse(itens[x].DataFinal);
                                diasAux = (int)aux.Subtract(DateTime.Today).TotalDays;
                                if (dias > diasAux) prazoMenor = itens[x];
                            }
                            prazoList.Add(prazoMenor);
                            prazoListAux = itens.ToList();
                            prazoListAux.Remove(prazoMenor);
                            itens = prazoListAux.ToArray();
                            cont++;
                        }
                        return Ok(prazoList);




                }
            }
            
                if (itens == null) return NotFound("Prazos não encontrados");
                return Ok(itens);
            
            
        }
        #endregion

        #region Funçoes 
        private bool PrazoExists(int id, string processo, int uti)
        {
            return _context.Prazo.Any(e => e.IdPrazoCodigo == id && e.NrProcesso == processo && e.IdUtilizador == uti);
        }
        #endregion
    }
}
