using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorewebApiAngular.Models;

namespace CorewebApiAngular.Models
{
    public class PayementDetailContext: DbContext
    {
        public PayementDetailContext(DbContextOptions<PayementDetailContext>options):base(options)
        {

        }
        public DbSet<PayementDetail> PayementDetails { get; set; }
        public DbSet<CorewebApiAngular.Models.Employé> Employé { get; set; }
    }
}
