using AReport.Support.Query;
using AReport.DAL.Data;

namespace AReport.Srv.Query
{
    internal class ClaveMesQueryHandler
    {
        private ClaveMesData _data;

        // para inyectar dependencias ClaveMesQueryData
        public ClaveMesQueryHandler(ClaveMesData data)
        { _data = data; }


        public ClaveMesQueryResult Handle(ClaveMesQuery query)
        {
            return new ClaveMesQueryResult(_data.QueryCollection());
        }

    }
}
