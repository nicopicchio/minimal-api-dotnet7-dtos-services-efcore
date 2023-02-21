using ReferralApi.Data;
using ReferralApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ReferralApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ReferralContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Endpoints to GET a list of all patients/doctors/referrals

app.MapGet("/api/patients", async (ReferralContext db) =>
{
    var patients = await db.Patients.ToListAsync();
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

app.MapPost("/api/patients", async (ReferralContext db, Patient patient) =>
{
    await db.Patients.AddAsync(patient);
    await db.SaveChangesAsync();
    return Results.Created($"/api/patients/{patient.Id}", patient);
});

app.MapPost("/api/referrals", async (ReferralContext db, Referral referral) =>
{
    await db.Referrals.AddAsync(referral);
    await db.SaveChangesAsync();
    return Results.Created($"/api/patients/{referral.Id}", referral);
});

app.MapPost("/api/doctors", async (ReferralContext db, Doctor doctor) =>
{
    await db.Doctors.AddAsync(doctor);
    await db.SaveChangesAsync();
    return Results.Created($"/api/patients/{doctor.Id}", doctor);
});

app.Run();
