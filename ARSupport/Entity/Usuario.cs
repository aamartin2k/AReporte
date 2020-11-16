using AReport.Support.Common;
using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    // Tabla:  AA_Usuarios
    [Serializable]
    public class Usuario : IEntityStatus 
    {
        public EntityState Status
        { get; set; }


       
        public string UserID
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
