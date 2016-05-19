using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1
{
    [Serializable]
    public enum TriangleType
    {
        Error = 0,
        Equilateral = 1,
        Isosceles = 2,
        Scalene = 3
    }
}