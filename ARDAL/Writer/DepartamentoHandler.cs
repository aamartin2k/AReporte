using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.DAL.Writer
{
    class DepartamentoHandler : ObjectWriterBase<Departamento>
    {
       
        protected override EntityWriter<Departamento> GetWriter(EntityState status)
        {
            EntityWriter<Departamento> writer = null;

            // select Writer
            switch (status)
            {
                case EntityState.Added:
                    writer = new DepartamentoInsert();
                    break;

                case EntityState.Modified:
                    writer = new DepartamentoUpdate();
                    break;

                case EntityState.Deleted:
                    writer = new DepartamentoDelete();
                    break;

                case EntityState.Unchanged:
                default:
                    break;
            }

            return writer;
        }
    }
}
