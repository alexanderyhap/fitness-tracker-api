namespace fitness_tracker_api.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Gender { get; set; }
        public decimal BodyFat { get; set; }
        public decimal BMI { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<Workout> Workouts { get; set; }
        public ICollection<ProgressPic> ProgressPics { get; set; }

        public User()
        {
            Workouts = new List<Workout>();
            ProgressPics = new List<ProgressPic>();
            RegistrationDate = DateTime.UtcNow;
        }

    }
}
