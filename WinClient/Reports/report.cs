﻿

namespace AReport.Client.Reports
{
    internal class myReport
    {
        public static string ReportAsString
        {
            get { return _report; }
        }

        private static string _report =
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            "<Report ScriptLanguage=\"CSharp\" ReportInfo.Created=\"06/20/2009 23:03:47\" ReportInfo.Modified=\"12/23/2020 21:56:36\" ReportInfo.CreatorVersion=\"2020.4.4.0\">" +
            "  <Dictionary>" +
            "    <BusinessObjectDataSource Name=\"Empleados\" ReferenceName=\"Empleados\" DataType=\"System.Collections.Generic.List`1[[DataFromBusinessObject.Empleado, DataFromBusinessObject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]\" Enabled=\"true\">" +
            "      <Column Name=\"Nombre\" DataType=\"System.String\"/>" +
            "      <Column Name=\"Code\" DataType=\"System.String\"/>" +
            "      <Column Name=\"Departamento\" DataType=\"System.String\"/>" +
            "      <BusinessObjectDataSource Name=\"Asistencias\" DataType=\"System.Collections.Generic.List`1[[DataFromBusinessObject.Asistencia, DataFromBusinessObject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]\" Enabled=\"true\">" +
            "        <Column Name=\"Fecha\" DataType=\"System.String\"/>" +
            "        <Column Name=\"DiaSemana\" DataType=\"System.String\"/>" +
            "        <Column Name=\"ChekinTime\" DataType=\"System.String\"/>" +
            "        <Column Name=\"ChekoutTime\" DataType=\"System.String\"/>" +
            "        <Column Name=\"IncidenciaCausaIncidencia\" DataType=\"null\"/>" +
            "        <Column Name=\"IncidenciaObservacion\" DataType=\"System.String\"/>" +
            "      </BusinessObjectDataSource>" +
            "    </BusinessObjectDataSource>" +
            "    <Parameter Name=\"parNombreMesAnno\" DataType=\"System.String\"/>" +
            "  </Dictionary>" +
            "  <ReportPage Name=\"Page1\" PaperWidth=\"215.9\" PaperHeight=\"279.4\" RawPaperSize=\"1\" FirstPageSource=\"15\" OtherPagesSource=\"15\" LastPageSource=\"15\" Watermark.Font=\"Arial, 60pt\">" +
            "    <PageHeaderBand Name=\"PageHeader1\" Width=\"740.5\" Height=\"33.1\">" +
            "      <TextObject Name=\"txtTitulo\" Top=\"9.45\" Width=\"718.2\" Height=\"28.35\" Text=\"GRUPO CAUDAL                 REPORTE DE ASISTENCIA\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"Arial, 12pt, style=Bold\"/>" +
            "      <LineObject Name=\"Line1\" Top=\"33.0\" Width=\"737.1\"/>" +
            "    </PageHeaderBand>" +
            "    <DataBand Name=\"Data1\" Top=\"39.76\" Width=\"740.5\" Height=\"132.3\" StartNewPage=\"true\" DataSource=\"Empleados\" KeepTogether=\"true\">" +
            "      <ShapeObject Name=\"shFondo\" Left=\"151.2\" Top=\"9.45\" Width=\"415.8\" Height=\"94.5\" Fill.Color=\"SandyBrown\"/>" +
            "      <TextObject Name=\"txtNombre\" Left=\"151.2\" Width=\"415.8\" Height=\"47.25\" Text=\"Nombre: [Empleados.Nombre]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"Arial, 12pt, style=Bold\"/>" +
            "      <TextObject Name=\"txtMesAño\" Left=\"151.2\" Top=\"47.25\" Width=\"415.8\" Height=\"18.9\" Text=\"Tarjeta de Asistencia de [parNombreMesAnno]\" HorzAlign=\"Center\" Font=\"Arial, 10pt, style=Bold\"/>" +
            "      <TextObject Name=\"txtCodigo\" Left=\"151.2\" Top=\"66.15\" Width=\"415.8\" Height=\"18.9\" Text=\"Número: [Empleados.Code]\" HorzAlign=\"Center\" Font=\"Arial, 9pt\"/>" +
            "      <TextObject Name=\"txtDepartamento\" Left=\"151.2\" Top=\"85.05\" Width=\"415.8\" Height=\"18.9\" Text=\"Departamento: [Empleados.Departamento]\" HorzAlign=\"Center\" Font=\"Arial, 9pt\"/>" +
            "      <TextObject Name=\"Text6\" Top=\"113.4\" Width=\"75.6\" Height=\"18.9\" Border.Lines=\"Left, Right, Top\" Text=\"Fecha\" VertAlign=\"Center\" Font=\"Arial, 10pt, style=Bold\"/>" +
            "      <TextObject Name=\"Text7\" Left=\"75.6\" Top=\"113.4\" Width=\"37.8\" Height=\"18.9\" Border.Lines=\"Right, Top\" Text=\"Dia\" VertAlign=\"Center\" Font=\"Arial, 10pt, style=Bold\" />    " +
            "      <TextObject Name=\"Text10\" Left=\"113.4\" Top=\"113.4\" Width=\"68.04\" Height=\"18.9\" Border.Lines=\"Right, Top\" Text=\"Entrada\" VertAlign=\"Center\" Font=\"Arial, 10pt, style=Bold\"/>" +
            "      <TextObject Name=\"Text11\" Left=\"179.55\" Top=\"113.4\" Width=\"68.04\" Height=\"18.9\" Border.Lines=\"Right, Top\" Text=\"Salida\" VertAlign=\"Center\" Font=\"Arial, 10pt, style=Bold\"/>" +
            "      <TextObject Name=\"Text13\" Left=\"245.7\" Top=\"113.4\" Width=\"198.45\" Height=\"18.9\" Border.Lines=\"Right, Top\" Text=\"Incidencia\" VertAlign=\"Center\" Font=\"Arial, 10pt, style=Bold\"/>" +
            "      <TextObject Name=\"Text14\" Left=\"444.15\" Top=\"113.4\" Width=\"292.95\" Height=\"18.9\" Border.Lines=\"Right, Top\" Text=\"Observación\" VertAlign=\"Center\" Font=\"Arial, 10pt, style=Bold\"/>" +
            "      <LineObject Name=\"Line3\" Top=\"130.03\" Width=\"737.1\" Border.Width=\"1.5\"/>" +
            "      <DataBand Name=\"Data2\" Top=\"174.02\" Width=\"740.5\" Height=\"18.9\" CanGrow=\"true\" CanShrink=\"true\" Guides=\"18.9\" DataSource=\"Asistencias\" KeepTogether=\"true\">" +
            "        <TextObject Name=\"txtFecha\" Width=\"75.6\" Height=\"18.9\" Border.Lines=\"Left, Right, Bottom\" CanGrow=\"true\" CanShrink=\"true\" GrowToBottom=\"true\" Text=\"[Empleados.Asistencias.Fecha]\" VertAlign=\"Center\" Font=\"Arial, 10pt\"/>" +
            "        <TextObject Name=\"txtDia\" Left=\"75.6\" Width=\"37.8\" Height=\"18.9\" Border.Lines=\"Right, Bottom\" CanGrow=\"true\" CanShrink=\"true\" GrowToBottom=\"true\" Text=\"[Empleados.Asistencias.DiaSemana]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"Arial, 10pt\"/>" +
            "        <TextObject Name=\"txtEntrada\" Left=\"113.4\" Width=\"68.04\" Height=\"18.9\" Border.Lines=\"Right, Bottom\" CanGrow=\"true\" CanShrink=\"true\" GrowToBottom=\"true\" Text=\"[Empleados.Asistencias.ChekinTime]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"Arial, 10pt\"/>" +
            "        <TextObject Name=\"txtSalida\" Left=\"179.55\" Width=\"68.04\" Height=\"18.9\" Border.Lines=\"Right, Bottom\" CanGrow=\"true\" CanShrink=\"true\" GrowToBottom=\"true\" Text=\"[Empleados.Asistencias.ChekoutTime]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"Arial, 10pt\"/>" +
            "        <TextObject Name=\"txtIncidencia\" Left=\"245.7\" Width=\"198.45\" Height=\"18.9\" Border.Lines=\"Right, Bottom\" CanGrow=\"true\" CanShrink=\"true\" GrowToBottom=\"true\" Text=\"[Empleados.Asistencias.IncidenciaCausaDesc]\" VertAlign=\"Center\" Font=\"Arial, 10pt\"/>" +
            "        <TextObject Name=\"txtObservacion\" Left=\"444.15\" Width=\"292.95\" Height=\"18.9\" Border.Lines=\"Right, Bottom\" CanGrow=\"true\" CanShrink=\"true\" GrowToBottom=\"true\" Text=\"[Empleados.Asistencias.IncidenciaObservacion]\" VertAlign=\"Center\" Font=\"Arial, 10pt\"/>" +
            "      </DataBand>" +
            "    </DataBand>" +
            "  </ReportPage>" +
            "</Report>";

    }
}
