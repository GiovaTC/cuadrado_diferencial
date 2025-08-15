var builder = WebApplication.CreateBuilder(args);

// Agrega servicios necesarios
builder.Services.AddControllers(); // Controladores (como DiferencialController)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Habilitar CORS para permitir llamadas desde JS (frontend)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Middleware para desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware HTTP
app.UseHttpsRedirection();
app.UseCors("AllowAll"); // Aplica la política de CORS
app.UseAuthorization();

app.MapControllers(); // Usa los controladores

app.Run();
