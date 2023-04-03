using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Repositories.Interface;
public interface IRegionRepository
{
    List<Region> GetAll();
    Region GetById(int id);
    int Insert (Region region);
    int Update (Region region);
    int Delete (int id);
}
