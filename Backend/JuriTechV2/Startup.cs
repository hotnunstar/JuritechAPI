namespace JuriTechV2
{
    public class Startup
    {
        public static WebApplication InitializeApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            // builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder.WithOrigins("https://localhost:7180").AllowAnyHeader().AllowAnyMethod()));
            builder.Services.AddCors();
          builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<Contexto>
                (option => option.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=Juritech;User Id=juritech;Password=juritech;"));
           
            builder.Services.AddSwaggerGen();
        }

        public static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(c=>c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthorization();
           
            app.MapControllers();
            app.UseDeveloperExceptionPage();
        }
    }
}
