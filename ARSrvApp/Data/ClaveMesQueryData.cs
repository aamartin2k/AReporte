using AReport.DAL.Entity;
using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System;

namespace AReport.Srv.Data
{
    internal class ClaveMesQueryData : CollectionQueryData<ClaveMes>
    {
       
        protected override EntityDataHandler<ClaveMes> GetDataHandler()
        {
            return new ClaveMesDataHandler();
        }
    }
}
