using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

class StatisticDBContext : DbContext
{
	public DbSet<WorkShiftStatistic> WorkShiftStatistics => Set<WorkShiftStatistic>();
	public StatisticDBContext() => Database.EnsureCreated();

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Data Source=DESKTOP-KJEDSA0;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=True;" +
			"Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
		//optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;" +
		//	"Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
	}
}
