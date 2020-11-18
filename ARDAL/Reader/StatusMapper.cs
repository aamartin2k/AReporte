using System;
using AReport.Support.Entity;
using AReport.Support.Interface;

namespace AReport.DAL.Reader
{
    class StatusMapper : DescriptorMapper<Status>
    {
        protected override string DescriptionFieldName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override IDescriptor GetEntity
        {
            get { return new Status(); }
        }

       

        protected override string IdFieldName
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
