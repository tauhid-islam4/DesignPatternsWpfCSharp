using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBuilderDesignPattern
{
    public interface IComputerBuilder
    {
        void AddProcessor();
        void AddRAM();
        void AddStorage();
        void AddGraphicsCard();
        Computer GetComputer();
    }
}
