using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TrainersMVC.Models;

namespace TrainersMVC.Configurations
{
    public class TrainerConfiguration : EntityTypeConfiguration<Trainer>
    {
        public TrainerConfiguration()
        {
            Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(60);

            Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(60);

            Ignore(t => t.FullName);

            Ignore(t => t.ImageFile);
        }
    }
}