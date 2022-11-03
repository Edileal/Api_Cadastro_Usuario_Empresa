using CadastroUsuarioEmpresa.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CadastroApi");
//var _connectionString = builder.Configuration["ConnectionString:aula04"];

NativeInjectorBootStrapper.RegisterAppDependencies(builder.Services);
NativeInjectorBootStrapper.RegisterAppDependenciesContext(builder.Services, connectionString);

builder.Services
    .AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1",
                       new Microsoft.OpenApi.Models.OpenApiInfo
                       {
                           Title = "Api Cadastro de Usuário e empresa",
                           Version = "v1",
                           Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "Edivandro" },
                           TermsOfService = new Uri("http://raroacademy.com")
                       });

    //swagger.AddSecurityDefinition

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    swagger.IncludeXmlComments(xmlPath);
});

var _secretKey = builder.Configuration["SecretKey"];
var secretKey = Encoding.ASCII.GetBytes(_secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swagger =>
    {
        swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Cadastro usuário e empresa api");
    });
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();