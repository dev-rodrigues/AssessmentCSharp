using LibApp.Model;
using LibApp.Service;
using LibApp.Service.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Helper {
    public class Utils {

        private static IUsuario ServiceUsuario = ServiceLab.GetInstanceOf<UsuarioImpl>();

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

        //TODO VALIDAR DADOS
        public static string[] SolicitarDadosCadastrarAmigo() {
            string[] vet = new string[3];
            string primeiroNome, sobrenome, data;

            Console.WriteLine("Digite o primeiro nome do seu amigo");
            primeiroNome = Console.ReadLine();

            Console.WriteLine("Digite o sobre nome do seu amigo");
            sobrenome = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento do seu amigo no formato YYYY-MM-DD");
            data = Console.ReadLine();
            vet[0] = primeiroNome; vet[1] = sobrenome; vet[2] = data;
            return vet;
        }

        // TODO VALIDAR DADOS
        public static Amigo SolicitarDadosCadastrarAmigo(Amigo Old, Usuario UsuarioLogado) {
            string primeiroNome, sobrenome, data;
            Console.WriteLine("Digite o primeiro nome do seu amigo");
            primeiroNome = Console.ReadLine();

            Console.WriteLine("Digite o sobre nome do seu amigo");
            sobrenome = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento do seu amigo no formato YYYY-MM-DD");
            data = Console.ReadLine();
            return new Amigo(Old.Id, primeiroNome, sobrenome, DateTime.Parse(data), UsuarioLogado.Id);
        }

        public static string SolicitarPalavraChave() {
            string palavraChave;
            Console.WriteLine("Digite o nome ou sobre nome do amigo");
            palavraChave = Console.ReadLine();
            return palavraChave;
        }

        public static string[] SolicitarDadosCadastrar() {
            string[] vet = new string[5];
            Console.Clear();

            Console.WriteLine("Vamos realizar o seu cadastro!");

            string nome, sobreNome, email, data, senha;

            Console.WriteLine("Escreva seu primeiro nome");
            nome = Console.ReadLine();

            Console.WriteLine("Escreva seu sobrenome");
            sobreNome = Console.ReadLine();

            Console.WriteLine("Escreva seu email");
            email = Console.ReadLine();

            Console.WriteLine("Escreva a data de nascimento no formato YYYY-MM-DD");
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

        private static void EscreverMenu() {
            Console.Clear();
            Console.WriteLine("SELECIONE UMA OPÇÃO");
            Console.WriteLine("1 - LOGAR");
            Console.WriteLine("2 - CADASTRAR");
            Console.WriteLine("3 - SAIR");
        }

        private static void SolicitaAcaoAutenticado(Usuario autenticado) {
            int value = int.MaxValue;

            while (value == int.MaxValue) {
                EscreveMenuAutenticado();
                value = SolicitaAcao();
                if (value == 6) {
                    break;
                }

                if (OpcaoSelecionadaLogadoValido(value)) {
                    ExecutaAcaoDoUsuarioLogado(value, autenticado);
                } else {
                    Console.WriteLine("Opcao invalida");
                }
                value = int.MaxValue;
            }
            Console.ReadLine();
        }

        private static int SolicitaAcao() {
            int value = int.MaxValue;

            while (value == int.MaxValue) {
                Console.WriteLine("Digite uma opção valida");
                try {
                    value = Int32.Parse(Console.ReadLine());
                } catch (Exception e) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Valor digitado inválido");
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    value = int.MaxValue;
                }
            }
            Console.Clear();
            return value;
        }

        public static void Interacao() {
            int opcao = 0;

            while (opcao != 3) {
                EscreverMenu();
                opcao = SolicitaAcao();

                if (OpcaoSelecionadaValida(opcao)) {
                    ExecutaSelecao(opcao);
                }
            }
        }

        private static bool OpcaoSelecionadaValida(int opcao) {
            return opcao >= 1 && opcao <= 3;
        }

        private static bool OpcaoSelecionadaLogadoValido(int opcao) {
            return opcao >= 1 && opcao <= 6;
        }

        private static void InformarDadosUsuarioSelecionado(Amigo Amigo) {
            var TotalDeDias = Amigo.TotalDeDiasProAniversario();
            var DataFormatada = Amigo.Nascimento.ToString("dd/MM/yyyy");
            Console.WriteLine($"{Amigo.Nome} {Amigo.SobreNome} - {DataFormatada} - Dias pro aniversário: {TotalDeDias}");
        }

        private static void EscreveMenuAutenticado() {
            Console.Clear();
            Console.WriteLine(" SELECIONE UMA OPÇÃO     ");
            Console.WriteLine(" 1 - CONSULTAR AMIGO     ");
            Console.WriteLine(" 2 - CADASTRAR AMIGO     ");
            Console.WriteLine(" 3 - LISTAR AMIGOS       ");
            Console.WriteLine(" 4 - EDITAR AMIGO        ");
            Console.WriteLine(" 5 - EXCLUIR AMIGO       ");
            Console.WriteLine(" 6 - RETORNAR            ");
        }

        private static void ExecutaAcaoDoUsuarioLogado(int opcaoSelecionada, Usuario autenticado) {
            switch (opcaoSelecionada) {
                //  consultar amigo
                case 1:
                    List<Amigo> amigos = ServiceUsuario.BuscarAmigo(SolicitarPalavraChave(), autenticado);
                    ListarAmigos(amigos);
                    if (amigos.Count > 0) {
                        var selecao = EscolherAmigo();
                        InformarDadosUsuarioSelecionado(amigos[selecao]);
                    } else {
                        Console.WriteLine("NÃO FOI LOCALIZADO NENHUM AMIGO...");
                    }                    
                    break;

                //  cadastrar amigo
                case 2:
                    Amigo a = ServiceUsuario.CadastrarAmigo(SolicitarDadosCadastrarAmigo(), autenticado);
                    if (a == null) {
                        Console.WriteLine("ERRO AO EXCLUIR O AMIGO");
                    }
                    Console.WriteLine("Amigo cadastrado");
                    break;

                //  listar todos os amigos
                case 3:
                    List<Amigo> TodosAmigos = ServiceUsuario.AllAmigos(autenticado);
                    ListarAmigos(TodosAmigos);
                    break;

                // Editar amigo
                case 4:
                    List<Amigo> Amigos = ServiceUsuario.BuscarAmigo(SolicitarPalavraChave(), autenticado);
                    if (Amigos.Count > 0) {
                        ListarAmigos(Amigos);
                        var selecionado = EscolherAmigo();
                        Amigo old = Amigos.ElementAt(selecionado);
                        Console.WriteLine("Amigo selecionado: " + old.Nome);

                        Amigo AmigoEditado = SolicitarDadosCadastrarAmigo(old, autenticado);
                        if (ServiceUsuario.EditarAmigo(autenticado, AmigoEditado)) {
                            Console.WriteLine($"AMIGO {AmigoEditado.Nome} EDITADO COM SUCESSO");
                        } else {
                            Console.WriteLine("ERRO AO EDITAR AMIGO");
                        }
                    } else {
                        Console.WriteLine("SEM AMIGOS PARA EDITAR");
                    }

                    break;

                // Excluir amigo
                case 5:
                    if (ServiceUsuario.ExcluirAmigo(autenticado, SolicitarPalavraChave())) {
                        Console.WriteLine("AMIGO EXCLUIDO COM SUCESSO");
                    } else {
                        Console.WriteLine("ERRO AO EXCLUIR AMIGO");
                    }
                    break;

                default:
                    Console.WriteLine("OPÇÃO INVÁLIDA");
                    break;
            }
            Console.ReadKey();
        }

        private static void ListarAmigos(List<Amigo> amigos) {
            int i = 0;
            Console.Clear();
            Console.WriteLine("AMIGOS LOCALIZADO");
            foreach (Amigo a in amigos) {
                Console.WriteLine($"{i} - {a.Nome} {a.SobreNome}");
                i++;
            }
        }

        private static int EscolherAmigo() {
            int selecao = 0;
            Console.WriteLine("Escolha um amigo");
            try {
                selecao = Int32.Parse(Console.ReadLine());
            } catch(Exception e) {
                selecao = 0;
                Console.WriteLine("Valor inválido...");
            }            
            return selecao;
        }

        private static void ExecutaSelecao(int opcaoSelecionada) {
            switch (opcaoSelecionada) {

                // logar
                case 1:
                    Usuario u = ServiceUsuario.Logar(SolicitarDadosLogar());

                    if (Autenticado(u)) {
                        SolicitaAcaoAutenticado(u);
                    } else {
                        Console.WriteLine("ERRO DE AUTENTICACAO");
                        Console.WriteLine("Aperte uma tecla para retornar");
                        Console.ReadLine();
                    }
                    break;

                // registrar novo usuario
                case 2:
                    ServiceUsuario.CadastrarUsuario(SolicitarDadosCadastrar());
                    break;

                // sair
                case 3:
                    Console.WriteLine("Fim da execucao. Aperte uma tecla para finalizar");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("'OPÇÃO INVALIDA'");
                    break;
            }
        }

        private static bool Autenticado(Usuario u) {
            return u != null;
        }
    }
}