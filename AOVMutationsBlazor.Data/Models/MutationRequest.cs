using System;
using System.ComponentModel.DataAnnotations;

namespace AOVMutationsBlazor.Data.Models;

/// <summary>
/// Represents an AOV mutation request following SZV-PRIS schema
/// </summary>
public class MutationRequest
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string RequestNumber { get; set; } = string.Empty;

    [Required]
    public DateTime RequestDate { get; set; } = DateTime.Now;

    [Required]
    [StringLength(20)]
    public string MutationType { get; set; } = string.Empty; // e.g., "Inschrijving", "Wijziging", "Afmelding"

    [StringLength(20)]
    public string Status { get; set; } = "Concept"; // e.g., "Concept", "Ingediend", "Verwerkt"

    // Person details
    public int? PersonId { get; set; }
    public virtual Person? Person { get; set; }

    // Address details
    public int? AddressId { get; set; }
    public virtual Address? Address { get; set; }

    // Employment details
    public int? EmploymentId { get; set; }
    public virtual Employment? Employment { get; set; }

    // Timestamps
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? ModifiedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
}
