using AReport.DAL.Entity;
using AReport.Support.Entity;
using System.Collections.ObjectModel;

namespace AReport.Srv.Data
{
    internal class ClaveMesQueryData
    {
        private ClaveMesDataHandler _dataReader;

        public ClaveMesQueryData(ClaveMesDataHandler dataReader)
        {
            _dataReader = dataReader;
        }

        public Collection<ClaveMes> ClavesMes
        {
            get { return _dataReader.Collection; }

        }
    }
}
