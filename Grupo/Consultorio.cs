using System;
using System.Collections.Generic;
using System.Linq;

public class Consultorio
{
    private List<Medico> medicos = new List<Medico>();
    private List<Paciente> pacientes = new List<Paciente>();
    private List<Exame> exames = new List<Exame>();
    private List<Atendimento> atendimentos = new List<Atendimento>();
    private Relatorios relatorios;

    public Consultorio()
    {
        // Inicializa a instância de Relatorios
        relatorios = new Relatorios(medicos, pacientes, atendimentos);
    }

    private int CalcularIdade(DateTime dataNascimento)
    {
        int idade = DateTime.Now.Year - dataNascimento.Year;
        if (DateTime.Now < dataNascimento.AddYears(idade)) idade--;

        return idade;
    }

    private void MostrarMedicos(List<Medico> lista)
    {
        Console.WriteLine("=========== Médicos Encontrados ===========");
        foreach (var medico in lista)
        {
            Console.WriteLine($"Nome: {medico.Nome}, Data de Nascimento: {medico.DataNascimento.ToShortDateString()}, CPF: {medico.CPF}, CRM: {medico.CRM}");
        }
    }

    private void MostrarPacientes(List<Paciente> lista)
    {
        Console.WriteLine("=========== Pacientes Encontrados ===========");
        foreach (var paciente in lista)
        {
            Console.WriteLine($"Nome: {paciente.Nome}, Data de Nascimento: {paciente.DataNascimento.ToShortDateString()}, CPF: {paciente.CPF}, Sexo: {paciente.Sexo}, Sintomas: {string.Join(", ", paciente.Sintomas)}");
        }
    }

    public void Executar()
    {
        while (true)
        {
            Console.WriteLine("=========== Tech Med ===========");
            Console.WriteLine("1. Inserir Médico");
            Console.WriteLine("2. Remover Médico");
            Console.WriteLine("3. Inserir Paciente");
            Console.WriteLine("4. Remover Paciente");
            Console.WriteLine("5. Iniciar Atendimento");
            Console.WriteLine("6. Finalizar Atendimento");
            Console.WriteLine("7. Relatórios");
            Console.WriteLine("8. Sair");
            Console.Write("Escolha uma opção: ");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    InserirMedico();
                    break;
                case "2":
                    RemoverMedico();
                    break;
                case "3":
                    InserirPaciente();
                    break;
                case "4":
                    RemoverPaciente();
                    break;
                case "5":
                    IniciarAtendimento();
                    break;
                case "6":
                    FinalizarAtendimento();
                    break;
                case "7":
                    GerarRelatorios();
                    break;
                case "8":
                    Console.WriteLine("Saindo do programa. Até logo!");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine(); // Adicione uma linha em branco para melhorar a legibilidade
        }
    }

    private void InserirMedico()
    {
        Medico medico = new Medico();
        Console.Write("Nome do médico: ");
        medico.Nome = Console.ReadLine();
        Console.Write("Data de Nascimento (DD/MM/AAAA): ");
        medico.DataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("CPF (11 dígitos): ");
        medico.CPF = Console.ReadLine();
        Console.Write("CRM: ");
        medico.CRM = Console.ReadLine();

        medicos.Add(medico);
        Console.WriteLine("Médico inserido com sucesso!");
    }

    private void RemoverMedico()
    {
        Console.Write("Digite o CPF do médico a ser removido: ");
        string cpf = Console.ReadLine();
        Medico medico = medicos.FirstOrDefault(m => m.CPF == cpf);

        if (medico != null)
        {
            medicos.Remove(medico);
            Console.WriteLine("Médico removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Médico não encontrado.");
        }
    }

    private void InserirPaciente()
    {
        Paciente paciente = new Paciente();
        Console.Write("Nome do paciente: ");
        paciente.Nome = Console.ReadLine();
        Console.Write("Data de Nascimento (DD/MM/AAAA): ");
        paciente.DataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("CPF (11 dígitos): ");
        paciente.CPF = Console.ReadLine();
        Console.Write("Sexo: ");
        paciente.Sexo = Console.ReadLine();
        Console.Write("Sintomas (separados por vírgula): ");
        paciente.Sintomas = Console.ReadLine().Split(',').Select(s => s.Trim()).ToList();

        pacientes.Add(paciente);
        Console.WriteLine("Paciente inserido com sucesso!");
    }

    private void RemoverPaciente()
    {
        Console.Write("Digite o CPF do paciente a ser removido: ");
        string cpf = Console.ReadLine();
        Paciente paciente = pacientes.FirstOrDefault(p => p.CPF == cpf);

        if (paciente != null)
        {
            pacientes.Remove(paciente);
            Console.WriteLine("Paciente removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Paciente não encontrado.");
        }
    }

