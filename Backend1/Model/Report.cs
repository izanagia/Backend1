namespace Backend1.Model
{
    public class Report
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Period { get; set; }
        public string ReportType { get; set; }
        public string Result { get; set; }
        public int Progress { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
