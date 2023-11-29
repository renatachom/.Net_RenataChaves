using System;
using System.Collections.Generic;
using System.Linq;

public class Consultorio
{
    private List<Medico> medicos;
    private List<Paciente> pacientes;

    public Consultorio(List<Medico> medicos, List<Paciente> pacientes)
    {
        this.medicos = medicos;
        this.pacientes = pacientes;
    }

    public IEnumerable<Medico> ObterMedicosPorIdade(int idadeMinima, int idadeMaxima)
    {
        var dataAtual = DateTime.Now;
        return medicos.Where(m => (dataAtual - m.DataNascimento).Days / 365 >= idadeMinima
                                && (dataAtual - m.DataNascimento).Days / 365 <= idadeMaxima);
    }

    public IEnumerable<Paciente> ObterPacientesPorIdade(int idadeMinima, int idadeMaxima)
    {
        var dataAtual = DateTime.Now;
        return pacientes.Where(p => (dataAtual - p.DataNascimento).Days / 365 >= idadeMinima
                                  && (dataAtual - p.DataNascimento).Days / 365 <= idadeMaxima);
    }

}
