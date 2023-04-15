using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueDeEquipamentos
{
    public class Equipamento
    {
        public static int idEquipamento;
        public int id { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public int numeroSerie { get; set; }
        public DateTime dataFabricacao { get; set; }
        public string fabricante { get; set; }

        public static List<Equipamento> listaEquipamentos = new List<Equipamento>();
        public static List<Chamado> listaChamados = new List<Chamado>();

        public Equipamento(int id, string nome, double preco, int numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            this.id = id;
            this.nome = nome;
            this.preco = preco;
            this.numeroSerie = numeroSerie;
            this.dataFabricacao = dataFabricacao;
            this.fabricante = fabricante;
        }

        public static void MenorQueCincoCaracteres(string nome)
        {
            if (nome.Length < 6)
            {
                Console.WriteLine("\nNão conter menos que 6 caracteres! Tente novamente.");
                Console.ReadKey();

                CadastroDoEquipamento();
            }
        }
        public static void RemoverEquipamento()
        {
            Console.Clear();

            if (listaEquipamentos.Count != 0)
            {
                Console.WriteLine("- Remove equipamento -\n");

                Console.WriteLine("Informe o id do equipamento que deseja remover: ");
                int idRemover = Convert.ToInt32(Console.ReadLine());

                foreach (var item in listaEquipamentos)
                {
                    if (idRemover == item.id)
                    {
                        listaEquipamentos.Remove(item);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nEquipamento Removido!");
                        Console.ResetColor();

                        Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");
                        Console.ReadKey();

                        Program.MenuEquipamento();
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nID não encontrado!");
                Console.ResetColor();

                Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                Program.MenuEquipamento();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão a equipamentos cadastrados!");
                Console.ResetColor();

                Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                Program.MenuEquipamento();
            }
        }
        public static void EditarUmEquipamento()
        {
            Console.Clear();

            if (listaEquipamentos.Count != 0)
            {
                Console.WriteLine("- Edita Equipamento - ");

                Console.WriteLine("\nInforme o id do equipamento que deseja editar: ");
                int idEditar = Convert.ToInt32(Console.ReadLine());

                foreach (var item in listaEquipamentos)
                {
                    if (idEditar == item.id)
                    {
                        Console.Clear();
                        Console.WriteLine("- Dados do equipamento a ser editado -\n");
                        Console.WriteLine("*********************************************");
                        Console.WriteLine($"Nome: {item.nome} \nPreço: {item.preco} \nNúmero de série: {item.numeroSerie} \nData de Fabricação: {item.dataFabricacao} \nFabricante: {item.fabricante}");
                        Console.WriteLine("*********************************************");

                        Console.WriteLine("Informe o nome do equipamento: ");
                        var nomeAtualizado = Console.ReadLine();

                        Console.WriteLine("Informe o preço do equipamento: ");
                        var precoAtualizado = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Informe o número de série do equipamento: ");
                        var numeroDeSerieAtualizado = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Informe a data de fabricação do equipamento: ");
                        var dataDeFabricacaoAtualizado = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine("Informe o fabricante do equipamento: ");
                        var fabricanteAtualizado = Console.ReadLine();

                        if (nomeAtualizado != item.nome)
                            item.nome = nomeAtualizado;
                        if (precoAtualizado != item.preco)
                            item.preco = precoAtualizado;
                        if (numeroDeSerieAtualizado != item.numeroSerie)
                           item.numeroSerie = numeroDeSerieAtualizado;
                        if (dataDeFabricacaoAtualizado != item.dataFabricacao)
                            item.dataFabricacao = dataDeFabricacaoAtualizado;
                        if (fabricanteAtualizado != item.fabricante)
                            item.fabricante = fabricanteAtualizado;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nEquipamento editado com sucesso!");
                        Console.ResetColor();

                        Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");
                        Console.ReadKey();

                        Program.MenuEquipamento();
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID não encontrado!");
                Console.ResetColor();
                Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();
                Program.MenuEquipamento();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão a equipamentos cadastrados!");
                Console.ResetColor();

                Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                Program.MenuEquipamento();
            }
        }
        public static void VizualizacaoDosEquipamentos()
        {
            if (listaEquipamentos.Count == 0)
            {
                Console.Clear();
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão existe nenhum equipamento na lista!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("- Lista de equipamentos -\n");

                Console.Write("{0,-2} | {1,-15} | {2,-10} | {3,-5} | {4,-20} | {5,-10}", "ID", "Nome", "Preço", "Série", "Data de Fabricação", "Fabricante");
                Console.WriteLine(" ");

                foreach (var item in listaEquipamentos)
                {
                    Console.WriteLine("{0,-2} | {1,-15} | {2,-10} | {3,-5} | {4,-20} | {5,-10}", item.id, item.nome, item.preco, item.numeroSerie, item.dataFabricacao.ToString("dd/MM/yyyy"), item.fabricante);
                }
            }

            Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");

            Console.ReadKey();
            Program.MenuEquipamento();
        }
        public static void CadastroDoEquipamento()
        {
            Console.Clear();
            Console.WriteLine("- Cadastro Equipamento -\n");

            Console.WriteLine("Informe o nome do equipamento: ");
            string nome = Console.ReadLine();

            MenorQueCincoCaracteres(nome);

            Console.WriteLine("Informe o preço do equipamento: ");
            double preco = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Informe o número de série do equipamento: ");
            int numeroSerie = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a data de fabricação do equipamento: ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe o fabricante do equipamento: ");
            string fabricante = Console.ReadLine();

            idEquipamento++;

            Equipamento equipamentos = new Equipamento(idEquipamento, nome, preco, numeroSerie, dataFabricacao, fabricante);
            listaEquipamentos.Add(equipamentos);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEquipamento cadastrado com sucesso!");
            Console.ResetColor();

            Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");
            Console.ReadKey();

            Program.MenuEquipamento();
        }
    
    }
}
