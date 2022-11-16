/*#nullable disable
namespace JuriTechV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        private readonly Contexto _context;

        public CalculadoraController(Contexto context)
        {
            _context = context;
        }

        [HttpPost("{tipoPrazo}")]
        public async Task<ActionResult<Calculadora>> PostCalculadora(Calculadora calculadora, int tipoPrazo)
        {
            // 1 -> Procedimental | 2 -> Caducidade | 3 -> Processual | 4 -> Prescrição (seguindo a informação da DB)

            Artigo artigo = new();
            artigo.Dias = 0;
            artigo.Anos = calculadora.Ano;
            if (calculadora.Ano != 0) artigo.Dias += (artigo.diasAno(calculadora.DataInicial.Year, calculadora.Ano));
            artigo.Meses = calculadora.Mes;
            if (calculadora.Mes != 0) artigo.Dias += (artigo.diasMes(calculadora.DataInicial.Month, calculadora.DataInicial.Year, calculadora.Mes));
            artigo.Dias += calculadora.Dias;

            Prazo prazo = new();

            if (tipoPrazo == 1) calculadora.DataFinal = prazo.RetornaCalculoDiasProcedimental(artigo, calculadora.DataInicial);
            if (tipoPrazo == 2) calculadora.DataFinal = prazo.RetornaCalculoDiasCaducidade(artigo, calculadora.DataInicial);
            if (tipoPrazo == 3 && calculadora.Ferias == true) calculadora.DataFinal = prazo.RetornaCalculoDiasProcessualSos(artigo, calculadora.DataInicial);
            if (tipoPrazo == 3 && calculadora.Ferias == false) calculadora.DataFinal = prazo.RetornaCalculoDiasProcessual(artigo, calculadora.DataInicial);
            if (tipoPrazo == 4) calculadora.DataFinal = prazo.RetornaCalculoDiasPrescricao(artigo, calculadora.DataInicial);

            Console.WriteLine("\n\n\n{0}\n\n\n", calculadora.DataFinal);

            _context.Calculadora.Add(calculadora);

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateException) { throw; }

            return CreatedAtAction("GetCalculadora", new { dataFinal = calculadora.DataFinal }, calculadora);
        }
    }
}*/