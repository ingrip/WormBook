namespace WormBook.Models
{
    public class PedidoEspecial
    {
        public int orderNumber { get; set; }
        public string clientName { get; set; }
        public string phoneNumber { get; set; }
        public DateTime? orderDate { get; set; }
        public int stock {  get; set; }
    }
}
