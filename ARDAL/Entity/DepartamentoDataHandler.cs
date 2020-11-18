
using AReport.Support.Entity;
using AReport.DAL.Writer;
using AReport.DAL.Reader;
using System;

namespace AReport.DAL.Entity
{
    public class DepartamentoDataHandler : EntityDataHandler<Dept>
    {
        protected override ObjectReaderBase<Dept> GetReader()
        {
            return new DepartamentoReader();
        }

        protected override ObjectWriterBase<Dept> GetWriter()
        {
            throw new NotImplementedException();
        }

        

       

    }
}
