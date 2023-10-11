namespace fitness_tracker_api.Models
{
    public class ProgressPic
    {
        public int PicID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime DateTaken { get; set; }
        public string S3ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public ProgressPic()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
