namespace MiniEcommerce.Api.Models
{
    public class ShoppingCart
    {
        //Id del carrello che in realtà sarebbe l'id utente o un Guid di sessione
        public string CartId { get; set; } = string.Empty;
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        //Comodo per calcolare il totale al volo
        public decimal TotalPrice => Items.Sum(item =>  item.Price * item.Quantity);
    }
}
