namespace BackEndStructuer.DATA.DTOs
{

    public class OrderForm 
    {
        public Guid UserId { get; set; }
        public Guid PharmacyId { get; set; }
        public List<DrugPharmacyForm> DrugPharmacy { get; set; }
    }
}
