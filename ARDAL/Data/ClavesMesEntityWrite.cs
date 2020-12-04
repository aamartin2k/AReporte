using AReport.Support.Entity;
using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AReport.DAL.Writer;

namespace AReport.DAL.Data
{
    class ClaveMesEntityWrite : EntityWriteBase<ClaveMes>, IEntityWrite<ClaveMes>
    {
        public bool WriteEntity(ClaveMes entity)
        {
            return Write(entity);
        }

        protected override ObjectWriterBase<ClaveMes> GetWriter()
        {
            return new ClaveMesWriter();
        }
    }
}
