using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.EF.Service
{
    public class ContextFactory : IDesignTimeDbContextFactory<EmpresaDBContext>
    {
        public EmpresaDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<EmpresaDBContext>();
            options.UseMySQL("Server=localhost;Database=empresa_EF;User=root;Password=;");
            return new EmpresaDBContext(options.Options);
        }
    }


}
