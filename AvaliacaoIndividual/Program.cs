using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
           
            var medicos = new List<Medico>
            {
                new Medico("Dr. João", new DateTime(1980, 5, 15), "12345678901", "CRM12345"),
                new Medico("Dra. Maria", new DateTime(1975, 8, 20), "98765432101", "CRM54321")
            };

            var pacientes = new List<Paciente>
            {
                new Paciente("Lucas", new DateTime(1990, 3, 10), "11122233344", Sexo.Masculino, "Febre"),
                new Paciente("Marta", new DateTime(1985, 6, 25), "55566677788", Sexo.Feminino, "Dor de cabeça")
            };

            // Adicione médicos e pacientes à coleção
            var consultorio = new Consultorio(medicos, pacientes);

            // Exemplo de relatório 1: Médicos com idade entre dois valores

            var relatorioMedicosIdade = consultorio.ObterMedicosPorIdade(35, 50).ToList();
            Console.WriteLine("Médicos com idade entre 35 e 50 anos:");
            foreach (var medico in relatorioMedicosIdade)
            {   
            Console.WriteLine(medico.Nome);
            }           

            var relatorioPacientesIdade = consultorio.ObterPacientesPorIdade(30, 40).ToList();
            Console.WriteLine("\nPacientes com idade entre 30 e 40 anos:");
            foreach (var paciente in relatorioPacientesIdade)
            {
            Console.WriteLine(paciente.Nome);
            }   

       
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
