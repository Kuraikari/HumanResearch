using System;
using System.Collections.Generic;

namespace HumanResearch
{
    public class Layer
    {
        public List<Neuron> neurons;
        public List<Synapse> synapses;
        public int neuronCount;

        public Layer(int layer = 0)
        {

        }

        /* ************************************************************************ *
         * ************************************************************************ *
         * ************************************************************************ */
        public class Synapse
        {
            private double weight;
            private double value;
            private Neuron startPoint;
            private Neuron endPoint;

            public double Weight { get { return weight; } set { weight = value; } }
            public double Value { get { return value; } set { this.value = value; } }
            public Neuron StartPoint  { get {  return startPoint; } set { startPoint = value; } }
            public Neuron EndPoint { get { return endPoint; } set { endPoint = value; } }

            public Synapse(Neuron startPoint, Neuron endPoint)
            {
                Random rnd = new Random();
                Weight = rnd.NextDouble();
                this.StartPoint = startPoint;
                this.EndPoint = endPoint;
                Value = (this.StartPoint.Value == 0 ) ? 0 : this.StartPoint.Value * Weight ;
            }
        }

        public class Neuron
        {
            private double value;
            private Synapse connection;
            private List<Dendrite> dendrites;
            private int bias;

            public double Value { get { return value; } set { this.value = value; } }
            public Synapse Connection { get { return connection; } set { connection = value; } }
            public List<Dendrite> Dendrites { get { return dendrites; } set { this.dendrites = value; } }
            public int Bias { get { return bias; } set { this.bias = value; } }

            public Neuron(double value = 0, Synapse connection = null)
            {
                this.Value = value;
                this.Connection = connection;
                this.Dendrites = dendrites;
                this.Bias = bias;
            }

            public class Dendrite
            {
                private double weight;
                public double Weight { get { return weight; } set { weight = value; } }

                public Dendrite()
                {
                    this.Weight = weight;
                }

                
            }
        }
    }
}