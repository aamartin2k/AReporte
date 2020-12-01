using System;
using AReport.Srv.Data;
using AReport.Support.Command;
using AReport.Support.Entity;


namespace AReport.Srv.Command
{
    internal class AsistenciaUpdateCommandHandler : EntityUpdateCommandHandler<ConjuntoDatosAsistencia>
    {
        protected override EntityUpdateCommandData<ConjuntoDatosAsistencia> GetData()
        {
            return new AsistenciaUpdateCommandData();
        }
    }






}
