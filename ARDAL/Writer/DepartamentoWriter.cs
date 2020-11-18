using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.DAL.Writer
{
    class DepartamentoWriter : IntermWriter<Dept> 
    {
        protected override EntityWriter<Dept> GetDeleteWriter
        {
            get
            {
                return new DepartamentoDelete();
            }
        }

        protected override EntityWriter<Dept> GetInsertWriter
        {
            get
            {
                return new DepartamentoInsert();
            }
        }

        protected override EntityWriter<Dept> GetUpdateWriter
        {
            get
            {
                return new DepartamentoUpdate();
            }
        }
    }
}
