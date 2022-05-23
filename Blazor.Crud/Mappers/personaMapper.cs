using Blazor.Crud.Interface;
using Blazor.Crud.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Blazor.Crud.Mappers
{
    public class personaMapper : IPersona
    {
        //traer conexion con la bd

        private readonly ConnectionDB connection;
        public string connectionString = "";

        List<Persona> lista;
        Persona p;

        public personaMapper(ConnectionDB configuracion)
        {

            connection = configuracion;
            connectionString = connection.ConnectionString;
        }

        public void delete(int id)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                con.Query("delete from personas where id=@id", new { id=id}).ToList();
                con.Close();
            }
        }

        public List<Persona> getAllPeople()
        {
            lista = new List<Persona>();
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                lista= con.Query<Persona>("select * from personas").ToList();
                con.Close();
            }
            return lista;
        }

        public void saveorUpdate(Persona p)
        {
            if (p.Id != 0)
            {
                using (IDbConnection con = new SqlConnection(connectionString))
                {
                    string sql = "update personas set nombre=@nombre, set apellido=@apellido, set ciudad=@ciudad where id=@id";
                    if (con.State == ConnectionState.Closed) con.Open();
                    con.Execute(sql, new { id = p.Id, nombre = p.Nombre, apellido = p.Apellido, ciudad = p.Ciudad });
                    con.Close();
                }
            }
            else
            {
                using (IDbConnection con = new SqlConnection(connectionString))
                {
                    string sql = "insert into personas(nombre,apellido,ciudad) values(@nombre,@apellido,@ciudad)";
                    if (con.State == ConnectionState.Closed) con.Open();
                    con.Execute(sql, new {nombre = p.Nombre, apellido = p.Apellido, ciudad = p.Ciudad });
                    con.Close();
                }
            }
        }

        public Persona searchPerson(int id)
        {
            p = new Persona();
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                p = con.QueryFirst<Persona>("select * from personas where id=@id", new { id = id });
                con.Close();
            }
            return p;
        }
    }
}
