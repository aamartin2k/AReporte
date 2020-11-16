using AReport.Support.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;

namespace AReport.DAL.Writer
{
    class DiaSemanaWriter : IntermWriter<DiaSemana>
    {
        protected override EntityWriter<DiaSemana> GetDeleteWriter
        {
            get
            {
                return new DiaSemanaDelete();
            }
        }

        protected override EntityWriter<DiaSemana> GetInsertWriter
        {
            get
            {
                return new DiaSemanaInsert();
            }
        }

        protected override EntityWriter<DiaSemana> GetUpdateWriter
        {
            get
            {
                return new DiaSemanaUpdate();
            }
        }
    }
}
