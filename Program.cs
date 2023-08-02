using MeusLivrosAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

//  Criando uma instância do WebApplication.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/* AddControllers() -> Adiciona os controladores à coleção de serviços da aplicação
 * permitindo o uso do padrão de arquitetura MVC (Model-View-Controller) para tratar as requisições HTTP.
 * AddNewtonsoftJson() -> Método de extensão que configura o sistema de serialização JSON da aplicação para utilizar o 
 * pacote Newtonsoft.Json como o serializador padrão.
*/
builder.Services.AddControllers().AddNewtonsoftJson();

// Configurando o automapper para todo o contexto da aplicação.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Faz a configuração da documentação do swagger via xml.
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LivrosAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Configura a conexão com o banco de dados a partir do appsettings.json.
var connectionString = builder.Configuration.GetConnectionString("LivroConnection");

// Adicionando conexão com o banco.
builder.Services.AddDbContext<LivroContext>(opts =>
    opts.UseMySql(connectionString, 
    ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Adicionando o swagger a aplicação.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona solicitações HTTP para HTTPS.
app.UseHttpsRedirection();

// Essa linha adiciona o middleware de autorização à pipeline de requisição da aplicação. 
app.UseAuthorization();

// Mapeando os controladores (Controllers) da aplicação à pipeline de requisição.
app.MapControllers();

// Iniciando a execução da aplicação ASP.NET.
app.Run();
