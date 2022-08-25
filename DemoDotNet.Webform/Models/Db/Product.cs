namespace DemoDotNet.Webform.Models.Db
{
    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public int CategoryID { set; get; }
        public string Image { set; get; }
        public decimal Price { set; get; }
        public int Quantity { set; get; }
        public string Description { set; get; }
        public bool Status { get; set; }
        public virtual ProductCategory ProductCategory { set; get; }
    }
}