﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSTowersOffice.Api.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WSTowersOfficeEntities : DbContext
    {
        public WSTowersOfficeEntities()
            : base("name=WSTowersOfficeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Team_Employee> Team_Employee { get; set; }
        public virtual DbSet<Team_Role> Team_Role { get; set; }
    }
}