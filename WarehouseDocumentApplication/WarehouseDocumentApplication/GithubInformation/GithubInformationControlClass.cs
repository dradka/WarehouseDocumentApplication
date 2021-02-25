using Octokit;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WarehouseDocumentApplication.Utils;

namespace WarehouseDocumentApplication.GithubInformation
{
    public class GithubInformationControlClass : BaseControlClass
    {
        private const string _userName = "dradka";
        private const string _repositoryName = "WarehouseDocumentApplication";
        
        private GithubInformation _githubInformationItem;
        public GithubInformation GithubInformationItem
        {
            get { return _githubInformationItem; }
            set { SetProperty(ref _githubInformationItem, value); }
        }

        public async Task LoadData()
        {
            try
            {
                string name = Assembly.GetExecutingAssembly().GetName().Name;
                var productInformation = new ProductHeaderValue(name);
                var client = new GitHubClient(productInformation);
                Repository repository = await client.Repository.Get(_userName, _repositoryName);

                GithubInformationItem = new GithubInformation
                {
                    RepositoryName = repository.Name,
                    UserName = repository.Owner.Login,
                    Rate = repository.StargazersCount,
                    DateCreated = repository.CreatedAt.Date
                };
            }
            catch(Exception)
            {
                MessageBoxUtils.ShowErrorMessage("Wystąpił błąd podczas odczytywania informacji o repozytorium");
                GithubInformationItem = new GithubInformation();
            }
        }
    }
}
