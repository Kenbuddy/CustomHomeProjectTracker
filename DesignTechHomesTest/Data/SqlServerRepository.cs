using DesignTechHomesTest.Interfaces;
using DesignTechHomesTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignTechHomesTest.Data
{
    public class SqlServerRepository : IDbRepository
    {
        #region Field Members

        private readonly ApplicationDbContext _context;

        #endregion

        #region Constructor

        public SqlServerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Clients

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToListAsync();
        }

        public async Task<Client?> GetClientAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client?> GetClientNoTrackingAsync(int id)
        {
            return await _context.Clients.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddClientAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> HasClientsAsync()
        {
            return await _context.Clients.AnyAsync();
        }

        #endregion

        #region Projects

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.Include(p => p.Client).ToListAsync();
        }

        public async Task<Project?> GetProjectAsync(int id)
        {
            return await _context.Projects
            .Include(p => p.ProjectNotes)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project?> GetProjectNoTrackingAsync(int id)
        {
            return await _context.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        #endregion
    }
}
