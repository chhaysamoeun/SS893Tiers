﻿using System;
using Microsoft.EntityFrameworkCore;
using SS893Tiers.Api.Models;

namespace SS893Tiers.Api.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{
		}
		public DbSet<Position> Position { get; set; }
		public DbSet<Department> Department { get; set; }
		public DbSet<Emplolyee> Employee { get; set; }
	}
}

