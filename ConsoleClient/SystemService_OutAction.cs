#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios de sistema.
 *  
 *  Parcial Acciones de Salida (Solicitudes) al servidor
*/
#endregion

#region Using

using AMGS.Application.Utils.Dialogs;
using AMGS.Application.Utils.Log;
using AReport.Support.Command;
using AReport.Support.Common;
using AReport.Support.Entity;
using AReport.Support.Interface;
using AReport.Support.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Zyan.Communication;
using Zyan.Communication.Toolbox;

#endregion

namespace ConsoleClient
{
    internal static partial class SystemService
    {
        #region Salida de Solicitudes al servidor

        // Comandos
        public static Action<LoginCommand> Out_LoginCommand { get; set; }

        public static Action<AsistenciaUpdateCommand> Out_AsistenciaUpdateCommand { get; set; }


        // Consultas

        #endregion
    }

}