using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using FluentNHibernate.Conventions.Inspections;
using Microsoft.EntityFrameworkCore;


namespace pajo22.Models
{
    public class AttributeValues
    {
        [Key]
        public int AttributeValueID { get; set; }

        // Foreign key for the attribute
        public int AttributeID { get; set; }
        public virtual Attributes Attribute { get; set; }

        // Foreign key for the product
        public int ProductModelId { get; set; }
        public virtual ProductModels ProductModel { get; set; }

        // The actual value 
        public string Value { get; set; }
    }
}