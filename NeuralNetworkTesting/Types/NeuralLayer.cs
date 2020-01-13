using NeuralNetworkTesting.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTesting.Types
{
    

    public class NeuralLayer : INeuralLayer
    {
        public INeuron this[int index]
        {
            get { return m_neurons[index]; }
            set { m_neurons[index] = value; }
        }

        public int Count { get { return m_neurons.Count; } }
        public bool IsReadOnly { get { return false; } }

        private readonly List<INeuron> m_neurons;

        public NeuralLayer()
        {
            m_neurons = new List<INeuron>();
        }

        public void InitializeLearning(INeuralNet net)
        {
            foreach (INeuron n in m_neurons)
            { n.InitializeLearning(this); }
        }
        public void Pulse(INeuralNet net)
        {
            foreach (INeuron n in m_neurons)
            { n.Pulse(this); }
        }

        public void ApplyLearning(INeuralNet net)
        {
            double learningRate = net.LearningRate;

            foreach (INeuron n in m_neurons)
            { n.ApplyLearning(this, ref learningRate); }
        }
               


        //Crud Operations

        public int IndexOf(INeuron item)
        { return m_neurons.IndexOf(item); }

        public void Insert(int index, INeuron item)
        { m_neurons.Insert(index, item); }

        public void RemoveAt(int index)
        { m_neurons.RemoveAt(index); }      

        public void Add(INeuron item)
        { m_neurons.Add(item); }

        public void Clear()
        { m_neurons.Clear(); }

        public bool Contains(INeuron item)
        { return m_neurons.Contains(item); }

        public void CopyTo(INeuron[] array, int arrayIndex)
        { m_neurons.CopyTo(array, arrayIndex); }      

        public bool Remove(INeuron item)
        { return m_neurons.Remove(item); }
        
        public IEnumerator<INeuron> GetEnumerator()
        { return m_neurons.GetEnumerator(); }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
        
    }
}
