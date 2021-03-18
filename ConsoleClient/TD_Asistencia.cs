using AReport.DAL.Data;
using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ConsoleClient
{
    partial class Test_DAL
    {
        // reader
        private static AsistenciaData _reader;

        // helpers
        static void CreateReader()
        {
            AsistenciaData reader = new AsistenciaData();
            _reader = reader;
        }

        static Collection<Asistencia> ReadAsistencia(AsistenciaData reader)
        {
            Collection<Asistencia> people = reader.QueryCollection();

            Console.WriteLine(string.Format("Leída Coleccion Asistencia: {0} entidades", people.Count));

            return people;
        }

        static void PrintOutAsistencia(Collection<Asistencia> people, int total = 15)
        {
            int count = 0;
            foreach (Asistencia p in people)
            {
                Console.WriteLine(string.Format("Entity Id: {0}\t Fecha Id: {1}\tUser Id: {2}\tChekIn Id: {3}\tChekOut Id: {4}\tIncidencia Id: {5}"
                    , p.Id, p.FechaId, p.UserId, p.ChekInId, p.ChekOutId, p.IncidenciaId));
                count++;
                if (count > total)
                    break;

            }
        }

        static void ReadEntidadAsistencia(AsistenciaData reader, int id)
        {
            
            Asistencia p = reader.QueryEntity(id);

            //Console.WriteLine(string.Format("Entity Id: {0}\t Fecha Id: {1}\tUser Id: {2}\tChekIn Id: {3}\tChekOut Id: {4}\tCausa Id: {5}"
            //        , p.Id, p.FechaId, p.UserId, p.ChekInId, p.ChekOutId, p.IncidenciaId));  

            Collection<Asistencia> ent = new Collection<Asistencia>();
            ent.Add(p);
            PrintOutAsistencia(ent);
        }

        static void ReadEntidadAsistenciaUserFecha(AsistenciaData reader, string userId, int fechaId)
        {
            Asistencia p = reader.QueryEntity(userId, fechaId);

            Collection<Asistencia> ent = new Collection<Asistencia>();
            ent.Add(p);
            PrintOutAsistencia(ent);
        }

        // AsistenciaCollectionReadByIncidenciaId
        static void ReadAsistenciaByIncidenciaId(AsistenciaData reader, Collection<Asistencia> people)
        {
            // Buscar asistencia con incidencia no nula
            var awi = people.Where(asi => asi.IncidenciaId != 0).Skip(5).First();

            Collection<Asistencia> col = reader.QueryCollection(awi.IncidenciaId);

            PrintOutAsistencia(col);
        }


        // Main Test
        static void Test_AsistenciaReadEnt()
        {
            CreateReader();

            Collection<Asistencia> people;

            // leer Asistencia
            Console.WriteLine("Lectura Inicial");
            people = ReadAsistencia(_reader);
            PrintOutAsistencia(people);

            // leer Entidad Asistencia por Id
            Console.WriteLine("Lectura Entidad 1 Asistencia por Id");
            ReadEntidadAsistencia(_reader, people[0].Id);

            Console.WriteLine("Lectura Entidad 10 Asistencia por Id");
            ReadEntidadAsistencia(_reader, people[10].Id);

            Console.WriteLine("Lectura Entidad 2 Asistencia por Usuario y Fecha");
            ReadEntidadAsistenciaUserFecha(_reader, people[2].UserId, people[2].FechaId);

            Console.WriteLine("Lectura Entidad 11 Asistencia por Usuario y Fecha");
            ReadEntidadAsistenciaUserFecha(_reader, people[11].UserId, people[11].FechaId);

            // leer coleccion de Asistencia con la misma IncidenciaId
            Console.WriteLine("Lectura coleccion de Asistencia con la misma IncidenciaId");
            ReadAsistenciaByIncidenciaId(_reader, people);


        }
    }
}
