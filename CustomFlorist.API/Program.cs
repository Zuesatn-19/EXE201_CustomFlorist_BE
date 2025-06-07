using System.Text.Json.Serialization;
using CustomFlorist.API.Common.Extensions;
using CustomFlorist.Domain;
using CustomFlorist.Domain.Constant;
using CustomFlorist.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsConstant.PolicyName,
        policy =>
        {
            policy.WithOrigins("*")
                .AllowAnyHeader().AllowAnyMethod();
        });
});
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    // x.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
});
builder.Services.AddDomainServices(builder.Configuration);
builder.Services.AddRepositoryServices();
builder.Services.AddServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJwtValidation();
builder.Services.AddConfigSwagger();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(CorsConstant.PolicyName);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.Run();
