#nullable disable
namespace JuriTechV2.Controllers
{
    /* TERMINADO
     * GetUtilizadores - Obter lista de utilizadores existentes
     * GetUtilizador - Obter determinado utilizador (by id)
     * PutUtilizador - Alterar determinado utilizador (verificar função)
     * PostUtilizador - Criar um novo utilizador
     */

    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadorController : ControllerBase
    {
        private readonly Contexto _context;

        public UtilizadorController(Contexto context)
        {
            _context = context;
        }

        #region verbos
        #region Sign up
        // POST: api/Utilizador
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilizador>> PostUtilizador(Utilizador utilizador)
        {
            if (VerificaNulo(utilizador.Nome)) return BadRequest("Inserir nome!");

            if (!VerificaEmail(utilizador.Email)) return BadRequest("Email em formato incorreto!");

            if (EmailExists(utilizador.Email)) return BadRequest("Email já registado!");
            else
            {
                _context.Utilizador.Add(utilizador);
                await _context.SaveChangesAsync();
                return Ok(utilizador);
            }
        }
        #endregion

        #region login
        // GET: api/Utilizador/email
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<Utilizador>> GetUtilizadorLogin(string email, string password)
        {
            var item = await _context.Utilizador.FirstOrDefaultAsync(x => x.Email == email);
            if (item == default) return NotFound("Utilizador não encontrado");
            else if (item.Password != password) return BadRequest("Email ou Password incorreto");
            else return Ok(item);
        }
        #endregion

        #region Editar dados do utilizador (by ID)
        // GET: api/Utilizador/id
        // Obter registo do utilizador
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizador>> GetUtilizadorById(int id)
        {
            var item = await _context.Utilizador.FindAsync(id);
            if (item == null) return NotFound("Utilizador não encontrado");
            else return Ok(item);
        }

        // PUT: api/Utilizador/5
        // Alterar dados do utilizador
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilizador(int id, Utilizador utilizador)
        {
            var aux = GetRegisto(id);

            if (id != aux.Id) return BadRequest("Utilizador desconhecido!");

            utilizador.Id = id;

            if (VerificaNulo(utilizador.Nome)) utilizador.Nome = aux.Nome;
            if (VerificaNulo(utilizador.Password)) utilizador.Password = aux.Password;
            if (VerificaNulo(utilizador.Email)) utilizador.Email = aux.Email;
            if (!VerificaEmail(utilizador.Email)) return BadRequest("Email em formato incorreto!");
            if (EmailExists(utilizador.Email) && utilizador.Id != id) return BadRequest("Email já registado!");

            _context.Entry(utilizador).State = EntityState.Modified;

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizadorExists(id)) return NotFound();
                else throw;
            }
            return Ok(utilizador);
        }
        #endregion
       
        // DELETE: api/Utilizador/ID
        // Função apenas para apagar utilizador criado nos testes!! Não dar acesso ao utilizador
        [HttpDelete]
        public async Task<IActionResult> DeleteUtilizador(int id)
        {
            var utilizador = await _context.Utilizador.FindAsync(id);
            if (utilizador == null) return NotFound("Utilizador não encontrado");

            _context.Utilizador.Remove(utilizador);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Functions
        private bool UtilizadorExists(int id) { return _context.Utilizador.Any(e => e.Id == id); }
        private bool EmailExists(string email) { email = email.ToLower(); return _context.Utilizador.Any(_e => _e.Email == email); }
        private static bool VerificaEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch { return false; }
        }
        private static bool VerificaNulo(string texto) { return (String.IsNullOrEmpty(texto)); }
        private Utilizador GetRegisto(int id) { return _context.Utilizador.AsNoTracking().SingleOrDefault(e => e.Id == id); }
        #endregion
    }
}
