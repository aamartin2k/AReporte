using AReport.DAL.Reader;


namespace AReport.DAL.Data
{
    abstract class EntityReadBase<T>
    {
        protected abstract ObjectReaderBase<T> GetReader();

        protected T GetEntity(int id)
        {
            ObjectReaderBase<T> reader = GetReader();
            T entity = reader.ReadEntityById(id);
            return entity;
        }

        protected T GetEntity(string id)
        {
            ObjectReaderBase<T> reader = GetReader();
            T entity = reader.ReadEntityById(id);
            return entity;
        }

        protected T GetEntity(int param1, int param2)
        {
            ObjectReaderBase<T> reader = GetReader();
            T entity = reader.ReadEntityBy2Params(param1, param2);
            return entity;
        }

        protected T GetEntity(string param1, int param2)
        {
            ObjectReaderBase<T> reader = GetReader();
            T entity = reader.ReadEntityByStringKeyAndIntKey(param1, param2);
            return entity;
        }

        

    }
}
