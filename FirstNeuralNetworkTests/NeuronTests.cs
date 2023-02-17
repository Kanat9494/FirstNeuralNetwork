﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirstNeuralNetwork.Tests
{
    [TestClass()]
    public class NeuronTests
    {
        [TestMethod()]
        public void FeedForwardTest()
        {
            var topology = new Topology(4, 1, 2);

            var neuralNetwork = new NeuralNetwork(topology);
            neuralNetwork.Layers[1].Neurons[0].SetWeights(0.5, -0.1, 0.3, -0.1);
            neuralNetwork.Layers[1].Neurons[1].SetWeights(0.1, -0.3, 0.7, -0.3);
            neuralNetwork.Layers[2].Neurons[0].SetWeights(1.2, 0.8);

            var result = neuralNetwork.FeedForward(new List<double> { 1, 0, 0, 0 });
        }
    }
}