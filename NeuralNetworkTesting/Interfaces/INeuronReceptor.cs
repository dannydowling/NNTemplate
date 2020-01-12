using NeuralNetworkTesting.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTesting.Interfaces
{
    public interface INeuronReceptor    
    {
        Dictionary<INeuronSignal, NeuralFactor> Input { get; }
    }
}
