# cuadrado_diferencial

<img width="2555" height="1079" alt="image" src="https://github.com/user-attachments/assets/420209a1-9588-4640-a498-057449c25fd2" />

<img width="2557" height="1079" alt="image" src="https://github.com/user-attachments/assets/f1ff974b-dbdc-412a-955a-bedea41e5c16" />

Para calcular un cuadrado diferencial (por ejemplo, 𝑑𝑦=𝑓′(𝑥)𝑑𝑥) y mostrar el resultado en una interfaz gráfica (GUI), 
con Visual Studio 2022 como entorno de desarrollo y un front en JavaScript (JS), podrías hacerlo con una arquitectura básica backend (C#) + frontend (HTML/JS).

Aquí te doy una guía paso a paso para lograrlo:

✅ Paso 1: Crea el Backend en C# con .NET (Web API)
1.1 En Visual Studio 2022

Crea un nuevo proyecto: ASP.NET Core Web API

Elige:

Framework: .NET 6 o .NET 7

Nombre del proyecto: DiferencialApi

Desmarca "Enable OpenAPI support" si no necesitas Swagger.

1.2 Código del controlador para calcular el cuadrado diferencial
// Controllers/DiferencialController.cs
using Microsoft.AspNetCore.Mvc;

namespace DiferencialApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiferencialController : ControllerBase
    {
        // Ejemplo: función f(x) = x^2 → f'(x) = 2x
        [HttpGet]
        public IActionResult Calcular(double x, double dx)
        {
            double derivada = 2 * x; // f'(x)
            double dy = derivada * dx; // dy = f'(x) * dx

            return Ok(new
            {
                x,
                dx,
                derivada,
                dy
            });
        }
    }
}

✅ Paso 2: Habilita CORS para permitir acceso desde el frontend JS

En Program.cs, agrega:

var builder = WebApplication.CreateBuilder(args);

// CORS
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

app.UseCors("AllowAll");
app.MapControllers();

app.Run();

✅ Paso 3: Frontend en JavaScript

Puedes usar HTML + JavaScript básico o algún framework como React. Aquí va un ejemplo simple:

Archivo: index.html
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>Cuadrado Diferencial</title>
</head>
<body>
    <h1>Cálculo de Cuadrado Diferencial</h1>
    <label for="x">x:</label>
    <input type="number" id="x" step="any"><br><br>

    <label for="dx">dx:</label>
    <input type="number" id="dx" step="any"><br><br>

    <button onclick="calcularDiferencial()">Calcular</button>

    <h3>Resultado:</h3>
    <pre id="resultado"></pre>

    <script>
        async function calcularDiferencial() {
            const x = parseFloat(document.getElementById("x").value);
            const dx = parseFloat(document.getElementById("dx").value);

            const res = await fetch(`http://localhost:5000/api/diferencial?x=${x}&dx=${dx}`);
            const data = await res.json();

            document.getElementById("resultado").textContent = JSON.stringify(data, null, 2);
        }
    </script>
</body>
</html>


Asegúrate de que el backend se esté ejecutando en http://localhost:5000 (o el puerto correcto de tu Web API).

✅ Paso 4: Ejecutar

Ejecuta el backend desde Visual Studio 2022.

Abre el index.html en tu navegador.

Ingresa valores de x y dx, y haz clic en "Calcular".

Verás el resultado de 𝑓′(𝑥)⋅𝑑𝑥(cuadrado diferencial) en pantalla.

🧠 Personalización

Puedes cambiar la función derivada a otra (por ejemplo 𝑓(𝑥)=sin(𝑥), 𝑓′(𝑥)=cos(𝑥)).
