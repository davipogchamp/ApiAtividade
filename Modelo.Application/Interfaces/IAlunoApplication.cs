using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Domain;

namespace Modelo.Application.Interfaces
{
    public interface IAlunoApplication
    {
        Task<Aluno> BuscarDadosAlunoID(int id);
        Task<string> InserirAluno(Aluno aluno);
        Task<string> EditarAluno(Aluno aluno);
        Task<string> ExcluirAluno(int id);
    }
}
