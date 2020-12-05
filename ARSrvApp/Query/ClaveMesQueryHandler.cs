using AReport.Support.Query;
using AReport.DAL.Data;
using AReport.Support.Entity;
using AReport.Support.Interface;

namespace AReport.Srv.Query
{
    internal class ClaveMesQueryHandler
    {
        private ICollectionRead<ClaveMes> _data;

        // para inyectar dependencias ClaveMesQueryData
        public ClaveMesQueryHandler(ICollectionRead<ClaveMes> data)
        { _data = data; }


        public ClaveMesQueryResult Handle(ClaveMesQuery query)
        {
            return new ClaveMesQueryResult(_data.QueryCollection());
        }

    }
}
