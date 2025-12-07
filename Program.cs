namespace lab5
{
    class Problem
    {

        private int[][] _profits;
        private int _size;

        private readonly string[] _weatherReports =
        {
            "Високі закуп. ціни та сприятливі погодні умови",
            "Високі закуп.ціни та несприятливі погодні умови",
            "Низькі закуп.ціни та сприятливі погодні умови",
            "Низькі закуп.ціни та несприятливі погодні умови"
        };
        
        public Problem(int n)
        {
            _profits = new int[n][];
            for (int i = 0; i < n; i++)
            {
                _profits[i] = new int[4];
            }
            _size = n;
        }
        
        public Problem(): this(4) { }

        public void solution1()
        {
            int[] probabilities = new int[_size];
            Console.WriteLine("Enter probabilities:");
            string line = Console.ReadLine();
            string[] splitLine = line.Split(' ');
            for (int i = 0; i < _size; i++)
            {
                probabilities[i] = int.Parse(splitLine[i]);   
            }
            
            double[] B = new double[_size];
            for (int i = 0; i < _size; i++)
            {
                B[i] = 0;
                for (int j = 0; j < _size; j++)
                    B[i] += (double) _profits[i][j] * probabilities[j];
            }

            double max = B.Max();
            int indexAtMax = B.ToList().IndexOf(B.Max());
            
            Console.WriteLine($"The best solution in the term of 1 informational situation is: " +
                              $"{_weatherReports[indexAtMax]} with value: {max}");
        }

        public void solution2()
        {
            int[] sequence =  new int[_size];
            string line = Console.ReadLine();
            string[] splitLine = line.Split(' ');
            
            for (int i = 0; i < _size; i++)
            {
                sequence[i] = int.Parse(splitLine[i]);
            }

            double[] probabilities = new double[_size];

            for (int i = 0; i < _size; i++)
            {
                probabilities[sequence[i]-1] =(double) (2 * (_size - (i + 1) + 1)) / (_size * (_size + 1));
            }
            
            double[] B = new double[_size];
            for (int i = 0; i < _size; i++)
            {
                B[i] = 0;
                for (int j = 0; j < _size; j++)
                    B[i] += (double) _profits[i][j] * probabilities[j];
            }

            double max = B.Max();
            int indexAtMax = B.ToList().IndexOf(B.Max());
            
            Console.WriteLine($"The best solution in the term of 1 informational situation is: " +
                              $"{_weatherReports[indexAtMax]} with value: {max}");
        }

        public void solution3()
        {
            double[] probabilities = new double[_size];
            
            for(int i = 0; i < _size; i++)
                probabilities[i] = (double) 1/_size;
            
            double[] B = new double[_size];
            for (int i = 0; i < _size; i++)
            {
                B[i] = 0;
                for (int j = 0; j < _size; j++)
                    B[i] += (double) _profits[i][j] * probabilities[j];
            }

            double max = B.Max();
            int indexAtMax = B.ToList().IndexOf(B.Max());
            
            Console.WriteLine($"The best solution in the term of 1 informational situation is: " +
                              $"{_weatherReports[indexAtMax]} with value: {max}");
        }
        public void solution4()
        {   
            int[] minValues = new int[_size];
            
            for (int i = 0; i < _size; i++)
            {
                minValues[i] = _profits[i].Min();
            }
            
            int maxOfMins = minValues.Max();
            int bestIndex = Array.IndexOf(minValues, maxOfMins);
            Console.WriteLine($"The best solution is: {_weatherReports[bestIndex]}");
            Console.WriteLine($"With value: {maxOfMins}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Problem result = new Problem();
            result.solution2();
        }
    }
}