using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Repositories.Interface;
public interface ICountryRepository
{
    List<Country> GetAll();
    Country GetById(string id);
    int Insert(Country country);
    int Update(Country country);
    int Delete(string id);
}
