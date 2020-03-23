using System;
using System.Collections;

namespace Calculadoral_Ligas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(82, 26);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Clear();

            Console.WriteLine(" ");

            String[] ligas = { "Bronze de Bismuto",
                               "Bronze Corintio",
                               "Bronze",
                               "Latão",
                               "Ouro Rosa",
                               "Prata de Lei",
                               "Aço Negro",
                               "Aço Azul",
                               "Aço Vermelho"
                };


            ArrayList alloys = new ArrayList();
            foreach (string liga in ligas)
            {
                Alloy all = new Alloy();
                all.Nome = liga;
                alloys.Add(all);
            }

            for (int i = 0; i < alloys.Count; i++)
            {
                Alloy alloy = (Alloy)alloys[i];

                if (i == 0)
                {
                    alloy.addMaterial("Cobre", "50/65");
                    alloy.addMaterial("Bismutinita", "10/20");
                    alloy.addMaterial("Zinco", "20/30");

                    alloy.mname().Add("Cobre", "Cobre");
                    alloy.mname().Add("Bismutinita", "Bismutinita");
                    alloy.mname().Add("Zinco", "Esfalerita");
                }
                else if (i == 1)
                {
                    alloy.addMaterial("Cobre", "50/70");
                    alloy.addMaterial("Ouro", "10/25");
                    alloy.addMaterial("Prata", "10/25");

                    alloy.mname().Add("Cobre", "Cobre");
                    alloy.mname().Add("Ouro", "Ouro");
                    alloy.mname().Add("Prata", "Tetraedita");
                }
                else if (i == 2)
                {
                    alloy.addMaterial("Cobre", "88/92");
                    alloy.addMaterial("Estanho", "8/12");

                    alloy.mname().Add("Cobre", "Cobre");
                    alloy.mname().Add("Estanho", "Cassiterita");
                }
                else if (i == 3)
                {
                    alloy.addMaterial("Cobre", "88/92");
                    alloy.addMaterial("Zinco", "8/12");

                    alloy.mname().Add("Cobre", "Cobre");
                    alloy.mname().Add("Zinco", "Esfalerita");
                }
                else if (i == 4)
                {
                    alloy.addMaterial("Cobre", "15/30");
                    alloy.addMaterial("Ouro", "70/85");

                    alloy.mname().Add("Cobre", "Cobre");
                    alloy.mname().Add("Ouro", "Ouro");
                }
                else if (i == 5)
                {
                    alloy.addMaterial("Cobre", "20/40");
                    alloy.addMaterial("Prata", "60/80");

                    alloy.mname().Add("Cobre", "Cobre");
                    alloy.mname().Add("Prata", "Tetraedita");
                }
                else if (i == 6)
                {
                    alloy.addMaterial("Aço", "50/70");
                    alloy.addMaterial("Nickel", "15/25");
                    alloy.addMaterial("Bronze Corintio", "15/25");

                    alloy.mname().Add("Nickel", "Garnierita");
                }
                else if (i == 7)
                {
                    alloy.addMaterial("Aço Negro", "50/55");
                    alloy.addMaterial("Bronze de Bismuto", "10/15");
                    alloy.addMaterial("Prata", "10/15");
                    alloy.addMaterial("Aço", "20/25");

                    alloy.mname().Add("Prata", "Tetraedita");
                }
                else if (i == 8)
                {
                    alloy.addMaterial("Aço Negro", "50/55");
                    alloy.addMaterial("Ouro Rosa", "10/15");
                    alloy.addMaterial("Latão", "10/15");
                    alloy.addMaterial("Aço", "20/25");
                }
            }

            String selecionada;

            Console.WriteLine("Escolha uma liga: ");
            Console.WriteLine(" ");

            foreach (Alloy ally in alloys)
            {
                Console.WriteLine(ally.Nome);
            }

            Console.WriteLine(" ");

            selecionada = Console.ReadLine();

            bool existe = Array.Exists(ligas, x => x.ToLower().Equals(selecionada));

            while (!existe)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Liga não encontrada, Por favor, tente novamente");
                selecionada = Console.ReadLine();
                existe = Array.Exists(ligas, x => x.ToLower().Equals(selecionada));
            }

            Console.Clear();

            Alloy selected = null;
            foreach (Alloy alloy in alloys)
            {
                if (alloy.Nome.ToLower().Equals(selecionada))
                {
                    selected = alloy;
                    break;
                }
            }

            Console.WriteLine(selected.Nome + " - Materiais: ");
            Console.WriteLine(" ");


            Console.WriteLine(selected.getMaterials());

            Console.WriteLine(" ");

            Console.WriteLine("Quantas barras você deseja fazer?");
            Console.WriteLine(" ");

            int barras;
            while (!Int32.TryParse(Console.ReadLine(), out barras))
            {
                Console.WriteLine(" ");
                Console.WriteLine("Por favor, utilize apenas números");
            }

            barras *= 100;

            string[] mat = selected.getMaterialsName();
            int[] percent = new int[mat.Length];

            Console.WriteLine(" ");
            bool stop = false;
            for (int i = 0; i < mat.Length; i++)
            {

                string s = (string)selected.dic()[mat[i]];
                int[] x = new int[s.Split('/').Length];

                x[0] = Int32.Parse(s.Split('/')[0]);
                x[1] = Int32.Parse(s.Split('/')[1]);

                switch (i)
                {
                    case 1:
                        if (mat.Length == 3)
                        {
                            int oldX = percent[i - 1];

                            if ((100 - oldX) % 2 == 0)
                            {
                                percent[1] = (100 - oldX) / 2;
                                percent[2] = percent[1];

                                stop = true;

                                break;
                            }

                            if (100 - oldX < 50)
                            {
                                if (100 - oldX >= 40)
                                {
                                    x[0] = (100 - oldX) - int.Parse(selected.dic()[mat[i + 1]].Split('/')[1]);
                                }
                                else
                                {
                                    percent[i] = (100 - oldX) - int.Parse(selected.dic()[mat[i + 1]].Split('/')[0]);
                                    continue;
                                }

                            }
                        }

                        break;
                    case 2:
                        if (mat.Length == 4)
                        {
                            int sum = (100 - (percent[i - 1]) + 100 - (percent[i - 2]));

                            if(sum <= 50 && sum >= 40)
                            {
                                percent[2] = sum - 25;
                                percent[3] = 25;

                                stop = true;

                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }

                if (stop) break;

                Console.WriteLine("Quanto você irá usar de " + mat[i] + " ?");

                if (i == mat.Length - 1)
                {
                    int total = 0;

                    for(int j = 0; j < mat.Length; j++)
                    {
                        total += percent[i - j];
                    }

                    percent[i] = 100 - total;

                    break;
                }

                Console.WriteLine("De: " + x[0] + "% A " + x[1] + "%");

                while (!Int32.TryParse(Console.ReadLine(), out percent[i]))
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Por favor, utilize apenas números");
                }

                while (percent[i] < x[0] || percent[i] > x[1])
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Por favor, respeite os limites - De: " + x[0] + "% A " + x[1] + "%");
                    Console.WriteLine(" ");
                    percent[i] = Int32.Parse(Console.ReadLine());
                }

                Console.WriteLine(" ");
            }

            Console.Clear();

            double[] materials = new double[selected.getMaterials().Length];
            string[] names = selected.getMaterialsName();

            for (int i = 0; i < percent.Length; i++)
            {
                materials[i] = Math.Round(barras * (percent[i] / 100.0), 3);
            }

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine("Total a ser adicionado de " + names[i] + ": " + materials[i] + " Unidades");
            }

            Console.WriteLine(" ");

            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                
                if (name.Contains("Aço") || name.Contains("Bronze") || name.Contains("Rosa") || name.Contains("ã"))
                {
                    Console.WriteLine("Barra's de " + name + ": " + (materials[i] / 100) + " Unidades");

                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine("Minério de " + selected.mineralName(name) + " rico: " + Math.Round((materials[i] / 35), 3) + " Unidades");
                    Console.WriteLine("Minério de " + selected.mineralName(name) + " normal: " + Math.Round((materials[i] / 25), 3) + " Unidades");
                    Console.WriteLine("Minério de " + selected.mineralName(name) + " pobre: " + Math.Round((materials[i] / 15), 3) + " Unidades");

                    Console.WriteLine(" ");
                }
            }

            Console.WriteLine(" ");

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Escrito por: Miguel L. Rodrigues");
            Console.WriteLine(" ");
            Console.WriteLine("Pressione enter para fechar");

            Console.ReadLine();
        }
    }
}
