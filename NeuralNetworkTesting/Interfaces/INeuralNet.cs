﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTesting.Interfaces
{
    public interface INeuralNet
    {
        INeuralLayer PerceptionLayer { get; }
        INeuralLayer HiddenLayer { get; }
        INeuralLayer OutputLayer { get; }

        double LearningRate { get; set; }

        void Pulse();
        void ApplyLearning();
        void InitializeLearning();
    }
}
