using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBuilderDesignPattern
{
    public class GamingPCBuilder : IComputerBuilder
    {
        private readonly Computer _computer = new Computer();

        public void AddProcessor()
        {
            _computer.Processor = "Intel i9";
        }

        public void AddRAM()
        {
            _computer.RAM = "32GB DDR5";
        }

        public void AddStorage()
        {
            _computer.Storage = "1TB NVMe SSD";
        }

        public void AddGraphicsCard()
        {
            _computer.GraphicsCard = "NVIDIA RTX 4090";
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
