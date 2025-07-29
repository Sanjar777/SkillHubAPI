using Microsoft.EntityFrameworkCore;
using SkillHubAPI.Models;

namespace SkillHubAPI.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // 1. Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = (int)RoleType.Learner, Name = RoleType.Learner.ToString() },
                new Role { Id = (int)RoleType.Mentor, Name = RoleType.Mentor.ToString() },
                new Role { Id = (int)RoleType.Admin, Name = RoleType.Admin.ToString() }
            );

            // 2. Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "Alice", Email = "alice@skillhub.com", Bio = "Learner in web dev", RoleId = (int)RoleType.Learner, PasswordHash = "hashedpwd1" },
                new User { Id = 2, FullName = "Bob", Email = "bob@skillhub.com", Bio = "Experienced mentor", RoleId = (int)RoleType.Mentor, PasswordHash = "hashedpwd2" },
                new User { Id = 3, FullName = "Admin", Email = "admin@skillhub.com", Bio = "System administrator", RoleId = (int)RoleType.Admin, PasswordHash = "hashedpwd3" }
            );

            // 3. Seed Sessions
            modelBuilder.Entity<Session>().HasData(
                new Session
                {
                    Id = 1,
                    Title = "C# Basics",
                    Description = "Intro to C#",
                    Tags = "C#, Beginner",
                    Difficulty = "Easy",
                    Capacity = 5,
                    MentorId = 2,
                    StartDate = new DateTime(2025, 8, 1),
                    EndDate = new DateTime(2025, 8, 15)
                }
            );

            // 4. Seed Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    LearnerId = 1,
                    SessionId = 1,
                    Status = "Enrolled"
                }
            );

            // 5. Optional: Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    UserId = 1,
                    SessionId = 1,
                    Rating = 5,
                    Comment = "Great intro session!"
                }
            );
        }
    }
}
 