using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public interface IGenerator
    {
        object Generate(GeneratorContext context);
        bool CanGenerate(Type type);
    }
}
