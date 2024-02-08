using Microsoft.AspNetCore.Mvc;

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

app.MapPost("/saveproduct", (Product product) => {
    return product.Code + " - " + product.Name;
});

//parametros Query string
app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) => {
    return dateStart + " - " + dateEnd;
});

//parametros rotas
app.MapGet("/getproduct/{code}", ([FromRoute] string code) => {
    return code;
});

//parametros Header
app.MapGet("/getproductheader", (HttpRequest request) => {
    return request.Headers["product-code"].ToString();
});

app.Run();

public class Product {
    public string Code { get; set; }
    public string Name { get; set; }
}