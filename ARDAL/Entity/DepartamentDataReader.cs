using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AReport.DAL.Reader;

namespace AReport.DAL.Entity
{
    public class DepartamentoDataReader
    {
        public Collection<Departamento> Collection
        {
            get
            {
                DepartamentoReader reader = new DepartamentoReader();
                Collection<Departamento> depts = reader.Execute();
                return depts;
            }
        }
    }
}
