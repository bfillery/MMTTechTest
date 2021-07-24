namespace MMT.Models.DB
{
    public class OrderItem
    {
        public int ORDERITEMID { get; set; }
        public int ORDERID { get; set; }
        public int PRODUCTID { get; set; }
        public int QUANTITY  { get; set; }
        public decimal PRICE { get; set; }
        public bool RETURNABLE { get; set; }

    }
}
