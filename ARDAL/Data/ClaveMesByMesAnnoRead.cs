using AReport.Support.Interface;
using AReport.Support.Entity;
using AReport.DAL.Reader;


namespace AReport.DAL.Data
{
    class ClaveMesByMesAnnoRead : EntityReadBase<ClaveMes>, IEntityReadByIntInt<ClaveMes>
    {
        public ClaveMes QueryEntity(int param1, int param2)
        {
            return QueryEntity(param1,  param2);
        }

        protected override ObjectReaderBase<ClaveMes> GetReader()
        {
            return new ClaveMesByMesAnnoReader();
        }
    }
}
