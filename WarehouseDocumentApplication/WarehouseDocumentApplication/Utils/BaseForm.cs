using System;
using System.Reactive.Disposables;
using System.Windows.Forms;

namespace WarehouseDocumentApplication.Utils
{
    public partial class BaseForm : Form, IHasControlClass<BaseControlClass>
    {
        public BaseControlClass ControlClass { get; set; }
        protected CompositeDisposable _disposables;
        public delegate void LoadCompletedEventHandler();
        public event LoadCompletedEventHandler LoadCompleted;

        public BaseForm()
        {
            InitializeComponent();
            _disposables = new CompositeDisposable();
        }

        private void BaseForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (LoadCompleted != null)
                LoadCompleted();
        }
    }
}
