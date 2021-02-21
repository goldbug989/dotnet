using Dapper;
using Microsoft.Extensions.Configuration;
using MVCApp.Models.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MVCApp.Models.Repos
{
    public class PersonRepo : IPersonRepo
    {
        private readonly IConfiguration _configuration;

        public PersonRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //return idbconnection connection lambda
        private IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));


        public void AddPerson(Person person)
        {
            using (var connection = Connection)
            {
                connection.Execute($@"insert into dbo.Person
                                    (
                                    FirstName,
                                    LastName)

                                    values
                                    (
                                     @firstname,
                                     @lastname)"
                                     , new
                                     {
                                         firstname = person.FirstName,
                                         lastname = person.LastName
                                     });
            }

        }

        public IEnumerable<Person> GetPeople()
        {
            //could do this way... 
            // string conn = _configuration.GetConnectionString("DefaultConnection");
            // IDbConnection connectionExample = new SqlConnection(conn);

            using (var connection = Connection)
            {

                return connection.Query<Person>(@"select * from dbo.Person");
            }
        }

        public Person GetPersonById(int id)
        {
            using (var connection = Connection)
            {
                Person person = connection.Query<Person>($@"select * from dbo.Person
                                                    where PersonID = @Id"
                                                    , new
                                                    { Id = id }).FirstOrDefault();
                return person;
            }

        }

        public void Remove(int id)
        {
            using (var connection = Connection)
            {
                connection.Execute($@"
                            delete from dbo.Person
                            where PersonId = @ID"
                            , new { ID = id });
            }

        }

        public void Edit(Person person)
        {
            using (var conneciton = Connection)
            {
                Connection.Execute($@"
                            update dbo.Person set
                                FirstName = @firstName,
                                LastName = @lastName
                            where PersonId = @id"
                                , new
                                {
                                    Firstname = person.FirstName,
                                    LastName = person.LastName,
                                    id = person.PersonID
                                });
            }
        }
    }
}
