﻿using Microsoft.EntityFrameworkCore;

namespace DanceCoolDataAccessLogic.Entities
{
    public partial class DanceCoolContext : DbContext
    {
        public DanceCoolContext()
        {
        }

        public DanceCoolContext(DbContextOptions<DanceCoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abonement> Abonements { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<DanceDirection> DanceDirections { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<LessonType> LessonTypes { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SkillLevel> SkillLevels { get; set; }
        public virtual DbSet<UserCredentials> UserCredentials { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ARCH;Database=DanceCool;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Abonement>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AbonementName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_Attendances");

                entity.HasOne(d => d.PresntStudent)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.PresntStudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Attendances");
            });

            modelBuilder.Entity<DanceDirection>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasOne(d => d.Direction)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.DirectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Direction_Group");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK_Level_Group");

                entity.HasOne(d => d.PrimaryMentor)
                    .WithMany(p => p.GroupsPrimaryMentor)
                    .HasForeignKey(d => d.PrimaryMentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrimMentor_Group");

                entity.HasOne(d => d.SecondaryMentor)
                    .WithMany(p => p.GroupsSecondaryMentor)
                    .HasForeignKey(d => d.SecondaryMentorId)
                    .HasConstraintName("FK_SecMentor_Group");
            });

            modelBuilder.Entity<LessonType>(entity =>
            {
                entity.Property(e => e.LessonTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Group_Lesson");

                entity.HasOne(d => d.LessonType)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.LessonTypeId)
                    .HasConstraintName("FK_LessonType_Lesson");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.TotalSum).HasColumnType("money");

                entity.HasOne(d => d.Abonement)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.AbonementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Abonement_Payment");

                entity.HasOne(d => d.UserReceiver)
                    .WithMany(p => p.PaymentsUserReceiver)
                    .HasForeignKey(d => d.UserReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserReceiver_Payment");

                entity.HasOne(d => d.UserSender)
                    .WithMany(p => p.PaymentsUserSender)
                    .HasForeignKey(d => d.UserSenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSender_Payment");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SkillLevel>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserCredentials>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(254);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCredentials)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserCredentials");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasOne(d => d.Group)
                    .WithMany(p => p.UserGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_UserGroup");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserGroups)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserGroup");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_UserRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserRole");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(17)
                    .IsUnicode(false);
            });
        }
    }
}
