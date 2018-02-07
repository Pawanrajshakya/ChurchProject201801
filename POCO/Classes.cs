using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POCO
{
    public class Church
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address1 is required")]
        [MaxLength(255)]
        public string Address1 { get; set; }
        [Required(ErrorMessage = "Address2 is required")]
        [MaxLength(255)]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "State is required")]
        [MaxLength(2)]
        public string State { get; set; }
        [Required(ErrorMessage = "ZipCode is required")]
        [MaxLength(5)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(255)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    public class ContributorGroup
    {

        public ContributorGroup()
        {
            Contributors = new List<Contributor>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Group")]
        public string Description { get; set; }

        public List<Contributor> Contributors { get; set; }
    }

    public class ContributorKey
    {
        [Key]
        [MaxLength(255)]
        public string Id { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(255)]
        [Display(Name ="Key")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    public class Contributor
    {
        public Contributor()
        {
            Donations = new List<Donation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(255)]
        public string LastName { get; set; }
        //[Required(ErrorMessage = "Phone is required")]
        [MaxLength(12)]
        public string Phone { get; set; }
        //[Required(ErrorMessage = "Email is required")]
        [MaxLength(55)]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Address1 is required")]
        [MaxLength(255)]
        public string Address1 { get; set; }
        //[Required(ErrorMessage = "Address2 is required")]
        [MaxLength(255)]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "State is required")]
        [MaxLength(2)]
        public string State { get; set; }
        [Required(ErrorMessage = "ZipCode is required")]
        [MaxLength(5)]
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }

        public List<Donation> Donations { get; set; }

        [Required]
        [Display(Name ="Group")]
        public int Group { get; set; }
        [ForeignKey("Group")]
        public virtual ContributorGroup ContributorGroup { get; set; }

        public string Key { get; set; }
        [ForeignKey("Key")]
        public virtual ContributorKey ContributorKey { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class TransactionType
    {
        [Key]
        [MaxLength(1)]
        public string Type { get; set; }
        [MaxLength(255)]
        [Required]
        public string Description { get; set; }
    }

    public class Donation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Date is required.")]
        public DateTime TransactionDate { get; set; }
        [Range(10, 100000000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Amount { get; set; }
        [MaxLength(255)]
        public string Description1 { get; set; }
        [MaxLength(255)]
        public string Description2 { get; set; }

        [Required(ErrorMessage ="Transaction Type is required.")]
        public string Type { get; set; }
        [ForeignKey("Type")]
        public virtual TransactionType TransactionType { get; set; }

        [Required(ErrorMessage = "Please select the contributor.")]
        public int ContributorId { get; set; }
        [ForeignKey("ContributorId")]
        public virtual Contributor Contributor { get; set; }

        public bool IsDeleted { get; set; }
    }

    //public class IOC
    //{
    //    private ChurchContext _ChurchContext;

    //    public IOC(ChurchContext context)
    //    {
    //        _ChurchContext = context;
    //    }

    //    public void Save()
    //    {
    //        try
    //        {
    //            _ChurchContext.SaveChanges();
    //        }
    //        catch (System.Data.Entity.Validation.DbEntityValidationException ex)
    //        {
    //            // Retrieve the error messages as a list of strings.
    //            var errorMessages = ex.EntityValidationErrors
    //                    .SelectMany(x => x.ValidationErrors)
    //                    .Select(x => x.ErrorMessage);

    //            // Join the list to a single string.
    //            var fullErrorMessage = string.Join("; ", errorMessages);

    //            // Combine the original exception message with the new one.
    //            var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

    //            throw ex;
    //        }
    //    }
    //}

    public class ContributorDonationReportViewModel {
        public ContributorDonationReportViewModel()
        {
            Contributors = new List<Contributor>();
        }
        public Decimal Amount { get; set; }
        public List<Contributor> Contributors { get; set; }
    }
}
