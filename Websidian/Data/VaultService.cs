namespace Websidian.Data
{
    public class VaultService
    {
        IConfiguration _configuration;

        public VaultService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<VaultFile[]> GetFilesAsync()
        {
            string? vaultPath = _configuration["Obsidian:Vault"];
            var files = Directory.GetFiles(vaultPath, "*", SearchOption.AllDirectories);

            return Task.FromResult(files.Select(file => new VaultFile
            {
                Name = file
            }).ToArray());
        }
    }
}
