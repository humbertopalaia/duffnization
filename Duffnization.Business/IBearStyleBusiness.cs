using Duffnization.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duffnization.Business
{
    public interface IBearStyleBusiness
    {
        BearStyle GetByTemperature(int temperature);
    }
}
