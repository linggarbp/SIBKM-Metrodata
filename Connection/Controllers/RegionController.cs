using Connection.Models;
using Connection.Repositories.Interface;
using Connection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Controllers;
public class RegionController
{
    private readonly IRegionRepository _regionRepository;
    private readonly VRegion _vRegion;

    public RegionController(IRegionRepository regionRepository, VRegion vRegion)
    {
        _regionRepository = regionRepository;
        _vRegion = vRegion;
    }

    //GET ALL
    public void GetAll()
    {
        var regions = _regionRepository.GetAll();
        if (regions==null)
            _vRegion.DataNotFound();
        if (regions != null)
            _vRegion.GetAll(regions);
    }

    public void GetById(int id)
    {
        var region = _regionRepository.GetById(id);
        if (region==null)
            _vRegion.DataNotFound();
        if (region!=null)
            _vRegion.GetById(region);
    }

    public void Insert(Region region)
    {
        var result = _regionRepository.Insert(region);
        if (result > 0)
        {
            _vRegion.Success("Inserted");
        }
        else
        {
            _vRegion.Failure("Insert");
        }
    }

    public void Update(Region region)
    {
        var result = _regionRepository.Update(region);
        if(result > 0)
        {
            _vRegion.Success("Updated");
        }
        else
        {
            _vRegion.Failure("Update");
        }
    }

    public void Delete(int id)
    {
        var result = _regionRepository.Delete(id);
        if(result > 0)
        {
            _vRegion.Success("Deleted");
        }
        else
        {
            _vRegion.Failure("Delete");
        }
    }
}
