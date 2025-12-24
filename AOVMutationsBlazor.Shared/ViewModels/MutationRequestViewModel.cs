using System;
using System.ComponentModel.DataAnnotations;

namespace AOVMutationsBlazor.Shared.ViewModels;

/// <summary>
/// View model for mutation request wizard
/// </summary>
public class MutationRequestViewModel
{
    public int Id { get; set; }
    public string RequestNumber { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; } = DateTime.Now;
    public string MutationType { get; set; } = string.Empty;
    public string Status { get; set; } = "Concept";

    // Person details
    public PersonViewModel Person { get; set; } = new();

    // Address details
    public AddressViewModel Address { get; set; } = new();

    // Employment details
    public EmploymentViewModel Employment { get; set; } = new();
}

public class PersonViewModel
{
    [Required(ErrorMessage = "BSN is verplicht")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "BSN moet 9 cijfers zijn")]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "BSN moet 9 cijfers bevatten")]
    public string BSN { get; set; } = string.Empty;

    [StringLength(20)]
    public string? EmployeeNumber { get; set; }

    [Required(ErrorMessage = "Voornaam is verplicht")]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(20)]
    public string? Initials { get; set; }

    [StringLength(50)]
    public string? Prefix { get; set; }

    [Required(ErrorMessage = "Achternaam is verplicht")]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Geboortedatum is verplicht")]
    public DateTime DateOfBirth { get; set; }

    public string? Gender { get; set; }
    
    [StringLength(3)]
    public string? Nationality { get; set; }

    [StringLength(50)]
    public string? PlaceOfBirth { get; set; }

    [StringLength(3)]
    public string? CountryOfBirth { get; set; }

    [EmailAddress(ErrorMessage = "Ongeldig e-mailadres")]
    [StringLength(50)]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "Ongeldig telefoonnummer")]
    [StringLength(20)]
    public string? PhoneNumber { get; set; }
}

public class AddressViewModel
{
    [Required(ErrorMessage = "Straat is verplicht")]
    [StringLength(100)]
    public string Street { get; set; } = string.Empty;

    [Required(ErrorMessage = "Huisnummer is verplicht")]
    [StringLength(10)]
    public string HouseNumber { get; set; } = string.Empty;

    [StringLength(10)]
    public string? HouseNumberAddition { get; set; }

    [Required(ErrorMessage = "Postcode is verplicht")]
    [StringLength(10)]
    [RegularExpression(@"^\d{4}\s?[A-Z]{2}$", ErrorMessage = "Ongeldig postcode formaat (bijv. 1234AB)")]
    public string PostalCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Plaats is verplicht")]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [StringLength(50)]
    public string? Province { get; set; }

    [Required]
    [StringLength(3)]
    public string Country { get; set; } = "NLD";
}

public class EmploymentViewModel
{
    [Required(ErrorMessage = "Startdatum is verplicht")]
    public DateTime StartDate { get; set; } = DateTime.Now;

    public DateTime? EndDate { get; set; }

    [Required(ErrorMessage = "Contracttype is verplicht")]
    [StringLength(20)]
    public string ContractType { get; set; } = string.Empty;

    [StringLength(50)]
    public string? JobTitle { get; set; }

    [StringLength(100)]
    public string? Department { get; set; }

    [Range(0, 999999.99, ErrorMessage = "Salaris moet tussen 0 en 999999.99 liggen")]
    public decimal? SalaryAmount { get; set; }

    [StringLength(20)]
    public string? SalaryPeriod { get; set; }

    [Range(0, 168, ErrorMessage = "Werkuren per week moet tussen 0 en 168 liggen")]
    public decimal? WorkHoursPerWeek { get; set; }

    [StringLength(20)]
    public string? EmploymentStatus { get; set; } = "Actief";

    [StringLength(20)]
    public string? IncomeCode { get; set; }

    [StringLength(20)]
    public string? SectorCode { get; set; }

    public bool IsAOVInsured { get; set; } = true;
}
