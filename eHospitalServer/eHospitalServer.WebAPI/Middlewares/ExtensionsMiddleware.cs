using eHospitalServer.Entities.Enums;
using eHospitalServer.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace eHospitalServer.WebAPI.Middlewares;

public static class ExtensionsMiddleware
{
    public static void CreateFirstUsers(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<User>>();

            var workingDays = new List<string> { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };

            var users = new List<User>
            {
                new User
                {
                    UserName = "admintest",
                    Email = "adminadmin@admin.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    IdentityNumber = "11111111222",
                    FullAddress = "İstanbul",
                    DateOfBirth = DateOnly.Parse("03.09.1989"),
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
                    LastName = "Yılmaz",
                    IdentityNumber = "11111111114",
                    FullAddress = "İstanbul",
                    DateOfBirth = DateOnly.Parse("15.04.1985"),
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
                    DateOfBirth = DateOnly.Parse("22.07.1978"),
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
                    FullAddress = "İzmir",
                    DateOfBirth = DateOnly.Parse("03.02.1990"),
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
                    FirstName = "Ayşe",
                    LastName = "Demir",
                    IdentityNumber = "11111111117",
                    FullAddress = "Antalya",
                    DateOfBirth = DateOnly.Parse("12.11.1982"),
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
                    DateOfBirth = DateOnly.Parse("28.09.1987"),
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
                // Kullanıcının var olup olmadığını kontrol et
                var existingUser = userManager.Users.FirstOrDefault(p => p.UserName == user.UserName || p.Email == user.Email || p.IdentityNumber == user.IdentityNumber);
                if (existingUser == null)
                {
                    // Kullanıcı veritabanında yoksa ekle
                    userManager.CreateAsync(user, "1").Wait();
                }
            }
        }
    }
}
