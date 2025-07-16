using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

var appInfo = new ProductManagementApplication[] {
    new(1, "Product Management"),
    new(2, "Hardip Grewal")
};

var prodManApi = app.MapGroup("/ProductManagement");
prodManApi.MapGet("/", () => appInfo);
prodManApi.MapGet("/{id}", (int id) =>
    appInfo.FirstOrDefault(a => a.Id == id) is { } prodMan
        ? Results.Ok(prodMan)
        : Results.NotFound());

app.Run();

public record ProductManagementApplication(int Id, string? Info);

[JsonSerializable(typeof(ProductManagementApplication[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
