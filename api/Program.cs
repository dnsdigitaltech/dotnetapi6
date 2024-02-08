var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World 2!");
app.MapPost("/", () => new {
    name = "Davi Bernado", age = 39
});
app.MapGet("/AddHeader", (HttpResponse response) => {
        response.Headers.Add("Teste", "Davi Bernardo");
        return new {
                name = "Davi Bernado", age = 39
            };
    });

app.Run();
