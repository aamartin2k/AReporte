using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    /*
    CREATE TABLE [dbo].[AA_ClavesMes](
   [MesId] [int] IDENTITY(1,1) NOT NULL,
   [Mes] [int] NOT NULL,
   [Anno] [int] NOT NULL,
    */

    public abstract class ClaveMesTableData : TableDataBase<ClaveMes>
    {
        protected override string TableName
        { get { return "[AA_ClavesMes]"; } }

        protected override string ParamPKId
        { get { return "@Id"; } }


        protected string ParamMes
        { get { return "[@Mes]"; } }
        protected string ParamAnno
        { get { return "[@Anno]"; } }

    }
}
