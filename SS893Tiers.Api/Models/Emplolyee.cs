using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS893Tiers.Api.Models
{
	public class Emplolyee
	{
		[Key]
		public Guid EmployeeId { get; set; }
		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
        [MaxLength(50)]
		[Phone]
        public string PhoneNumber { get; set; }
        [MaxLength(500)]
        public string PlaceOfBirth { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
		[ForeignKey("Position")]
		public Guid PositionId { get; set; }
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }

		public Position Position { get; set; }
		public Department Department { get; set; }
	}
}

