using AReport.Support.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;
using System;

namespace AReport.DAL.Entity
{
    public class ClaveMesDataHandler :  EntityDataHandler<ClaveMes>
    {
        protected override ObjectWriterBase<ClaveMes> GetWriter()
        {
            return new ClaveMesWriter();
        }

        protected override ObjectReaderBase<ClaveMes> GetReader()
        {
            return new ClaveMesReader();
        }

        protected override ObjectReaderBase<ClaveMes> GetEntityByIdReader()
        {
            return new ClaveMesByIdReader();
        }


        // metodos no derivados
        public ObjectReaderBase<ClaveMes> GetEntityMesAnnoReader()
        {
            return new ClaveMesByIdReader();
        }
    }
}
