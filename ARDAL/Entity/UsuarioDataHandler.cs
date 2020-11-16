using AReport.DAL.Reader;
using AReport.DAL.Writer;
using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.DAL.Entity
{
    public class UsuarioDataHandler : EntityDataHandler<Usuario>
    {

        protected override ObjectWriterBase<Usuario> GetWriter()
        {
            return new UsuarioWriter(); 
        }

        protected override ObjectReaderBase<Usuario> GetReader()
        {
            return new UsuarioReader();
        }
    }
}
