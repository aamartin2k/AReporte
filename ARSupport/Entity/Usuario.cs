using AReport.Support.Common;
using AReport.Support.Interface;
using System;


namespace AReport.Support.Entity
{
    // Tabla:  AA_Usuarios  Usuarios del sistema
    /*
      CREATE TABLE [dbo].[AA_Usuarios](
	    [Id] [int] IDENTITY(1,1) NOT NULL,
	    [UserId] [varchar](20) NOT NULL,
	    [RoleId] [int] NOT NULL,
	    [Login] [varchar](20) NOT NULL,
	    [Password] [varchar](20) NOT NULL,
     */
    [Serializable]
    public class Usuario : IEntity 
    {
        public int Id
        { get; set; }

        public EntityState State
        { get; set; }

        public string UserId
        { get; set; }

        public int RoleId
        { get; set; }

        public string Login
        { get; set; }

        public string Password
        { get; set; }

      
        // Propiedades para GUI
        public UserRoleEnum RoleIdEnum
        {
            get
            {
                return (UserRoleEnum)RoleId;
            }
            set
            {
                RoleId = (int)value;
            }
        }

        public string Nombre
        { get; set; }
    }
}
