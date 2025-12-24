using System;
using System.ComponentModel.DataAnnotations;

namespace AOVMutationsBlazor.Data.Models;

/// <summary>
/// Represents a person in the SZV-PRIS schema
/// </summary>
public class Person
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(9)]
    public string BSN { get; set; } = string.Empty; // Burgerservicenummer

    [StringLength(20)]
    public string? EmployeeNumber { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(20)]
    public string? Initials { get; set; }

    [StringLength(50)]
    public string? Prefix { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public DateTime DateOfBirth { get; set; }

    [StringLength(10)]
    public string? Gender { get; set; } // M, V, X

    [StringLength(3)]
    public string? Nationality { get; set; }

    [StringLength(50)]
    public string? PlaceOfBirth { get; set; }

    [StringLength(3)]
    public string? CountryOfBirth { get; set; }

    // Contact information
    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    // Navigation properties
    public virtual ICollection<MutationRequest> MutationRequests { get; set; } = new List<MutationRequest>();
}
