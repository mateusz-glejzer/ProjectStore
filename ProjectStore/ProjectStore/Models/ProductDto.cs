namespace ProjectStore.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public byte[] Image { get ; set; }

        //public virtual int UserId { get; set; }
        //public virtual UserDto User { get; set; }
    }
}
