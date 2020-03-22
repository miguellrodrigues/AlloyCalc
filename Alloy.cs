using System;

using System.Collections.Generic;

namespace Calculadoral_Ligas
{
    public class Alloy
    {
        private string name;
    
        private Dictionary<string, string> materials;
        private Dictionary<string, string> correspondente;

        public string Nome { get => name; set => name = value; }

        public Alloy()
        {
            materials = new Dictionary<string, string>();
            correspondente = new Dictionary<string, string>();
        }

        public Dictionary<string, string> dic()
        {
            return materials;
        }

        public Dictionary<string, string> mname()
        {
            return correspondente;
        }

        public void addMaterial(string nome, string quantidades)
        {
            string[] qtd = quantidades.Split("/");

            int x, y;

            if (Int32.TryParse(qtd[0], out x) == false || Int32.TryParse(qtd[1], out y) == false)
            {
                Console.WriteLine("Por favor, utilize apenas números");
                return;
            }

            materials.Add(nome, quantidades);
        }

        public string getMaterials()
        {
            string retorno = "";

            foreach (KeyValuePair<string, string> entry in materials)
            {
                string[] qtd = entry.Value.Split("/");
                int x, y;

                x = Int32.Parse(qtd[0]);
                y = Int32.Parse(qtd[1]);

                retorno += entry.Key + ": de " + x + "% A " + y + "% \n";
            }

            return retorno;
        }

        public string[] getMaterialsName()
        {

            string[] retorno = new string[materials.Keys.Count];

            int x = 0;
            foreach (KeyValuePair<string, string> entry in materials)
            {
                retorno[x] = entry.Key;
                x++;
            }

            return retorno;
        }

        public int getMaterialSize(string key)
        {
            return materials[key].Length;
        }

        public string mineralName(string key)
        {
            return correspondente[key];
        }
    }
}