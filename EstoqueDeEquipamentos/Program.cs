using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueDeEquipamentos
{
    internal class Program
    {
        static int tentativas = 0;

        static void Main(string[] args)
        {
            while (tentativas != 3)
            {
                MenuPrincipal();
            }

            Console.ReadKey();
        }

        public static void MenuChamado()
        {
            var opcaoChamado = 0;

            Console.Clear();
            Console.WriteLine("1- Registrar chamado \n2- Vizualizar chamados \n3- Editar chamado");
            Console.WriteLine("4- Excluir chamado \n5- Voltar ao menu principal\n");
            Console.Write("Informe a opção -> ");
            opcaoChamado = Convert.ToInt32(Console.ReadLine());

            switch (opcaoChamado)
            {
                case 1:
                    Chamado.RegistrarChamado();
                    break;

                case 2:
                    Chamado.VizualizacaoDosChamados();
                    break;

                case 3:
                    Chamado.EditarChamado();
                    break;

                case 4:
                    Chamado.RemoveChamado();
                    break;

                case 5:
                    MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Console.ReadKey();

                    MenuChamado();
                    break;
            }
        }
        public static void MenuEquipamento()
        {
            var opcaoEquipamento = 0;

            Console.Clear();
            Console.WriteLine("1- Cadastrar equipamento \n2- Vizualizar equipamentos \n3- Editar equipamento");
            Console.WriteLine("4- Excluir equipamento \n5- Voltar ao menu principal\n");
            Console.Write("Informe a opção -> ");
            opcaoEquipamento = Convert.ToInt32(Console.ReadLine());

            switch (opcaoEquipamento)
            {
                case 1:
                    Equipamento.CadastroDoEquipamento();
                    break;

                case 2:
                    Equipamento.VizualizacaoDosEquipamentos();
                    break;

                case 3:
                    Equipamento.EditarUmEquipamento();
                    break;

                case 4:
                    Equipamento.RemoverEquipamento();
                    break;

                case 5:
                    MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Console.ReadKey();

                    MenuEquipamento();
                    break;
            }
        }
        public static void MenuPrincipal()
        {
            var opcaoMenuPrincipal = 0;

            Console.Clear();
            Console.WriteLine("- Menu -");

            Console.WriteLine("1- Controle de equipamento \n2- Controle de Chamados\n3- Sair");
            Console.Write("\nInforme a opção -> ");
            opcaoMenuPrincipal = Convert.ToInt32(Console.ReadLine());

            switch (opcaoMenuPrincipal)
            {
                case 1:
                    MenuEquipamento();
                    break;

                case 2:
                    MenuChamado();
                    break;

                case 3:
                    Console.WriteLine("\nSaindo do sistema...");
                    Console.ReadKey();

                    Environment.Exit(3);
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
