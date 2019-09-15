using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Helper {
    public class Utils {

        public static string[] SolicitarDadosLogar() {
            string[] vet = new string[2];
            Console.Clear();

            string email, senha;
            Console.WriteLine("Escreva seu email");
            email = Console.ReadLine();

            Console.WriteLine("Escreva uma senha");
            senha = Console.ReadLine();
            vet[0] = email;
            vet[1] = senha;
            return vet;
        }

        public static string[] SolicitarDadosCadastrar() {
            string[] vet = new string[5];
            Console.Clear();

            Console.WriteLine("Nenhum Usuario Cadastrado...");
            Console.WriteLine("Vamos realizar o seu cadastro!");

            string nome, sobreNome, email, data, senha;

            Console.WriteLine("Escreva seu primeiro nome");
            nome = Console.ReadLine();

            Console.WriteLine("Escreva seu sobrenome");
            sobreNome = Console.ReadLine();

            Console.WriteLine("Escreva seu email");
            email = Console.ReadLine();

            Console.WriteLine("Escreva a data de nascimento no formato YYYY/MM/DD");
            data = Console.ReadLine();

            Console.WriteLine("Escreva uma senha");
            senha = Console.ReadLine();

            vet[0] = nome;
            vet[1] = sobreNome;
            vet[2] = email;
            vet[3] = data;
            vet[4] = senha;
            Console.Clear();
            return vet;
        }
    }
}