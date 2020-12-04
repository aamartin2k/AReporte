using AReport.Support.Interface;
using AReport.Support.Entity;
using System.Collections.ObjectModel;
using AReport.DAL.Writer;
using System;

namespace AReport.DAL.Data
{
    class FechaMesCollectionWrite : CollectionWriteBase<FechaMes>, ICollectionWrite<FechaMes>
    {
        public bool WriteCollection(Collection<FechaMes> collection)
        {
            return  WriteCollection(collection);
        }

        protected override ObjectWriterBase<FechaMes> GetWriter()
        {
            return new FechaMesWriter();
        }
    }
}
