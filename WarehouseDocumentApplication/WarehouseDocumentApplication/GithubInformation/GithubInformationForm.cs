using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseDocumentApplication.Utils;
using WarehouseDocumentApplication.WarehouseDocument;

namespace WarehouseDocumentApplication.GithubInformation
{
    public partial class GithubInformationForm : BaseForm, IHasControlClass<GithubInformationControlClass>
    {
        public new GithubInformationControlClass ControlClass
        {
            get { return base.ControlClass as GithubInformationControlClass; }
            set { base.ControlClass = value; }
        }

        public GithubInformationForm(GithubInformationControlClass controlClass)
        {
            InitializeComponent();
            ControlClass = controlClass;

        }

        public void AddDataBindings()
        {
            repositoryNameTextBox.DataBindings.Add(nameof(repositoryNameTextBox.Text),
                githubInformationBindingSource, nameof(ControlClass.GithubInformationItem.RepositoryName));
            userNameTextBox.DataBindings.Add(nameof(userNameTextBox.Text),
                githubInformationBindingSource, nameof(ControlClass.GithubInformationItem.UserName));
            rateTextBox.DataBindings.Add(nameof(rateTextBox.Text),
                githubInformationBindingSource, nameof(ControlClass.GithubInformationItem.Rate));

            Binding dateCreatedBinding = new Binding(nameof(dateCreatedTextBox.Text),
               githubInformationBindingSource, nameof(ControlClass.GithubInformationItem.DateCreated), true);
            dateCreatedBinding.FormatString = "dd.MM.yyyy";
            dateCreatedTextBox.DataBindings.Add(dateCreatedBinding);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void LoginForm_LoadCompleted()
        {
            var controlClass = ControlClass;
            if (controlClass != null)
            {
                await controlClass.LoadData();
                githubInformationBindingSource.DataSource = controlClass.GithubInformationItem;
                AddDataBindings();
            }
        }
    }
}
