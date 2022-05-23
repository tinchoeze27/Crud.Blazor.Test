using Blazor.Crud.Models;

namespace Blazor.Crud.Interface
{
    public interface IPersona
    {

        public List<Persona> getAllPeople();

        public void saveorUpdate(Persona p);

        public void delete(int id);

        public Persona searchPerson(int id);


    }
}
