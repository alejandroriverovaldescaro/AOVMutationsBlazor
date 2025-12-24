using System.ComponentModel.DataAnnotations;

namespace AOVMutationsBlazor.Data.Models;

/// <summary>
/// Represents an address in the SZV-PRIS schema
/// </summary>
public class Address
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Street { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public string HouseNumber { get; set; } = string.Empty;

    [StringLength(10)]
    public string? HouseNumberAddition { get; set; }

    [Required]
    [StringLength(10)]
    public string PostalCode { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [StringLength(50)]
    public string? Province { get; set; }

    [Required]
    [StringLength(3)]
    public string Country { get; set; } = "NLD"; // ISO 3166-1 alpha-3

    // Navigation properties
    public virtual ICollection<MutationRequest> MutationRequests { get; set; } = new List<MutationRequest>();
}
