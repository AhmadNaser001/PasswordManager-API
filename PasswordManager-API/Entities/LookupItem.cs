namespace PasswordManager_API.Entities
{
    public class LookupItem : ParentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LookupTypeId { get; set; }
    }
}
