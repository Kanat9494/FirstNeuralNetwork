namespace FirstNeuralNetwork;

public class NeuralNetwork
{
    public NeuralNetwork(Topology topology)
    {
        CurrentTopology = topology;

        Layers = new List<Layer>();

        CreateOutputLayer();
        CreateHiddenLayers();
        CreateInputLayer();
    }
    public List<Layer> Layers { get; }
    public Topology CurrentTopology { get; }

    public Neuron FeedForward(List<double> inputSignals)
    {
        SendSignalsToInputNeurons(inputSignals);

        FeedForwardAllLayersAfterInput();

        if (CurrentTopology.OutputCount == 1)
            return Layers.Last().Neurons[0];
        else
            return Layers.Last().Neurons.OrderByDescending(n => n.Output).First();
    }

    private void FeedForwardAllLayersAfterInput()
    {
        for (int i = 1; i < Layers.Count; i++)
        {
            var layer = Layers[i];
            var previousLayerSignals = Layers[i - 1].GetSignals();

            foreach (var neuron in layer.Neurons)
                neuron.FeedForward(previousLayerSignals);
        }
    }

    private void SendSignalsToInputNeurons(List<double> inputSignals)
    {
        for (int i = 0; i < inputSignals.Count; i++)
        {
            var signal = new List<double>() { inputSignals[i] };
            var neuron = Layers[0].Neurons[i];

            neuron.FeedForward(signal);
        }
    }

    void CreateOutputLayer()
    {
        var outputNeurons = new List<Neuron>();
        var lastLayer = Layers.Last();
        for (int i = 0; i < CurrentTopology.OutputCount; i++)
        {
            var neuron = new Neuron(1, NeuronType.Output);
            outputNeurons.Add(neuron);
        }

        var outputLayer = new Layer(outputNeurons, NeuronType.Input);
        Layers.Add(outputLayer);
    }

    private void CreateHiddenLayers()
    {
        for (int j = 0; j < CurrentTopology.HiddenLayers.Count; j++ )
        {
            var hiddenNeurons = new List<Neuron>();
            var lastLayer = Layers.Last();

            for (int i = 0; i < CurrentTopology.OutputCount; i++)
            {
                var neuron = new Neuron(lastLayer.Count);
                hiddenNeurons.Add(neuron);
            }

            var hiddenLayer = new Layer(hiddenNeurons, NeuronType.Output);
            Layers.Add(hiddenLayer);
        }
    }

    private void CreateInputLayer()
    {
        var inputNeurons = new List<Neuron>();
        for (int i = 0; i < CurrentTopology.InputCount; i++)
        {
            var neuron = new Neuron(1, NeuronType.Input);
            inputNeurons.Add(neuron);
        }

        var inputLayer = new Layer(inputNeurons, NeuronType.Input);
        Layers.Add(inputLayer);
    }
}
