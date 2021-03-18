
using System;
using System.Collections.ObjectModel;

namespace AReport.Support.Interface
{
    // Lectura de Coleccion.
    public interface ICollectionRead<T>
    {
        Collection<T> QueryCollection();
    }

    // nueva INt
    public interface ICollectionReadByInt<T>
    {
        Collection<T> QueryCollection(int param1);
    }


    public interface ICollectionReadByStringDate<T>
    {
        Collection<T> QueryCollection(string param1, DateTime param2);
    }

    public interface ICollectionReadByStringString<T>
    {
        Collection<T> QueryCollection(string param1, string param2);
    }

    public interface ICollectionReadByStringInt<T>
    {
        Collection<T> QueryCollection(string param1, int param2);
    }


    // Escritura de Coleccion.
    public interface ICollectionWrite<T>
    {
        bool WriteCollection(Collection<T> collection);
    }


    // Lectura de Entidad
    public interface IEntityRead<T>
    {
       
        T QueryEntity(int id);

        T QueryEntity(string id);
    }

    public interface IEntityReadByIntInt<T>
    {
        T QueryEntity(int param1, int param2);
    }

    public interface IEntityReadByStringInt<T>
    {
        T QueryEntity(string param1, int param2);
    }

    public interface IEntityWrite<T>
    {
        
        bool WriteEntity(T entity);
    }
}
