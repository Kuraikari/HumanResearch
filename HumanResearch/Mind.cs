using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResearch
{
    public class Mind
    {

        public List<Layer> layers { get; set; }
        public double learningRate { get; set; }
        public int layerCount { get { return layers.Count; } }
        public Status status { get; set; }

        //Enums
        public enum Status { working, pause, idle }

        public Mind(double learningRate, int[] layers)
        {
            if (layers.Length < 2) return;

            this.learningRate = learningRate;
            this.layers = new List<Layer>();
            this.status = Status.idle;

            for (int i = 0; i < layers.Length; i++)
            {
                Layer layer = new Layer(layers[1]);
                this.layers.Add(layer);

                for (int j = 0; j < layers[1]; j++)
                {
                    layer.neurons.Add(new Layer.Neuron());
                }

                layer.neurons.ForEach((nn) =>
                {
                    if (i == 0) nn.Bias = 0;
                    else
                        for (int d = 0; d < layers[i - 1]; d++)
                            nn.Dendrites.Add(new Layer.Neuron.Dendrite());
                });
            }
        }

        private double sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public double[] run(List<double> input)
        {
            if (input.Count != this.layers[0].neuronCount) return null;

            for (int l = 0; l < layers.Count; l++)
            {
                Layer layer = layers[l];

                for (int n = 0; n < layer.neurons.Count; n++)
                {
                    Layer.Neuron neuron = layer.neurons[n];

                    if (l == 0)
                        neuron.Value = input[n];
                    else
                    {
                        neuron.Value = 0;
                        for (int np = 0; np < this.layers[l - 1].neurons.Count; np++)
                            neuron.Value = neuron.Value + this.layers[l - 1].neurons[np].Value * neuron.Dendrites[np].Weight;

                        neuron.Value = sigmoid(neuron.Value + neuron.Bias);
                    }
                }
            }

            Layer last = this.layers[this.layers.Count - 1];
            int numOutput = last.neurons.Count;
            double[] output = new double[numOutput];
            for (int i = 0; i < last.neurons.Count; i++)
                output[i] = last.neurons[i].Value;

            return output;
        }
    }
}
