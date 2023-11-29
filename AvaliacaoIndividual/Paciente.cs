using System;

public class Paciente
{
    public string Nome { get; }
    public DateTime DataNascimento { get; }
    public string CPF { get; }
    public Sexo Sexo { get; }
    public string Sintomas { get; }

    public Paciente(string nome, DateTime dataNascimento, string cpf, Sexo sexo, string sintomas)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = ValidarCPF(cpf);
        Sexo = sexo;
        Sintomas = sintomas;
    }

    private string ValidarCPF(string cpf)
    {
     

        return cpf;
    }
}
