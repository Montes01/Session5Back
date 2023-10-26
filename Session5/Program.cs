var builder = WebApplication.CreateBuilder(args);
const string POLICY = "AllowAll";
builder.Services.AddControllers();


builder.Services.AddCors(policy =>
    policy.AddPolicy(POLICY, config =>
    {
        config.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    })
);

var app = builder.Build();

app.MapControllers();

app.UseCors(POLICY);

app.MapGet("/", () => "Hello World!");

app.Run();
