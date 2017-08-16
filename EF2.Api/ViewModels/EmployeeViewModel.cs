namespace EF2.Api.ViewModels
{
    public struct EmployeeViewModel
    {
        public int Id { get; set; }
        public string NationalIDNumber { get; set; }
        public string Title { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public System.DateTime HireDate { get; set; }
        public bool SalariedFlag { get; set; }
        public bool IsActive { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
    }

    public struct VendorViewModel
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public bool PreferredVendorStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
