using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueDeEquipamentos
{
    public class Chamado
    {
        public static int idContador;
        public int idChamado;
        public int idEquipamento { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public DateTime dataAbertura { get; set; }
        public DateTime diasEmAberto { get; set; }
        public Equipamento equipamento;
        public static List<Chamado> listaChamados = new List<Chamado>();

        public Chamado(int idChamado, string titulo, string descricao, int idEquipamento, DateTime dataAbertura, Equipamento equipamento)
        {
            this.idChamado = idChamado;
            this.titulo = titulo;
            this.descricao = descricao;
            this.idEquipamento = idEquipamento;
            this.dataAbertura = dataAbertura;
            this.equipamento = equipamento;
        }

        public static void MenorQueCincoCaracteres(string titulo)
        {
            if (titulo.Length < 6)
            {
                Console.WriteLine("\nNão conter menos que 6 caracteres! Tente novamente.");
                Console.ReadKey();

                RegistrarChamado();
            }
        }
        public static void RegistrarChamado()
        {
            Console.Clear();
            Console.WriteLine("- Registrar Chamado -\n");

            Console.WriteLine("Informe o título do chamado: ");
            string titulo = Console.ReadLine();

            MenorQueCincoCaracteres(titulo);

            Console.WriteLine("Informe a descrição do chamado: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Informe o id do equipamento: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a data de abertura do chamado: ");
            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

            idContador++;

            foreach (var item in Equipamento.listaEquipamentos)
            {
                if (idEquipamento == item.id)
                {
                    Chamado chamados = new Chamado(idContador, titulo, descricao, idEquipamento, dataAbertura, item);
                    listaChamados.Add(chamados);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nChamado registrado com sucesso!");
                    Console.ResetColor();

                    Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");
                    Console.ReadKey();

                    Program.MenuChamado();
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nId não encontrado!");
            Console.ResetColor();

            Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");
            Console.ReadKey();

            Program.MenuChamado();
        }
        public static void VizualizacaoDosChamados()
        {
            if (listaChamados.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("- Lista de chamados -\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão existe nenhum chamado na lista!!");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");

                Console.ReadKey();
                Program.MenuChamado();
            }
            if (listaChamados.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("- Lista de chamados -\n");

                Console.Write("{0,-2} | {1,-15} | {2,-18} | {3,-18} | {4,-20} |", "ID", "Título", "Descrição", "Nome Equipamento", "Data de abertura");

                foreach (var item in listaChamados)
                {
                    Console.Write("\n{0,-2} | {1,-15} | {2,-18} | {3,-18} | {4,-20} |", item.idChamado, item.titulo, item.descricao, item.equipamento.nome, item.dataAbertura.ToString("dd/MM/yyyy"));
                }

                Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");

                Console.ReadKey();
                Program.MenuChamado();
            }
        }
        public static void EditarChamado()
        {
            Console.Clear();
            
            if (listaChamados.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("- Editar chamado -\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão existe nenhum chamado na lista!!");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");

                Console.ReadKey();
                Program.MenuChamado();
            }
            else
            {
                Console.WriteLine("- Edita Equipamento - ");

                Console.WriteLine("\nInforme o id do chamado que deseja editar: ");
                int idEditar = Convert.ToInt32(Console.ReadLine());

                foreach (var item in listaChamados)
                {
                    if (idEditar == item.equipamento.id)
                    {
                        Console.Clear();
                        Console.WriteLine("- Editar Chamado -\n");

                        Console.WriteLine("Informe o título do chamado: ");
                        string tituloAtualizado = Console.ReadLine();

                        Console.WriteLine("Informe a descrição do chamado: ");
                        string descricaoAtualizado = Console.ReadLine();

                        Console.WriteLine("Informe a data de abertura do chamado: ");
                        DateTime dataAberturaAtualizado = Convert.ToDateTime(Console.ReadLine());


                        if (tituloAtualizado != item.titulo)
                            item.titulo = tituloAtualizado;
                        if (descricaoAtualizado != item.descricao)
                            item.descricao = descricaoAtualizado;
                        if (dataAberturaAtualizado != item.dataAbertura)
                            item.dataAbertura = dataAberturaAtualizado;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nChamado editado com sucesso!");
                        Console.ResetColor();

                        Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");
                        Console.ReadKey();

                        Program.MenuChamado();
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nID não encontrado!");
                Console.ResetColor();

                Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                Program.MenuEquipamento();
            }
        }
        public static void RemoveChamado()
        {
            Console.Clear();

            if (listaChamados.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("- Remove chamado -\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão existe nenhum chamado na lista!!");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");

                Console.ReadKey();
                Program.MenuChamado();
            }
            else
            {
                Console.WriteLine("- Remove de Chamado -\n");

                Console.WriteLine("Informe o id do chamado que deseja remover: ");
                int idRemover = Convert.ToInt32(Console.ReadLine());

                foreach (var item in listaChamados)
                {
                    if (idRemover == item.idChamado)
                    {
                        listaChamados.Remove(item);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nChamado Removido!");
                        Console.ResetColor();

                        Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");
                        Console.ReadKey();

                        Program.MenuChamado();

                        return;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nID não encontrado!");
                Console.ResetColor();

                Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                Program.MenuChamado();
            }
        }
    }
}
