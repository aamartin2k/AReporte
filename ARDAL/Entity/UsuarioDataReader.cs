using AReport.DAL.Reader;
using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.DAL.Entity
{
    public class UsuarioDataReader
    {
        public Collection<Usuario> Collection
        {
            get
            {
                UsuarioReader reader = new UsuarioReader();
                Collection<Usuario> usuarios = reader.Execute();
                return usuarios;
            }
        }

    }
}
