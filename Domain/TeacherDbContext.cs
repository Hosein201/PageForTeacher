using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Domain
{
    public class TeacherDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRoles, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options)
            : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<UserField> UserFields { get; set; }
        public DbSet<PathImg> PathImgs { get; set; }
        public DbSet<Edu> Edus { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRoles>().HasOne<User>(h => h.User).WithMany(w => w.UserRoles)
                .HasForeignKey(f => f.UserId).IsRequired();

            builder.Entity<UserRoles>().HasOne<Role>(h => h.Role).WithMany(w => w.UserRoles)
                .HasForeignKey(f => f.RoleId).IsRequired();

            builder.Entity<Support>().HasOne<User>(h => h.User).WithMany(w => w.Supports)
                .HasForeignKey(f => f.UserId).IsRequired();

            builder.Entity<Student>().HasOne(a => a.User).WithOne(b => b.Student)
                   .HasForeignKey<Student>(b => b.UserId);

            builder.Entity<Teacher>().HasOne(a => a.User).WithOne(b => b.Teacher)
             .HasForeignKey<Teacher>(b => b.UserId);

            builder.Entity<PathImg>().HasOne(h => h.User).WithMany(w => w.PathImgs)
                   .HasForeignKey(f => f.UserId).IsRequired();

            builder.Entity<User>().HasMany(h => h.UserFields).WithOne(w => w.User)
                .HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.NoAction);


            builder.Entity<UserField>().HasOne<Field>(h => h.Field).WithMany(w => w.UserFields)
                .HasForeignKey(f => f.FieldId).IsRequired();

            builder.Entity<Payment>().HasOne<User>(h => h.User).WithMany(w => w.Payments)
                   .HasForeignKey(f => f.UserId).IsRequired();

            builder.Entity<User>().HasIndex(h => h.PhoneNumber).IsUnique();
            builder.Entity<User>().HasIndex(h => h.Email).IsUnique();
            builder.Entity<User>().HasIndex(h => h.UserName).IsUnique();
            builder.Entity<User>().HasIndex(h => h.NationalCode).IsUnique();

            builder.Entity<Field>().HasIndex(h => h.Name).IsUnique();

            builder.Entity<Edu>().HasIndex(h => h.TeacherId).IsUnique(false);
            builder.Entity<Edu>().HasIndex(h => h.StudentId).IsUnique(false);
            builder.Entity<Edu>().HasIndex(h => h.FieldId).IsUnique(false);


            builder.Entity<Edu>().HasOne<Field>(h => h.Field).WithMany(w => w.Edus)
                .HasForeignKey(f => f.FieldId).IsRequired().OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Edu>().HasOne<Teacher>(h => h.Teacher).WithMany(w => w.Edus)
                .HasForeignKey(f => f.TeacherId).IsRequired().OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Edu>().HasOne<Student>(h => h.Student).WithMany(w => w.Edus)
                .HasForeignKey(f => f.StudentId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
