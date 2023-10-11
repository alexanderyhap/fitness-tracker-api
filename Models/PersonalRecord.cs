namespace fitness_tracker_api.Models
{
    public class PersonalRecord
    {
        public int PersonalRecordID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
        public DateTime CreatedAt { get; set; }

        public PersonalRecord()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
