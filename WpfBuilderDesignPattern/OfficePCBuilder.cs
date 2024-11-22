using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBuilderDesignPattern
{
    public class OfficePCBuilder : IComputerBuilder
    {
        private readonly Computer _computer = new Computer();

        public void AddProcessor()
        {
            _computer.Processor = "Intel i5";
        }

        public void AddRAM()
        {
            _computer.RAM = "16GB DDR4";
        }

        public void AddStorage()
        {
            _computer.Storage = "512GB SSD";
        }

        public void AddGraphicsCard()
        {
            _computer.GraphicsCard = "Integrated Graphics";
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
