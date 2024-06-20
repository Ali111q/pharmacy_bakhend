namespace BackEndStructuer.DATA.DTOs
{

    public class SellForm 
    {
        public Guid UserId { get; set; }
        public Guid PharmacyId { get; set; }
        public List<SellDrugForm> SellDrugs { get; set; } = default!;
        public decimal Discount { get; set; }
    }
}
