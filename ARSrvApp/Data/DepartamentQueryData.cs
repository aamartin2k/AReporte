using AReport.DAL.Entity;
using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Srv.Data
{
    internal class DepartamentQueryData
    {
        private DepartamentoDataReader _dataReader;

        public DepartamentQueryData(DepartamentoDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public Collection<Departamento> Departamentos
        {
            get { return _dataReader.Collection; }
           
        }
    }
}
