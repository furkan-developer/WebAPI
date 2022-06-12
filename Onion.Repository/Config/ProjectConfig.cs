using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Repository.Config
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(
                new Project
                {
                    Id = new Guid("b67e3d43-23ef-444f-a022-5294810a5428"),
                    Name = "ASP.NET Core Web API Project",
                    Description = "Onion Architecture",
                    Field = "Computer Science"
                });
        }      
    }
}
