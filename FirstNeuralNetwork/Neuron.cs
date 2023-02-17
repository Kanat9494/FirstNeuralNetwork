namespace FirstNeuralNetwork;

public class Neuron
{
    public Neuron(int inputCount, NeuronType type = NeuronType.Normal)
    {
        TypeOfNeuron = type;
        Weights = new List<double>();

        for (int i = 0; i < inputCount; i++)
        {
            Weights.Add(1);
        }
    }
    public List<double> Weights { get; }
    public NeuronType TypeOfNeuron { get; }
    public double Output { get; private set; }

    public double FeedForward(List<double> inputs)
    {
        var sum = 0.0;
        for (int i = 0; i < inputs.Count; i++)
        {
            sum = sum + inputs[i] * Weights[i];
        }

        if (TypeOfNeuron != NeuronType.Input)
            Output = Sigmoid(sum);
        else
            Output = sum;

        return Output;
    }

    private double Sigmoid(double x)
    {
        var result = 1.0 / (1.0 + Math.Pow(Math.E, -x));

        return result;
    }

    public void SetWeights(params double[] weights)
    {
        for (int i = 0; i < weights.Length; i++)
            Weights[i] = weights[i];
    }

    public override string ToString()
    {
        return Output.ToString();
    }
}
