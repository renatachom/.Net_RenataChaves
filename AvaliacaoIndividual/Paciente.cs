using System;

public class Paciente
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    private string _cpf;
    public string CPF
    {
        get => _cpf;
        set
        {
            if (value.Length == 11)
                _cpf = value;
            else
                throw new ArgumentException("CPF deve ter 11 dígitos.");
        }
    }
    public string Sexo { get; set; }
    public string Sintomas { get; set; }

    public int Idade => DateTime.Now.Year - DataNascimento.Year;

    public Paciente(string nome, DateTime dataNascimento, string cpf, string sexo, string sintomas)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = cpf;
        Sexo = sexo;
        Sintomas = sintomas;
    }
}
