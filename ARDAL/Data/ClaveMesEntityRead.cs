using AReport.Support.Entity;
using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AReport.DAL.Reader;

namespace AReport.DAL.Data
{
    class ClaveMesEntityRead : EntityReadBase<ClaveMes>, IEntityRead<ClaveMes>
    {
       

        public ClaveMes QueryEntity(int id)
        {
            return  this.QueryEntity(id);
        }


        public ClaveMes QueryEntity(string id)
        {
            throw new NotImplementedException();
        }

        protected override ObjectReaderBase<ClaveMes> GetReader()
        {
            return new ClaveMesByIdReader();
        }
    }
}
