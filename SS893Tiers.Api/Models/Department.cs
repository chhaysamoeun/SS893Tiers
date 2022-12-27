﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SS893Tiers.Api.Models
{
	public class Department
	{
		[Key]
		public Guid DepartmentId { get; set; }
		[Required]
		[MaxLength(50)]
		public string DepartmentName { get; set; }
	}
}

