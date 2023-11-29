using System;

public class Medico
{
    public string Nome { get; }
    public DateTime DataNascimento { get; }
    public string CPF { get; }
    public string CRM { get; }

    public Medico(string nome, DateTime dataNascimento, string cpf, string crm)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = ValidarCPF(cpf);
        CRM = ValidarCRM(crm);
    }

    private string ValidarCPF(string cpf) => cpf;

    private string ValidarCRM(string crm) => crm;
}
