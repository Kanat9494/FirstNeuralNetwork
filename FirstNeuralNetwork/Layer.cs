namespace FirstNeuralNetwork;

internal class Layer
{
    public Layer(List<Neuron> neurons, NeuronType type = NeuronType.Normal)
    {
        // ToDo проверить все входные нейроны на соответствие типу
        Neurons = neurons;
    }
    public List<Neuron> Neurons { get; }
    public int Count => Neurons?.Count ?? 0;
}
