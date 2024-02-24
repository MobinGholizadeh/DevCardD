namespace EFCoreProj.Models
{
	public class Product
	{
		public Product(long id, string name, double unitPrice, DateTime creationDate)
		{
			Id = id;
			Name = name;
			UnitPrice = unitPrice;
			CreationDate = creationDate;
		}

		public long Id { get; set; }
        public string Name{ get; set; }
        public double UnitPrice { get; set; }
        public DateTime CreationDate { get; set; }

    }

}
