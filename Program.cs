namespace lab5
{
    class Problem
    {

        private int[][] _profits;
        private int _size;
        private string[] _harvests;

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
            input();
        }

        public Problem()
        {
            _size = 4;
            _profits = new int[_size][];
            for (int i = 0; i < _size; i++)
            {
                _profits[i] = new int[4];
            }
            
            _profits[0][0] = 15;
            _profits[0][1] = 10;
            _profits[0][2] = 9;
            _profits[0][3] = 7;

            _profits[1][0] = 19;
            _profits[1][1] = 13;
            _profits[1][2] = 8;
            _profits[1][3] = 6;

            _profits[2][0] = 20;
            _profits[2][1] = 12;
            _profits[2][2] = 12;
            _profits[2][3] = 4;

            _profits[3][0] = 21;
            _profits[3][1] = 15;
            _profits[3][2] = 10;
            _profits[3][3] = 4;

            _harvests = new string[_size];
            _harvests[0] = "Жито";
            _harvests[1] = "Овес";
            _harvests[2] = "Пшениця";
            _harvests[3] = "Гречка";
        }

        public void input()
        {
            _harvests = new string[_size];
            Console.Write("Input all variant of harvests:");
            string harvests = Console.ReadLine();
            string[] harvest = harvests.Split(' ');
            
            for (int i = 0; i < _size; i++)
            {
                Console.Write($"Input values for option {i+1}: ");
                string line = Console.ReadLine();
                string[] splitLine = line.Split(' ');
                
                int size = splitLine.Length;
                for (int j = 0; j < size; j++)
                {
                    _profits[j][j] = int.Parse(splitLine[j]);
                }
            }

            foreach (var tmp in harvest)
            {
                Console.Write(tmp + " ");
            }
        }

        public void solution1()
        {
            float[] probabilities = new float[_size];
            Console.WriteLine("Enter probabilities:");
            string line = Console.ReadLine();
            string[] splitLine = line.Split(' ');
            for (int i = 0; i < _size; i++)
            {
                probabilities[i] = float.Parse(splitLine[i]);   
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
                              $"{_harvests[indexAtMax]} with value: {max}");
        }

        public void solution2()
        {
            int[] sequence =  new int[_size];
            Console.WriteLine("Enter sequence(example 1>2>3>4):");
            string line = Console.ReadLine();
            string[] splitLine = line.Split('>');
            
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
            
            Console.WriteLine($"The best solution in the term of 2 informational situation is: " +
                              $"{_harvests[indexAtMax]} with value: {max}");
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
            
            Console.WriteLine($"The best solution in the term of 4 informational situation is: " +
                              $"{_harvests[indexAtMax]} with value: {max}");
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
            Console.Write($"The best solution in terms of is: {_harvests[bestIndex]} with value: {maxOfMins}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Problem result = new Problem();
                result.solution1();
                result.solution2();
                result.solution3();
                result.solution4();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}