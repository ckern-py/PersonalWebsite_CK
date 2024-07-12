using CK_Website_2024.Models;

namespace CK_Website_2024.DataLayer
{
    public interface IWebsiteAPI
    {
        void LogPageVisit(string pageName);
        public List<GitHubProjects> GetGitHubProjects();
    }
}
