using MeusLivrosAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

//  Criando uma inst�ncia do WebApplication.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/* AddControllers() -> Adiciona os controladores � cole��o de servi�os da aplica��o
 * permitindo o uso do padr�o de arquitetura MVC (Model-View-Controller) para tratar as requisi��es HTTP.
 * AddNewtonsoftJson() -> M�todo de extens�o que configura o sistema de serializa��o JSON da aplica��o para utilizar o 
 * pacote Newtonsoft.Json como o serializador padr�o.
*/
builder.Services.AddControllers().AddNewtonsoftJson();

// Configurando o automapper para todo o contexto da aplica��o.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Faz a configura��o da documenta��o do swagger via xml.
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LivrosAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Configura a conex�o com o banco de dados a partir do appsettings.json.
var connectionString = builder.Configuration.GetConnectionString("LivroConnection");

// Adicionando conex�o com o banco.
builder.Services.AddDbContext<LivroContext>(opts =>
    opts.UseMySql(connectionString, 
    ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Adicionando o swagger a aplica��o.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona solicita��es HTTP para HTTPS.
app.UseHttpsRedirection();

// Essa linha adiciona o middleware de autoriza��o � pipeline de requisi��o da aplica��o. 
app.UseAuthorization();

// Mapeando os controladores (Controllers) da aplica��o � pipeline de requisi��o.
app.MapControllers();

// Iniciando a execu��o da aplica��o ASP.NET.
app.Run();
