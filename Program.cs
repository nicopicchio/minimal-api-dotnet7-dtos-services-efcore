using ApiLearning.Data;
using ApiLearning.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ReferralContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/patients", async (ReferralContext context) =>
{
    var patients = await context.Patients.ToListAsync();
    return patients;
});

app.MapGet("/api/referrals", async (ReferralContext context) =>
{
    var referrals = await context.Referrals.ToListAsync();
    return referrals;
});

app.MapGet("/api/doctors", async (ReferralContext context) =>
{
    var doctors = await context.Doctors.ToListAsync();
    return doctors;
});

app.Run();
