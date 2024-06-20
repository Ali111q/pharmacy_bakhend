namespace BackEndStructuer.DATA.DTOs
{

    public class DrugPharmacyForm 
    {
        public Guid DrugId { get; set; }
        public DateTime ExpiryDate { get; set; } 
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
