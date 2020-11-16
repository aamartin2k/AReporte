

namespace AReport.Support.Entity
{
    // Unchanged toma valor Cero. Al crear nuevas entidades la propiedad se hace cero por defecto
    // coincidiendo con el estado de la entidad. No es necesario actualizar la propiedad 
    // en el momentoi de crear la entidad.
    public enum EntityState
    { Unchanged, Added, Modified, Deleted }
}
