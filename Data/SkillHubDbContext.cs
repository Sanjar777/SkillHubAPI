using Microsoft.EntityFrameworkCore;
using SkillHubAPI.Models;

namespace SkillHubAPI.Data;

public class SkillHubDbContext : DbContext
{
    public SkillHubDbContext(DbContextOptions<SkillHubDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Session> Sessions { get; set; } = null!;
    public DbSet<Enrollment> Enrollments { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<UploadedFile> UploadedFiles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // One-to-many: User (Mentor) → Sessions
        modelBuilder.Entity<Session>()
            .HasOne(s => s.Mentor)
            .WithMany(m => m.SessionsCreated)
            .HasForeignKey(s => s.MentorId)
            .OnDelete(DeleteBehavior.Restrict);

        // One-to-many: Session → Reviews
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Session)
            .WithMany(s => s.Reviews)
            .HasForeignKey(r => r.SessionId);

        // One-to-one: User → Role
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId);

        // Many-to-many: Learners ↔ Sessions (via Enrollment)
        modelBuilder.Entity<Enrollment>()
            .HasKey(e => new { e.SessionId, e.LearnerId });

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Session)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.SessionId);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Learner)
            .WithMany(l => l.Enrollments)
            .HasForeignKey(e => e.LearnerId);

        // File upload: Session has many resources
        modelBuilder.Entity<Session>()
            .HasMany(s => s.UploadedFiles)
            .WithOne(uf => uf.Sessions)
            .HasForeignKey(uf => uf.SessionId);
    }
}