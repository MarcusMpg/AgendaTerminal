using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeContatos
{
    internal class BackupAgenda
    {
        public static  String nomeArquivo = "dados.txt";

        public static void SalvarDados(ref String[] nome, ref String[] email, ref int tl)
        {
            StreamWriter sr = new StreamWriter(nomeArquivo);
            for (int i = 0; i < tl; i++)
            {
                sr.WriteLine(nome[i] + "-" + email[i]);
            }
            sr.Close();
        }
        public static void RestalrarDados(ref String[] nome, ref String[] email, ref int tl) 
        {
            tl = 0;
            StreamReader sr = new StreamReader(nomeArquivo);
            String line = sr.ReadLine();

            while (line != null)
            {
                int pos = line.IndexOf("-");
                nome[tl] = line.Substring(0, pos);
                email[tl] = line.Substring(pos+1);
                tl++;
                line = sr.ReadLine();
            }
            sr.Close();
        }
    }
}
