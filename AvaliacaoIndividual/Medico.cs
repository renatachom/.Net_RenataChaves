using System;

public class Medico
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
    public string CRM { get; set; }

    public int Idade => DateTime.Now.Year - DataNascimento.Year;

    public Medico(string nome, DateTime dataNascimento, string cpf, string crm)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = cpf;
        CRM = crm;
    }
}
