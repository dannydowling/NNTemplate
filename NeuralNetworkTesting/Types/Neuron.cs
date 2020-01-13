using NeuralNetworkTesting.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTesting.Types
{
    public class Neuron : INeuron
    {
        //The weight needs to be passed in as a double.
        public NeuralFactor BiasWeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double Output
        {
            get { return m_output; }
            set { m_output = value; }
        }

        public double LastError
        {
            get { return m_lastError; }
            set { m_lastError = value; }
        }

        private readonly Dictionary<INeuronSignal, NeuralFactor> m_input;
        double m_output, m_error, m_lastError;
        NeuralFactor m_bias;

        public Dictionary<INeuronSignal, NeuralFactor> Input
        {
            get { return m_input; }
        }

        public Neuron(double bias)
        {
            m_bias = new NeuralFactor(bias);
            m_error = 0;
            m_input = new Dictionary<INeuronSignal, NeuralFactor>();
        }
        public void Pulse(INeuralLayer layer)
        {
            lock (this)
            {
                m_output = 0;

                foreach (KeyValuePair<INeuronSignal, NeuralFactor> item in m_input)
                    m_output += item.Key.Output * item.Value.Weight;

                m_output += m_bias.Weight;

                m_output = Sigmoid(m_output);
            }
        }

        public NeuralFactor Bias
        {
            get { return m_bias; }
            set { m_bias = value; }
        }

        public double Error
        {
            get { return m_error; }
            set
            {
                m_lastError = m_error;
                m_error = value;
            }
        }

        public void ApplyLearning(INeuralLayer layer, ref double learningRate)
        {
            foreach (KeyValuePair<INeuronSignal, NeuralFactor> m in m_input)
                m.Value.ApplyWeightChange(ref learningRate);

            m_bias.ApplyWeightChange(ref learningRate);
        }

        public void InitializeLearning(INeuralLayer layer)
        {
            foreach (KeyValuePair<INeuronSignal, NeuralFactor> m in m_input)
            { m.Value.ResetWeightChange(); }

            m_bias.ResetWeightChange();
        }

      

        public static double Sigmoid(double value)
        {
            return 1 / (1 + Math.Exp(-value));
        }
    }
}
