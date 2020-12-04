using AReport.Srv.Data;
using AReport.Support.Command;
using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Srv.Command
{
    internal abstract class EntityUpdateCommandHandler<T> 
    {

        protected abstract EntityUpdateCommandData<T> GetData();

        public CommandStatus Handle(EntityUpdateCommand<T> command)
        {
            EntityUpdateCommandData<T> _data = GetData();
            bool ret;
           
            try
            {
                ret = _data.Update(command.Entity);
                return new Success();
            }
            catch (Exception ex)
            {
                // Notify, log
                return new Failure(ex.Message);
               
            }

        }
    }
}
