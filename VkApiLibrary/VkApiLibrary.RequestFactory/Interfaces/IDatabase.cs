using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiLibrary.Factory.Models;

namespace VkApiLibrary.Factory.Interfaces
{
    public interface IDatabase
    {
        VkResponse<GetCountries> GetCountries();
    }
}