    private void IniciarAtendimento()
    {
        Atendimento atendimento = new Atendimento();
        Console.Write("CPF do médico responsável: ");
        string cpfMedico = Console.ReadLine();
        atendimento.MedicoResponsavel = medicos.FirstOrDefault(m => m.CPF == cpfMedico);

        Console.Write("CPF do paciente: ");
        string cpfPaciente = Console.ReadLine();
        atendimento.Paciente = pacientes.FirstOrDefault(p => p.CPF == cpfPaciente);

        if (atendimento.MedicoResponsavel != null && atendimento.Paciente != null && atendimento.MedicoResponsavel.CPF == atendimento.Paciente.CPF)
        {
            Console.WriteLine("Um médico não pode ser paciente e vice-versa. Tente novamente.");
        }
        else
        {
            Console.Write("Início do atendimento (DD/MM/AAAA HH:mm): ");
            atendimento.Inicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);

            Console.Write("Suspeita inicial: ");
            atendimento.SuspeitaInicial = Console.ReadLine();

            // Adicione lógica para incluir exames, se necessário

            Atendimento atendimentoExistente = atendimentos.FirstOrDefault(a => a.MedicoResponsavel == atendimento.MedicoResponsavel && a.Paciente == atendimento.Paciente);

            if (atendimentoExistente != null)
            {
                Console.WriteLine("Este médico já está atendendo este paciente.");
            }
            else
            {
                atendimentos.Add(atendimento);
                Console.WriteLine("Atendimento iniciado com sucesso!");
            }
        }
    }

    private void FinalizarAtendimento()
    {
        Console.Write("CPF do médico responsável: ");
        string cpfMedico = Console.ReadLine();
        Medico medico = medicos.FirstOrDefault(m => m.CPF == cpfMedico);

        Console.Write("CPF do paciente: ");
        string cpfPaciente = Console.ReadLine();
        Paciente paciente = pacientes.FirstOrDefault(p => p.CPF == cpfPaciente);

        Atendimento atendimento = atendimentos.FirstOrDefault(a => a.MedicoResponsavel == medico && a.Paciente == paciente);

        if (atendimento != null)
        {
            Console.Write("Fim do atendimento (DD/MM/AAAA HH:mm): ");
            atendimento.Fim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);

            if (atendimento.Fim <= atendimento.Inicio)
            {
                Console.WriteLine("A data final deve ser posterior à data inicial.");
            }
            else
            {
                Console.Write("Diagnóstico final: ");
                atendimento.DiagnosticoFinal = Console.ReadLine();

                Console.WriteLine("Atendimento finalizado com sucesso!");
            }
        }
        else
        {
            Console.WriteLine("Atendimento não encontrado.");
        }
    }

    private void GerarRelatorios()
    {
        Console.WriteLine("=========== Relatórios ===========");
        Console.WriteLine("1. Médicos com idade entre dois valores.");
        Console.WriteLine("2. Pacientes com idade entre dois valores.");
        Console.WriteLine("3. Pacientes do sexo informado pelo usuário.");
        Console.WriteLine("4. Pacientes em ordem alfabética.");
        Console.WriteLine("5. Pacientes cujos sintomas contenham texto informado pelo usuário.");
        Console.WriteLine("6. Médicos e Pacientes aniversariantes do mês informado.");
        Console.WriteLine("7. Atendimentos em aberto (sem finalizar) em ordem decrescente pela data de início.");
        Console.WriteLine("8. Médicos em ordem decrescente da quantidade de atendimentos concluídos.");
        Console.WriteLine("9. Atendimentos cuja suspeita ou diagnóstico final contenham determinada palavra.");
        Console.WriteLine("10. Os 10 exames mais utilizados nos atendimentos.");

        Console.Write("Escolha um número de relatório: ");

        string escolha = Console.ReadLine();
        switch (escolha)
        {
            case "1":
                RelatorioMedicosComIdadeEntreDoisValores();
                break;
            case "2":
                RelatorioPacientesComIdadeEntreDoisValores();
                break;
            case "3":
                RelatorioPacientesPorSexo();
                break;
            case "4":
                RelatorioPacientesEmOrdemAlfabetica();
                break;
            case "5":
                RelatorioPacientesComSintomasContendoTexto();
                break;
            // Adicione casos para os outros relatórios
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

    private void RelatorioMedicosComIdadeEntreDoisValores()
    {
        Console.Write("Informe a idade mínima: ");
        int idadeMinima = int.Parse(Console.ReadLine());

        Console.Write("Informe a idade máxima: ");
        int idadeMaxima = int.Parse(Console.ReadLine());

        var medicosComIdadeEntre = medicos
            .Where(m => CalcularIdade(m.DataNascimento) >= idadeMinima && CalcularIdade(m.DataNascimento) <= idadeMaxima)
            .ToList();

        MostrarMedicos(medicosComIdadeEntre);
    }

    private void RelatorioPacientesComIdadeEntreDoisValores()
    {
        Console.Write("Informe a idade mínima: ");
        int idadeMinima = int.Parse(Console.ReadLine());

        Console.Write("Informe a idade máxima: ");
        int idadeMaxima = int.Parse(Console.ReadLine());

        var pacientesComIdadeEntre = pacientes
            .Where(p => CalcularIdade(p.DataNascimento) >= idadeMinima && CalcularIdade(p.DataNascimento) <= idadeMaxima)
            .ToList();

        MostrarPacientes(pacientesComIdadeEntre);
    }

    private void RelatorioPacientesPorSexo()
    {
        Console.Write("Informe o sexo desejado (M/F): ");
        string sexo = Console.ReadLine();

        var pacientesPorSexo = pacientes
            .Where(p => p.Sexo.Equals(sexo, StringComparison.OrdinalIgnoreCase))
            .ToList();

        MostrarPacientes(pacientesPorSexo);
    }

    private void RelatorioPacientesEmOrdemAlfabetica()
    {
        var pacientesOrdenados = pacientes.OrderBy(p => p.Nome).ToList();
        MostrarPacientes(pacientesOrdenados);
    }

    private void RelatorioPacientesComSintomasContendoTexto()
    {
        Console.Write("Informe o texto dos sintomas desejado: ");
        string textoSintomas = Console.ReadLine();

        var pacientesComSintomas = pacientes
            .Where(p => p.Sintomas.Any(s => s.Contains(textoSintomas, StringComparison.OrdinalIgnoreCase)))
            .ToList();

        MostrarPacientes(pacientesComSintomas);
    }

    // Adicione métodos para os outros relatórios aqui...

    // ... Restante do código
}
