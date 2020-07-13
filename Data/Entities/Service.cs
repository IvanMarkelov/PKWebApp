namespace PKWebApp.Data.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public bool IsAvailable { get; set; }
        public string Photo { get; set; }
    }
}