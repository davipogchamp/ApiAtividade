using Modelo.Application.Interfaces;
using Modelo.Domain;
using Dapper;
using Modelo.Infra;
using Microsoft.Data.SqlClient;
namespace Modelo.Application

{
    public class AlunoApplication : IAlunoApplication
    {
        private readonly DbConnectionFactory _dbConnectionString;

        public AlunoApplication(DbConnectionFactory dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public async Task<Aluno> BuscarDadosAlunoID(int id) 
        {
            using var connection = _dbConnectionString.CreateConnection();
            var query = "SELECT Id, Nome, Email, Idade FROM Aluno WHERE Id = @Id";
            var aluno = await connection.QueryFirstOrDefaultAsync<Aluno>(query, new { Id = id });
            return aluno;
        }

        public async Task<string> InserirAluno(Aluno aluno)
        {
            try
            {
                using var connection = _dbConnectionString.CreateConnection();
                var query = "INSERT INTO Aluno (Id, Nome, Email, Idade) VALUES (@Id, @Nome, @Email, @Idade)";
                await connection.ExecuteAsync(query, aluno);
                return "Aluno inserido com sucesso.";
            }
            catch (Exception)
            {
                return "Falha ao inserir aluno!";
            }
        }

        public async Task<string> EditarAluno(Aluno aluno)
        {
            try
            {
                using var connection = _dbConnectionString.CreateConnection();
                var query = "UPDATE Aluno SET Nome = @Nome, Email = @Email, Idade = @Idade WHERE Id = @Id";
                await connection.ExecuteAsync(query, aluno);
                return "Aluno atualizado com sucesso.";
            }
            catch (Exception)
            {
                return "Falha ao editar aluno";
            }
        }

        public async Task<string> ExcluirAluno(int id)
        {
            try
            {
                using var connection = _dbConnectionString.CreateConnection();
                var query = "DELETE FROM Aluno WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
                return "Aluno excluído com sucesso.";
            }
            catch (Exception)
            {
                return "Falha ao excluir aluno";
            }
        }
    }
}
