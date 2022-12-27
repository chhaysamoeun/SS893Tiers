﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SS893Tiers.Api.Models
{
	public class Position
	{
		[Key]
		public Guid PositionId { get; set; }
		[Required]
		[MaxLength(50)]
		public string PositionName { get; set; }
	}
}

