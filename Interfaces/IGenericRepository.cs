namespace ClinicaVet.GestaoVeterinaria.Interfaces
{
    public interface IGenericRepository<Entidade>
        where Entidade : class
    {
        IQueryable<Entidade> ObterTodos();
        Entidade ObterPorId(int id);
        void Inserir(Entidade entidade);
        void InserirVarios(List<Entidade> entidades);
        void Atualizar(Entidade entidade);
        void Deletar(Entidade entidade);
        void Salvar();
    }
}
