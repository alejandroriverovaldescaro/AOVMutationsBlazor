using System;
using System.ComponentModel.DataAnnotations;

namespace AOVMutationsBlazor.Data.Models;

/// <summary>
/// Represents employment details in the SZV-PRIS schema
/// </summary>
public class Employment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [Required]
    [StringLength(20)]
    public string ContractType { get; set; } = string.Empty; // e.g., "Vast", "Tijdelijk", "Payroll"

    [StringLength(50)]
    public string? JobTitle { get; set; }

    [StringLength(100)]
    public string? Department { get; set; }

    public decimal? SalaryAmount { get; set; }

    [StringLength(20)]
    public string? SalaryPeriod { get; set; } // e.g., "Per maand", "Per 4 weken"

    public decimal? WorkHoursPerWeek { get; set; }

    [StringLength(20)]
    public string? EmploymentStatus { get; set; } // e.g., "Actief", "Beëindigd"

    // SZV-PRIS specific fields
    [StringLength(20)]
    public string? IncomeCode { get; set; }

    [StringLength(20)]
    public string? SectorCode { get; set; }

    public bool IsAOVInsured { get; set; } = true;

    // Navigation properties
    public virtual ICollection<MutationRequest> MutationRequests { get; set; } = new List<MutationRequest>();
}
