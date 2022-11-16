namespace JuriTechV2.Context
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options)
            : base(options) => Database.EnsureCreated();

        public DbSet<Artigo> Artigo { get; set; }
        public DbSet<Codigo> Codigo { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<FaseProcessual> FaseProcessual { get; set; }
        public DbSet<Prazo> Prazo { get; set; }
        public DbSet<PrazoCodigo> PrazoCodigo { get; set; }
        public DbSet<Processo> Processo { get; set; }
        public DbSet<Tema> Tema { get; set; }
        public DbSet<TipoPrazo> TipoPrazo { get; set; }
        public DbSet<TipoProcesso> TipoProcesso { get; set; }
        public DbSet<Utilizador> Utilizador { get; set; }
        //public DbSet<Calculadora> Calculadora { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artigo>().HasKey(c => new { c.IdCodigo, c.NrArtigo, c.IdUtilizador });
            modelBuilder.Entity<FaseProcessual>().HasKey(c => new { c.IdUtilizador, c.IdEstado, c.NrProcesso, c.DataEntrada });
            modelBuilder.Entity<Prazo>().HasKey(c => new { c.IdPrazoCodigo, c.IdUtilizador, c.NrProcesso });
            modelBuilder.Entity<Processo>().HasKey(c => new { c.NrProcesso, c.IdUtilizador });
        }
    }
}
