using ReferralApi.Data;
using ReferralApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ReferralApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ReferralContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<ReferralService>();
builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Endpoints to GET a list of all patients/doctors/referrals

app.MapGet("/api/patients", async (PatientService service) =>
{
    var patients = await service.GetAllPatients();
    return patients;
});

app.MapGet("/api/referrals", async (ReferralService service) =>
{
    var referrals = await service.GetAllReferrals();
    return referrals;
});

app.MapGet("/api/doctors", async (DoctorService service) =>
{
    var doctors = await service.GetAllDoctors();
    return doctors;
});


// Endpoints to GET a specific patient/doctor/referral based on the id

app.MapGet("/api/patients/{id}", async (PatientService service, int id) =>
{
    var patient = await service.GetPatientById(id);
    if (patient is null)
    {
        return Results.NotFound("Patient not found!");
    }
    return Results.Ok(patient);
});

app.MapGet("/api/doctors/{id}", async (DoctorService service, int id) =>
{
    var doctor = await service.GetDoctorById(id);
    if (doctor is null)
    {
        return Results.NotFound("Doctor not found!");
    }
    return Results.Ok(doctor);
});

app.MapGet("/api/referral/{id}", async (ReferralService service, int id) =>
{
    var referral = await service.GetReferralById(id);
    if (referral is null)
    {
        return Results.NotFound("Referral not found!");
    }
    return Results.Ok(referral);
});


// Endpoints to POST a new patient/doctor/referral

app.MapPost("/api/patients", async (PatientService service, [FromBody] Patient patient) =>
{
    var response = await service.AddNewPatient(patient);
    return Results.Created($"/api/patients/{response.Id}", response);
});

app.MapPost("/api/referrals", async (ReferralService service, [FromBody] Referral referral) =>
{
    var response = await service.AddNewReferral(referral);
    return Results.Created($"/api/patients/{response.Id}", response);
});

app.MapPost("/api/doctors", async (DoctorService service, [FromBody] Doctor doctor) =>
{
    var response = await service.AddNewDoctor(doctor);
    return Results.Created($"/api/patients/{response.Id}", response);
});

app.Run();
