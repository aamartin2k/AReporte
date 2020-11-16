using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.DAL.Writer
{
    class DepartamentoWriter : IntermWriter<Departamento> 
    {
        protected override EntityWriter<Departamento> GetDeleteWriter
        {
            get
            {
                return new DepartamentoDelete();
            }
        }

        protected override EntityWriter<Departamento> GetInsertWriter
        {
            get
            {
                return new DepartamentoInsert();
            }
        }

        protected override EntityWriter<Departamento> GetUpdateWriter
        {
            get
            {
                return new DepartamentoUpdate();
            }
        }
    }
}
