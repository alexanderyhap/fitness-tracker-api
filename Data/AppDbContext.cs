using fitness_tracker_api.Models;
using Microsoft.EntityFrameworkCore;

namespace fitness_tracker_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ProgressPic> ProgressPics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User entity configuration
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);             // Setting primary key
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100);

            // Workout entity configuration
            modelBuilder.Entity<Workout>()
                .HasKey(w => w.WorkoutID);          // Setting primary key

            modelBuilder.Entity<Workout>()
                .HasOne(w => w.User)                // Setting foreign key relationship to User
                .WithMany(u => u.Workouts)          // User entity has a Workouts collection property
                .HasForeignKey(w => w.UserID);

            modelBuilder.Entity<Workout>()
                .HasMany(w => w.WorkoutExercises)   // Setting one-to-many relationship to WorkoutExercises
                .WithOne(we => we.Workout)          // Each WorkoutExercise has one Workout
                .HasForeignKey(we => we.WorkoutID); // Setting the foreign key on WorkoutExercise

            // Exercise entity configuration
            modelBuilder.Entity<Exercise>()
                .HasKey(e => e.ExerciseID);         // Setting primary key

            // WorkoutExercise (join table) configuration
            modelBuilder.Entity<WorkoutExercise>()
                .HasKey(we => new { we.WorkoutID, we.ExerciseID }); // Composite key

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Workout)
                .WithMany(w => w.WorkoutExercises)
                .HasForeignKey(we => we.WorkoutID);

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Exercise)
                .WithMany(e => e.WorkoutExercises)
                .HasForeignKey(we => we.ExerciseID);

            // If you're tracking progress pics with dates
            modelBuilder.Entity<ProgressPic>()
                .HasKey(p => p.PicID);              // Setting primary key

            modelBuilder.Entity<ProgressPic>()
                .Property(p => p.DateTaken)
                .IsRequired();

            modelBuilder.Entity<ProgressPic>()
                .HasOne(p => p.User)                // Setting foreign key relationship to User
                .WithMany(u => u.ProgressPics)
                .HasForeignKey(p => p.UserID);

            base.OnModelCreating(modelBuilder);
        }

    }
}
