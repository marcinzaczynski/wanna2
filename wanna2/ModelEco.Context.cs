﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wanna2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ecoplastolEntities : DbContext
    {
        public static string WannaCS = WindowMain.WannaCS;

        public ecoplastolEntities()
        : base(WannaCS)
        //: base("name=ecoplastolEntities")
        {

        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<wanna_lista_badan> wanna_lista_badan { get; set; }
        public virtual DbSet<wanna_probki_cisnienia> wanna_probki_cisnienia { get; set; }
        public virtual DbSet<wanna_probki_temperatury> wanna_probki_temperatury { get; set; }
    }
}
