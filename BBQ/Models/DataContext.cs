using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BBQ.Models
{
    public class DataContext : DbContext

	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			var configuration = builder.Build();

			
			optionsBuilder.UseMySql(configuration
				["ConnectionStrings:DefaultConnection"], new MySqlServerVersion(new Version(8, 0, 11)));

		}


	

		public DbSet<Ususerlogin> Ususerlogins { get; set; }
  
        //need to register your model here 
        //public Dbset<product> Products{get;set;}

        //public DbSet<AdminRegister> AdminRegisters { get; set; }
        /*public DbSet<library> libraries { get; set; }

		public DbSet<userlogin> userlogins { get; set; }
		public DbSet<Administratorregisters> Administratorregisters { get; set; }

		public DbSet<Studentregister> Studentregisters { get; set; }

		public DbSet<Teacherregister> Teacherregisters { get; set; }

		public DbSet<Staffregister> Staffregisters { get; set; }

		public DbSet<Courseadd> Courseadds { get; set; }

		public DbSet<Ajaxtest> Ajaxtests { get; set; }

		public DbSet<Complain> Complains { get; set; }

		public DbSet<Notice> notices { get; set; }*/


    }
}
