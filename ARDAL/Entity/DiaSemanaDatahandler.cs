using AReport.Support.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;
using System;

namespace AReport.DAL.Entity
{
    public class DiaSemanaDataHandler : EntityDataHandler<DiaSemana>
    {
        protected override ObjectWriterBase<DiaSemana> GetWriter()
        {
            return new DiaSemanaWriter();
        }

        protected override ObjectReaderBase<DiaSemana> GetReader()
        {
            return new DiaSemanaReader();
        }

        protected override ObjectReaderBase<DiaSemana> GetEntityByIdReader()
        {
            throw new NotImplementedException();
        }
    }
}
