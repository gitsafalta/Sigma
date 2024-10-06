
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Sigma.Application;
using Sigma.Application.Mapper;
using Sigma.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SigmaDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<ICandidatesRepository, CandidatesRepository>();
builder.Services.AddTransient<ICandidateService, CandidateService>();
builder.Services.AddAutoMapper(typeof(CandidateMapper));
builder.Services.AddTransient<IValidator<CandidateDTO>, CandidateValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureApi();

app.Run();
