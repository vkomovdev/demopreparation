using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;
public enum AuditChangeType
{
	[Display(Name = "A")]
	Create,
	[Display(Name = "C")]
	Update,
	[Display(Name = "D")]
	Delete,
}
