using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Fgcm.Dale.Data
{
    public interface IConnectionStringProvider
    {
        string ConnectionString { get; set; }
    }
}
