using AlunosAPI.Models;

namespace AlunosAPI.Services
{
    public interface IAlunosService
    {

        Task<IEnumerable<Aluno>> GetAlunos();
        Task<Aluno> GetAluno(int Id);

        Task<IEnumerable<Aluno>> GetAlunosByNome(string nome);

        Task CreateAluno(Aluno aluno);
        Task UpdateAluno(Aluno aluno);
        Task DeleteAluno(Aluno aluno);
    }
}
