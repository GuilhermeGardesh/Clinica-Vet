namespace ClinicaVet.GestaoVeterinaria.Interfaces
{
    public interface ISeedInitialDependencies
    {
        Task SeedUsersAsync();
        Task SeedRolesAsync();
        Task SeedPoliticasDeAcessoAsync();

    }
}
