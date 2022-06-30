using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TrainersMVC.Models;

namespace TrainersMVC.Configurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}