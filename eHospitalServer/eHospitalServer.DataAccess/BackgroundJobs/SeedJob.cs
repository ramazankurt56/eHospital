using eHospitalServer.Entities.Enums;
using eHospitalServer.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace eHospitalServer.DataAccess.BackgroundJobs;

public class SeedJob
{
    private readonly IServiceProvider _serviceProvider;

    public SeedJob(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task SeedAsync()
    {
        using var scope = _serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        var workingDays = new List<string> { "Pazartesi", "Salý", "Çarþamba", "Perþembe", "Cuma", "Cumartesi", "Pazar" };

        var users = new List<User>
        {
             new User
            {
                UserName = "admin",
                Email = "admin@admin.com",
                FirstName = "Admin",
                LastName = "Admin",
                IdentityNumber = "11111111222",
                FullAddress = "Ýstanbul",
                DateOfBirth = DateOnly.ParseExact("03.09.1989", "dd.MM.yyyy"),
                EmailConfirmed = true,
                IsActive = true,
                IsDeleted = false,
                BloodType = "0 rh+",
                UserType = UserType.Admin,
                EmailConfirmCode = 25
            },
            new User
            {
                UserName = "doctor1",
                Email = "doctor1@hospital.com",
                FirstName = "Ali",
                LastName = "Yýlmaz",
                IdentityNumber = "11111111114",
                FullAddress = "Ýstanbul",
                DateOfBirth = DateOnly.ParseExact("15.04.1985", "dd.MM.yyyy"),
                EmailConfirmed = true,
                IsActive = true,
                IsDeleted = false,
                BloodType = "A rh+",
                UserType = UserType.Doctor,
                EmailConfirmCode = 1001,
                DoctorDetail = new DoctorDetail
                {
                    Specialty = Specialty.Kardiyoloji,
                    WorkingDays = workingDays
                }
            },
            new User
            {
                UserName = "doctor2",
                Email = "doctor2@hospital.com",
                FirstName = "Mehmet",
                LastName = "Kaya",
                IdentityNumber = "11111111115",
                FullAddress = "Ankara",
                DateOfBirth = DateOnly.ParseExact("22.07.1978", "dd.MM.yyyy"),
                EmailConfirmed = true,
                IsActive = true,
                IsDeleted = false,
                BloodType = "B rh+",
                UserType = UserType.Doctor,
                EmailConfirmCode = 1002,
                DoctorDetail = new DoctorDetail
                {
                    Specialty = Specialty.Ortopedi,
                    WorkingDays = workingDays
                }
            },
            new User
            {
                UserName = "doctor3",
                Email = "doctor3@hospital.com",
                FirstName = "Zeynep",
                LastName = "Çelik",
                IdentityNumber = "11111111116",
                FullAddress = "Ýzmir",
                DateOfBirth = DateOnly.ParseExact("03.02.1990", "dd.MM.yyyy"),
                EmailConfirmed = true,
                IsActive = true,
                IsDeleted = false,
                BloodType = "0 rh+",
                UserType = UserType.Doctor,
                EmailConfirmCode = 1003,
                DoctorDetail = new DoctorDetail
                {
                    Specialty = Specialty.Psikiyatri,
                    WorkingDays = workingDays
                }
            },
            new User
            {
                UserName = "doctor4",
                Email = "doctor4@hospital.com",
                FirstName = "Ayþe",
                LastName = "Demir",
                IdentityNumber = "11111111117",
                FullAddress = "Antalya",
                DateOfBirth = DateOnly.ParseExact("12.11.1982", "dd.MM.yyyy"),
                EmailConfirmed = true,
                IsActive = true,
                IsDeleted = false,
                BloodType = "AB rh-",
                UserType = UserType.Doctor,
                EmailConfirmCode = 1004,
                DoctorDetail = new DoctorDetail
                {
                    Specialty = Specialty.Goz,
                    WorkingDays = workingDays
                }
            },
            new User
            {
                UserName = "doctor5",
                Email = "doctor5@hospital.com",
                FirstName = "Ramazan",
                LastName = "Kurt",
                IdentityNumber = "11111111118",
                FullAddress = "Bursa",
                DateOfBirth = DateOnly.ParseExact("28.09.1987", "dd.MM.yyyy"),
                EmailConfirmed = true,
                IsActive = true,
                IsDeleted = false,
                BloodType = "0 rh-",
                UserType = UserType.Doctor,
                EmailConfirmCode = 1005,
                DoctorDetail = new DoctorDetail
                {
                    Specialty = Specialty.Noroloji,
                    WorkingDays = workingDays
                }
            }
        };

        foreach (var user in users)
        {
            var existingUser = userManager.Users.FirstOrDefault(p => p.UserName == user.UserName || p.Email == user.Email || p.IdentityNumber == user.IdentityNumber);
            if (existingUser == null)
            {
                await userManager.CreateAsync(user, "1");
            }
        }
    }
}
