using System;
using System.Collections.Generic;
using System.Linq;

public class Consultorio
{
    private List<Medico> medicos;
    private List<Paciente> pacientes;

    public Consultorio()
    {
        medicos = new List<Medico>();
        pacientes = new List<Paciente>();
    }

    public void AdicionarMedico(Medico medico)
    {
        if (!medicos.Any(m => m.CPF == medico.CPF) && !medicos.Any(m => m.CRM == medico.CRM))
        {
            medicos.Add(medico);
            Console.WriteLine($"Médico {medico.Nome} adicionado com sucesso.");
        }
        else
        {
            Console.WriteLine("CPF ou CRM já existente para um médico.");
        }
    }

    public void AdicionarPaciente(Paciente paciente)
    {
        if (!pacientes.Any(p => p.CPF == paciente.CPF))
        {
            pacientes.Add(paciente);
            Console.WriteLine($"Paciente {paciente.Nome} adicionado com sucesso.");
        }
        else
        {
            Console.WriteLine("CPF já existente para um paciente.");
        }
    }

    public IEnumerable<Medico> ObterMedicosComIdadeEntre(int idadeMinima, int idadeMaxima)
    {
        return medicos.Where(m => m.Idade >= idadeMinima && m.Idade <= idadeMaxima);
    }

    public IEnumerable<Paciente> ObterPacientesComIdadeEntre(int idadeMinima, int idadeMaxima)
    {
        return pacientes.Where(p => p.Idade >= idadeMinima && p.Idade <= idadeMaxima);
    }

    public IEnumerable<Paciente> ObterPacientesPorSexo(string sexo)
    {
        return pacientes.Where(p => p.Sexo.Equals(sexo, StringComparison.OrdinalIgnoreCase));
    }

    // Outras consultas e relatórios podem ser implementados aqui
}
