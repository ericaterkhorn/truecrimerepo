using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCrimeRepo.Models;

namespace TrueCrimeRepo.Contracts
{
    //An interface is a type that defines a contract between an object and the interface
    public interface ICrimeService
    {
        //properties
        //method signatures
        
        bool CreateCrime(CrimeCreate model);
        IEnumerable<CrimeListItem> GetCrimes();
        bool DeleteCrime(int crimeID);
        CrimeDetail GetCrimeById(int id);
        bool UpdateCrime(CrimeEdit model);
        


    }
}
