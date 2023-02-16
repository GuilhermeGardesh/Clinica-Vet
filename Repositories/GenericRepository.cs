using ClinicaVet.GestaoVeterinaria.Data;
using ClinicaVet.GestaoVeterinaria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVet.GestaoVeterinaria.Repositories
{
    public abstract class GenericRepository<Entidade> : IGenericRepository<Entidade> where Entidade : class
    {
        private readonly ClinicaVetDbContext _clinicaVetDbContext;
        private DbSet<Entidade> _db;
        protected GenericRepository(ClinicaVetDbContext clinicaVetDbContext)
        {
            _clinicaVetDbContext = clinicaVetDbContext;
            _db = clinicaVetDbContext.Set<Entidade>();
        }
        public Entidade ObterPorId(int id)
            => _db.Find(id);

        public IQueryable<Entidade> ObterTodos()
            => _db;

        public void Inserir(Entidade entidade)
        {
            _db.Add(entidade);
            Salvar();
        }

        public void Atualizar(Entidade entidade)
        {
            _clinicaVetDbContext.Entry(entidade).State = EntityState.Modified;
            Salvar();
        }

        public void Deletar(Entidade entidade)
        {
            _db.Remove(entidade);
            Salvar();
        }

        public void Salvar()
        {
            _clinicaVetDbContext.SaveChanges();
        }
    }
}
