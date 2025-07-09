namespace Webshop.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int User_Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Email { get; set; }

        public List<API.Models.OrderedProduct>? Products { get; set; }

        public string? Status { get; set; }
    }
}
