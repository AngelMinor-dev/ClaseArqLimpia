using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OC
{
    public interface IArea
    {
        double Area();
    }

    public class Square : IArea
    {
        public double lado { get; set; }
        
        public double Area()
        {
            return lado * lado;
        }
    }




    public class Calculadora
    {

        public void CalcularArea(IArea obj)
        { 
            obj.Area();
        }

    }
}
