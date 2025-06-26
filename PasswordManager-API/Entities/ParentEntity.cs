namespace PasswordManager_API.Entities
{
    public class ParentEntity
    {
        
        public int Id {get; set;}
        public string CreatedBy {get; set;}
        public string? UpdatedBy {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? UpdatedDate { get; set;}
        public bool IsActive { get; set; } = true;

    }
}
