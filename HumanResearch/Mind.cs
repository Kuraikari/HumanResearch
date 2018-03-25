using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResearch
{
    public class Mind
    {

        private List<Synapse> synapses { get; set; }
        private List<Neuron> neurons { get; set; }
        private Status status { get; set; }

        //Enums
        private enum Status { working, pause, idle }

        public Mind()
        {
            this.synapses = new List<Synapse>();
            this.neurons = new List<Neuron>();
            this.status = Status.idle;
        }

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
