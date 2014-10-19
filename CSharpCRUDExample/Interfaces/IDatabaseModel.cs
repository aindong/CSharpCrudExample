using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharpCRUDExample.Models;
using MySql.Data.MySqlClient;

namespace CSharpCRUDExample.Interfaces
{
    // We will create a generic interface
    // to create a rule that all models that we create must contain this functions
    // this is also like a class or a blueprint, and it's just a rule to make everything
    // organize and generic, so please don't worry
    public interface IDatabaseModel<T>
    {
        // A function for creating a new object (INSERT)
        void Create();

        // A function for retrieving the full database object (SELECT)
        List<T> Retrieve();

        // A function to get an object by ID
        T FindById(int id);

        // A function to update a record
        void Update(T item);

        // A function to delete a record
        void Delete(int id);
    }
}
