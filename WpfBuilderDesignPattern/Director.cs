using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBuilderDesignPattern
{
    public class Director
    {
        private readonly IComputerBuilder _builder;

        public Director(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public Computer BuildPC()
        {
            _builder.AddProcessor();
            _builder.AddRAM();
            _builder.AddStorage();
            _builder.AddGraphicsCard();
            return _builder.GetComputer();
        }
    }
}
