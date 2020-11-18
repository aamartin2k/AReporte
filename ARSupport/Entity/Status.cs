using AReport.Support.Interface;
using System;

namespace AReport.Support.Entity
{
    /*
     CREATE TABLE [dbo].[Status](
	   > [Statusid] [int] NOT NULL,
	     [StatusChar] [varchar](2) NOT NULL,
	   > [StatusText] [varchar](50) NOT NULL,
    */
    // No se leen todos las columnas, solo las necesarias para usar como descriptor.
    [Serializable]
    public class Status : IEntityStatus, IDescriptor
    {
        public EntityState State
        { get; set; }

        public int Id
        { get; set; }

        public string Description
        { get; set; }
    }
}
