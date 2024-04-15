using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeContatos
{
    //ybersecurity, data gathering, cloud computing, automation, and seeking guidance from a digital transformation advisor
    internal class Program
    {
        static int ExibirManu()
        {
            Console.Clear();
            Console.WriteLine("     Agenda de contatos");
            Console.WriteLine("     Exibir Contatos (1)");
            Console.WriteLine("     Inserir Contatos (2)");
            Console.WriteLine("     Alterar Contatos (3)");
            Console.WriteLine("     Excluir Contatos (4)");
            Console.WriteLine("     Localizar Contatos (5)");
            Console.WriteLine("     Sair (6)");
            Console.Write("     Opção: ");
            int op = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return op;
        }

        static void ExibirContatos(String[] nome, String[] email, int tl)
        {
            for (int i = 0;i < tl; i++)
            {
                Console.WriteLine("Lista de Contatos");
                Console.WriteLine(" nome: {0} - E-mail: {1}", nome[i], email[i]);
                
            }
            Console.ReadKey();
        }

        static void InserirContato(ref String[] nome, ref String[] email, ref int tl)
        {
            try
            {
                if (tl >= 200)
                {
                    Console.WriteLine("Tamanho maximo atingido !!!!.");
                }
                else
                {
                    Console.WriteLine("Inserir contatos");
                    Console.Write("Nome: ");
                    nome[tl] = Console.ReadLine();
                    Console.Write("E-mail: ");
                    email[tl] = Console.ReadLine();
                    int pos = LocalizarContato(email, tl, email[tl]);
                    if (pos == -1)
                    {
                        tl++;
                        Console.Clear();
                        Console.WriteLine("Contato Inserido.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Registro ja cadastrado");

                    }
                }
            }
                catch (Exception e)
                {
                Console.Clear();
                Console.WriteLine("Erro: " + e.Message);
                    
                }
            Console.ReadKey();
        }

        static int LocalizarContato( String[] email, int tl, string emailContato)
        {
            int pos = -1;
            int i = 0;
            while (i<tl && email[i] != emailContato)
            {
                i++;
            }
            if (i < tl) pos = i;
            return pos;
        }
        
        static void AlterarContato(ref String[] nome, ref String[] email, ref int tl)
        {
            try
            {
                Console.WriteLine("Alterar contatos");
                Console.Write("E-mail: ");
                String emailContato = Console.ReadLine();
                int pos = LocalizarContato(email, tl, emailContato);
                if (pos != -1)
                {
                    Console.WriteLine("Novos dados do contatos");
                    Console.Write("Nome: "); 
                    String novoNome = Console.ReadLine();
                    Console.Write("E-mail: ");
                    String novoEmail = Console.ReadLine();
                    int posV = LocalizarContato(email, tl, novoEmail);
                     
                    if (posV == -1 || posV == pos)
                    {
                        nome[pos] = novoNome;
                        email[pos] = novoEmail;
                        Console.Clear();
                        Console.WriteLine("Alteração realizada.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Já existe um contato com esse e-mail.");
                        
                    }  
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Contato não encontrado .");
                    
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                Console.ReadKey();
            }
        }
        static Boolean ExcluirContato(ref String[] nome, ref String[] email, ref int tl, String emailContato)
        {
            Boolean excluiu = false;
            int pos = -1;
            pos = LocalizarContato(email, tl, emailContato);
            if (pos != -1)
            {
                for (int i = pos; i < tl - 1; i++)
                {
                    nome[i] = nome[i + 1];
                    email[i] = email[i + 1]; 
                }
                excluiu |= true;
                tl--;
            }

            return excluiu;
        }


        static void Main(string[] args)
        {
            //Capacidade da agenda
            String[] nome = new string[200];
            String[] email = new string[200];
            
            //Tamanho logico da agenda
            int tl = 0;
            int op = 0;
            int pos = 0;
            string emailContato = "";

            BackupAgenda.nomeArquivo = "dados.txt";
            BackupAgenda.RestalrarDados(ref nome, ref email, ref tl);
            
            while (op != 6)
            {   
                op = ExibirManu();

                switch (op)
                {
                    case 1:
                        ExibirContatos(nome, email, tl);
                        break;

                    case 2:
                        InserirContato(ref nome, ref email, ref tl);
                        break;

                    case 3:
                        AlterarContato(ref nome, ref email, ref tl);
                        break;

                    case 4:
                        Console.WriteLine("Excluir um contato.");
                        Console.Write("E-mail: ");
                        emailContato = Console.ReadLine();
                        if (ExcluirContato(ref nome, ref email, ref tl, emailContato) == true)
                        {
                            Console.WriteLine("Contato Excluido");

                        }
                        else
                        {
                            Console.WriteLine("Contato não encontrado");
                        }
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine("Localizar um contato.");
                        Console.Write("E-mail: ");
                        emailContato = Console.ReadLine();
                        pos = LocalizarContato(email, tl, emailContato);
                        if (pos != -1) 
                        {
                            Console.WriteLine(" nome: {0} - E-mail: {1}", nome[pos], email[pos]);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Contato não encontrado");
                        }
                            Console.ReadKey();
                        break;
                }
            }
            BackupAgenda.SalvarDados(ref nome, ref email, ref tl);
            Console.ReadKey();
        }
        
    }

}
