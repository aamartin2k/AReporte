
using AReport.Support.Entity;
using AReport.DAL.Writer;
using AReport.DAL.Reader;
using System;

namespace AReport.DAL.Entity
{
    public class DepartamentoDataHandler : EntityDataHandler<Departamento>
    {
        protected override ObjectWriterBase<Departamento> GetWriter()
        {
            return new DepartamentoWriter();
        }

        protected override ObjectReaderBase<Departamento> GetReader()
        {
            return new DepartamentoReader();
        }

       

    }
}
