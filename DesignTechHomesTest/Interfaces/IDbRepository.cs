using DesignTechHomesTest.Models;

namespace DesignTechHomesTest.Interfaces
{
    public interface IDbRepository
    {
        #region Projects

        Task<IEnumerable<Project>> GetAllProjectsAsync();
      
        Task<Project?> GetProjectAsync(int id);
        
        Task<Project?> GetProjectNoTrackingAsync(int id);
        
        Task AddProjectAsync(Project project);
        
        Task UpdateProjectAsync(Project project);
        
        Task DeleteProjectAsync(int id);

        #endregion

        #region Clients

        Task<IEnumerable<Client>> GetAllClientsAsync();
        
        Task<Client?> GetClientAsync(int id);
        
        Task<Client?> GetClientNoTrackingAsync(int id);
        
        Task AddClientAsync(Client client);
        
        Task UpdateClientAsync(Client client);
        
        Task DeleteClientAsync(int id);

        Task<bool> HasClientsAsync();

        #endregion
    }
}
