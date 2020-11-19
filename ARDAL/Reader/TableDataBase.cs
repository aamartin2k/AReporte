

namespace AReport.DAL.Reader
{
    public abstract class TableDataBase<T> 
    {

        protected abstract string TableName { get; }
       
        protected abstract string ParamPKId { get; }
    }
}
