using System;
using System.Collections.Generic;
using System.Linq;

public class Relatorios
{
    private List<Medico> medicos;
    private List<Paciente> pacientes;
    private List<Atendimento> atendimentos;

    public Relatorios(List<Medico> medicos, List<Paciente> pacientes, List<Atendimento> atendimentos)
    {
        this.medicos = medicos;
        this.pacientes = pacientes;
        this.atendimentos = atendimentos;
    }

    public void GerarRelatorios()
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

    // Métodos de apoio
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
}
