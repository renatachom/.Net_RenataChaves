using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Exemplo de uso
        Consultorio consultorio = new Consultorio();

        // Adicionar alguns médicos e pacientes interativamente
        AdicionarMedicosInterativamente(consultorio);
        AdicionarPacientesInterativamente(consultorio);

        // Exemplo de relatórios
        Console.WriteLine("Relatório 1: Médicos com idade entre 30 e 50 anos");
        var medicoRelatorio1 = consultorio.ObterMedicosComIdadeEntre(30, 50);
        ImprimirMedicos(medicoRelatorio1);

        Console.WriteLine("\nRelatório 2: Pacientes com idade entre 25 e 35 anos");
        var pacienteRelatorio2 = consultorio.ObterPacientesComIdadeEntre(25, 35);
        ImprimirPacientes(pacienteRelatorio2);

        Console.WriteLine("\nRelatório 3: Pacientes do sexo feminino");
        var pacienteRelatorio3 = consultorio.ObterPacientesPorSexo("Feminino");
        ImprimirPacientes(pacienteRelatorio3);

        Console.ReadLine();
    }

    static void AdicionarMedicosInterativamente(Consultorio consultorio)
    {
        Console.WriteLine("Adicionar Médicos:");
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"Médico {i + 1}:");
            string nome = SolicitarString("Nome: ");
            DateTime dataNascimento = SolicitarData("Data de Nascimento (dd/mm/yyyy): ");
            string cpf = SolicitarCPF();
            string crm = SolicitarString("CRM: ");

            try
            {
                consultorio.AdicionarMedico(new Medico(nome, dataNascimento, cpf, crm));
                Console.WriteLine($"Médico {nome} adicionado com sucesso.\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao adicionar médico: {ex.Message}\n");
                i--; // Permitir que o usuário insira novamente os dados para o médico
            }
        }
    }

    static void AdicionarPacientesInterativamente(Consultorio consultorio)
    {
        Console.WriteLine("Adicionar Pacientes:");
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"Paciente {i + 1}:");
            string nome = SolicitarString("Nome: ");
            DateTime dataNascimento = SolicitarData("Data de Nascimento (dd/mm/yyyy): ");
            string cpf = SolicitarCPF();
            string sexo = SolicitarString("Sexo (Masculino/Feminino): ");
            string sintomas = SolicitarString("Sintomas: ");

            try
            {
                consultorio.AdicionarPaciente(new Paciente(nome, dataNascimento, cpf, sexo, sintomas));
                Console.WriteLine($"Paciente {nome} adicionado com sucesso.\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao adicionar paciente: {ex.Message}\n");
                i--; // Permitir que o usuário insira novamente os dados para o paciente
            }
        }
    }

    static string SolicitarString(string mensagem)
    {
        Console.Write(mensagem);
        return Console.ReadLine();
    }

    static DateTime SolicitarData(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            if (DateTime.TryParse(Console.ReadLine(), out DateTime data))
                return data;
            else
                Console.WriteLine("Formato de data inválido. Tente novamente.");
        }
    }

    static string SolicitarCPF()
    {
        while (true)
        {
            string cpf = SolicitarString("CPF (11 dígitos): ");
            if (cpf.Length == 11)
                return cpf;
            else
                Console.WriteLine("CPF deve ter exatamente 11 dígitos. Tente novamente.");
        }
    }

   static void ImprimirMedicos(IEnumerable<Medico> medicos)
{
    Console.WriteLine("\nLista de Médicos:");
    foreach (var medico in medicos)
    {
        Console.WriteLine($"Nome: {medico.Nome}, CRM: {medico.CRM}, Idade: {medico.Idade}");
    }
}

static void ImprimirPacientes(IEnumerable<Paciente> pacientes)
{
    Console.WriteLine("\nLista de Pacientes:");
    foreach (var paciente in pacientes)
    {
        Console.WriteLine($"Nome: {paciente.Nome}, CPF: {paciente.CPF}, Idade: {paciente.Idade}, Sexo: {paciente.Sexo}, Sintomas: {paciente.Sintomas}");
    }
}

}
