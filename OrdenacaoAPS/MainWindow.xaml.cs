using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrdenacaoAPS
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void preparaArray(float[,] num, int qtd)
        {
            for (int i = 0; i < qtd; i++)
            {
                num[i, 0] = float.Parse((string)lstX.Items[i]);
                num[i, 1] = float.Parse((string)lstY.Items[i]);
                num[i, 2] = float.Parse((string)lstM.Items[i]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lstX.Items.Count > 0)
            {
                lTempo1.Content = "";
                lTempo2.Content = "";
                lTempo3.Content = "";

                DateTime start;
                TimeSpan time;

                int qtd = lstX.Items.Count;
                float[,] num = new float[qtd, 3];

                preparaArray(num, qtd);
                start = DateTime.Now;
                quicksort(num, 0, (num.Length / 3) - 1);
                time = DateTime.Now - start;
                lTempo1.Content = "Quick Sort: " + String.Format("{0}.{1}", time.Seconds, time.Milliseconds.ToString().PadLeft(3, '0')) + "s";

                preparaArray(num, qtd);
                start = DateTime.Now;
                heapsort(num, qtd);
                time = DateTime.Now - start;
                lTempo2.Content = "Heap Sort: " + String.Format("{0}.{1}", time.Seconds, time.Milliseconds.ToString().PadLeft(3, '0')) + "s";

                preparaArray(num, qtd);
                start = DateTime.Now;
                insertionsort(num);
                time = DateTime.Now - start;
                lTempo3.Content = "Insertion Sort: " + String.Format("{0}.{1}", time.Seconds, time.Milliseconds.ToString().PadLeft(3, '0')) + "s";


                lstX2.Items.Clear();
                for (int i = 0; i < qtd; i++)
                {
                    lstX2.Items.Add(Convert.ToString(num[i, 0]));
                }

                lstY2.Items.Clear();
                for (int i = 0; i < qtd; i++)
                {
                    lstY2.Items.Add(Convert.ToString(num[i, 1]));
                }

                lstM2.Items.Clear();
                for (int i = 0; i < qtd; i++)
                {
                    lstM2.Items.Add(Convert.ToString(num[i, 2]));
                }
            }
        }
        public void heapsort(float[,] a, int n)
        {
            int i = n / 2, pai, filho;
            float t0, t1, t2;
            while (true)
            {
                if (i > 0)
                {
                    i--;
                    t0 = a[i, 0];
                    t1 = a[i, 1];
                    t2 = a[i, 2];
                }
                else
                {
                    n--;
                    if (n == 0) return;
                    t0 = a[n, 0];
                    t1 = a[n, 1];
                    t2 = a[n, 2];
                    a[n, 0] = a[0, 0];
                    a[n, 1] = a[0, 1];
                    a[n, 2] = a[0, 2];
                }
                pai = i;
                filho = i * 2 + 1;
                while (filho < n)
                {
                    if ((filho + 1 < n) && (a[filho + 1, 2] > a[filho, 2]))
                        filho++;
                    if (a[filho, 2] > t2)
                    {
                        a[pai, 0] = a[filho, 0];
                        a[pai, 1] = a[filho, 1];
                        a[pai, 2] = a[filho, 2];
                        pai = filho;
                        filho = pai * 2 + 1;
                    }
                    else
                    {
                        break;
                    }
                }
                a[pai, 0] = t0;
                a[pai, 1] = t1;
                a[pai, 2] = t2;
            }
        }

        static public void quicksort(float[,] vetor, int primeiro, int ultimo)
        {

            int alto, baixo, meio;
            float pivo_0, pivo_1, pivo_2, repositorio_0, repositorio_1, repositorio_2;
            baixo = primeiro;
            alto = ultimo;
            meio = (int)((baixo + alto) / 2);

            pivo_0 = vetor[meio, 0];
            pivo_1 = vetor[meio, 1];
            pivo_2 = vetor[meio, 2];

            while (baixo <= alto)
            {
                while (vetor[baixo, 0] < pivo_0)
                    baixo++;
                while (vetor[alto, 0] > pivo_0)
                    alto--;
                if (baixo < alto)
                {
                    repositorio_0 = vetor[baixo, 0];
                    repositorio_1 = vetor[baixo, 1];
                    repositorio_2 = vetor[baixo, 2];

                    vetor[baixo, 0] = vetor[alto, 0];
                    vetor[baixo, 1] = vetor[alto, 1];
                    vetor[baixo, 2] = vetor[alto, 2];
                    baixo++;

                    vetor[alto, 0] = repositorio_0;
                    vetor[alto, 1] = repositorio_1;
                    vetor[alto, 2] = repositorio_2;
                    alto--;
                }
                else
                {
                    if (baixo == alto)
                    {
                        baixo++;
                        alto--;
                    }
                }
            }

            if (alto > primeiro)
                quicksort(vetor, primeiro, alto);
            if (baixo < ultimo)
                quicksort(vetor, baixo, ultimo);
        }

        static public void insertionsort(float[,] inputArray)
        {
            for (int i = 0; i < (inputArray.Length / 3) - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1, 0] > inputArray[j, 0])
                    {
                        float temp_0 = inputArray[j - 1, 0];
                        float temp_1 = inputArray[j - 1, 1];
                        float temp_2 = inputArray[j - 1, 2];

                        inputArray[j - 1, 0] = inputArray[j, 0];
                        inputArray[j - 1, 1] = inputArray[j, 1];
                        inputArray[j - 1, 2] = inputArray[j, 2];

                        inputArray[j, 0] = temp_0;
                        inputArray[j, 1] = temp_1;
                        inputArray[j, 2] = temp_2;
                    }
                }
            }
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tX.Text != "" && tY.Text != "")
            {
                lstX.Items.Add(tX.Text);

                lstY.Items.Add(tY.Text);

                lstM.Items.Add(Convert.ToString((float.Parse(tX.Text) + float.Parse(tY.Text)) / 2));

                tX.Clear();
                tY.Clear();
            }
            tX.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BClear_Click(object sender, RoutedEventArgs e)
        {
            lstX.Items.Clear();
            lstY.Items.Clear();
            lstM.Items.Clear();

            lstX2.Items.Clear();
            lstY2.Items.Clear();
            lstM2.Items.Clear();
        }

        private static readonly Random getrandom = new Random();

        static Random random = new Random();
        public float GetRandomNumber(float minimum, float maximum)
        {
            return Convert.ToSingle(random.NextDouble() * (maximum - minimum) + minimum);
        }

        private void BAleatorio_Click(object sender, RoutedEventArgs e)
        {
            BClear_Click(bClear, e);
            for (int i = 0; i < int.Parse(tQtdAleatorio.Text); i++)
            {
                float x;
                float y;
                x = GetRandomNumber(0f, 100f);
                y = GetRandomNumber(0f, 100f);


                lstX.Items.Add(Convert.ToString(Math.Round(x, 0)));

                lstY.Items.Add(Convert.ToString(Math.Round(y, 0)));

                lstM.Items.Add(Convert.ToString(Math.Round(((x + y) / 2), 2)));

            }
        }
    }
}
