using AReport.Support.Common;
using AReport.Support.Interface;
using System;


namespace AReport.Support.Entity
{
    // Tabla:  AA_Usuarios  Usuarios del sistema

    [Serializable]
    public class Usuario : IEntityStatus 
    {
        public EntityState Status
        { get; set; }

        public int Id
        { get; set; }

        public string UserId
        { get; set; }

        public string Login
        { get; set; }
        public string Password
        { get; set; }

        public int RoleId
        { get; set; }

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
    }
}
