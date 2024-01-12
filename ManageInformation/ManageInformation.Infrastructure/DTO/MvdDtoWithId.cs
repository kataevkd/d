
namespace ManageInformation.Infrastructure.DTO
{
    public class MvdDtoWithId
    {
        public int Id { get; set; }
        public int Passport { get; set; }
        public string FamilyName { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string FatherName { get; set; } = String.Empty;
        public DateTime Date { get; set; }
        public string Address { get; set; } = String.Empty;
    }
}
