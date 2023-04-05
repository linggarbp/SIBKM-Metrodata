using Connection.Models;
using Connection.Repositories.Interface;
using Connection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Controllers;
public class CountryController
{
    private readonly ICountryRepository _countryRepository;
    private readonly VCountry _vCountry;

    public CountryController(ICountryRepository countryRepository, VCountry vCountry)
    {
        _countryRepository = countryRepository;
        _vCountry = vCountry;
    }

    //GET ALL
    public void GetAll()
    {
        var countries = _countryRepository.GetAll();
        if (countries == null)
            _vCountry.DataNotFound();
        if (countries != null)
            _vCountry.GetAll(countries);
    }

    public void GetById(string id)
    {
        var country = _countryRepository.GetById(id);
        if (country == null)
            _vCountry.DataNotFound();
        if (country != null)
            _vCountry.GetById(country);
    }

    public void Insert(Country country)
    {
        var result = _countryRepository.Insert(country);
        if (result > 0)
        {
            _vCountry.Success("Inserted");
        }
        else
        {
            _vCountry.Failure("Insert");
        }
    }

    public void Update(Country country)
    {
        var result = _countryRepository.Update(country);
        if (result > 0)
        {
            _vCountry.Success("Updated");
        }
        else
        {
            _vCountry.Failure("Update");
        }
    }

    public void Delete(string id)
    {
        var result = _countryRepository.Delete(id);
        if (result > 0)
        {
            _vCountry.Success("Deleted");
        }
        else
        {
            _vCountry.Failure("Delete");
        }
    }
}
