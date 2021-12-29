using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class CicleDependenciesDetector
    {
        private readonly Stack<Type> typeStack = new Stack<Type>();

        public bool IsCycleDependencyDetected(Type type)
        {
            return typeStack.Contains(type);
        }

        public void PushType(Type type)
        {
            typeStack.Push(type);
        }

        public void PopType()
        {
            if (typeStack.Count > 0)
            {
                typeStack.Pop();
            }
        }
    }
}
