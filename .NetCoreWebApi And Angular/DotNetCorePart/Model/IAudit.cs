namespace DotNetCorePart.Model
{
    public abstract class Audit
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
