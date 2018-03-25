using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResearch
{
    public class Mind
    {
        List<Synapse> synapses;
        List<Neuron> neurons;

        private class Synapse
        {
            public int id;
            public float weight;
            public object value;
            public Neuron startPoint;
            public Neuron endPoint;
        }

        private class Neuron
        {
            public int id;
            public object value;
            public Synapse connection;
        }
    }
}
