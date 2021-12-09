namespace ProjectStore.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description  { get; set; }
        public bool IsAvailable { get; set; }

        //public virtual int UserId { get; set; }
        //public virtual User User { get; set; }
    }
}
