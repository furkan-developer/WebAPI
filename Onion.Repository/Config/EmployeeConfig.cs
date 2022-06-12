using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Entities.Models;

namespace Onion.Repository.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = new Guid("6019da1c-2aaf-4221-a788-10e5dbb7e1da"),
                    FirstName = "Furkan",
                    LastName =  "AYDIN",
                    ProjectId = new Guid("b67e3d43-23ef-444f-a022-5294810a5428")
                });
        }
    }
}
