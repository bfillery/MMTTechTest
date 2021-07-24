using Common.Library;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WPF.Sample.ViewModelLayer;

namespace WPF.Sample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //connect to instance of the view model created by the xaml
            _viewModel = (MainWindowViewModel)this.Resources["viewModel"];

            MessageBroker.Instance.MessageReceived += Instance_MessageReceived;
        }

        private void Instance_MessageReceived(object sender, MessageBrokerEventArgs e)
        {
            switch (e.MessageName)
            {
                case MessageBrokerMessages.DISPLAY_STATUS_MESSAGE:
                    //set new status message
                    _viewModel.StatusMessage = e.MessagePayload.ToString();
                    break;

                case MessageBrokerMessages.CLOSE_USER_CONTROL:
                    CloseUserControl();
                    break;
            }
        }

        //Main windows's view model class
        private MainWindowViewModel _viewModel = null;


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mnu = (MenuItem)sender;
            string cmd = string.Empty;

            //The Tag property contains a command, OR
            //the name of a user control to load
            if(mnu.Tag!=null)
            {
                cmd = mnu.Tag.ToString();
                if (cmd.Contains("."))
                {
                    //display a user control
                    LoadUserControl(cmd);
                }
                else
                {
                    //process special commands
                    ProcessMenuCommands(cmd);
                }

                
            }
        }

        public void CloseUserControl()
        {
            //remove current user control
            contentArea.Children.Clear();
        }


        public void DisplayUserControl(UserControl uc)
        {
            //close current user control in contentArea
            CloseUserControl();

            //add new ser control to contentArea
            contentArea.Children.Add(uc);
        }


        public void LoadUserControl(string controlName)
        {
            if (!ShouldLoadUserControl(controlName)) 
                return;

            Type ucType = null;
            UserControl uc = null;

            //create Type from controlName parameter
            ucType = Type.GetType(controlName);
            if (ucType == null)
            {
                MessageBox.Show($"The Control: {controlName} does not exist.");
            }
            else
            {
                //create an instace of this control
                uc = (UserControl)Activator.CreateInstance(ucType);
                if (uc != null)
                {
                    //display control in contentArea
                    DisplayUserControl(uc);
                }
            }
        }


        private void ProcessMenuCommands(string command)
        {
            switch(command.ToLower())
            {
                case "exit":
                    this.Close();
                    break;

                default:
                    break;
            }
        }


        private bool ShouldLoadUserControl(string controlName)
        {
            bool ret = true;

            //make sure you don;t load a control that's already loaded
            if(contentArea.Children.Count > 0)
            {
                if(((UserControl)contentArea.Children[0]).GetType().Name == 
                        controlName.Substring(controlName.LastIndexOf(".") + 1))
                {
                    ret = false;
                }
            }
            
            return ret;
        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadApplication();

            _viewModel.ClearInfoMessages();

        }


        public async Task LoadApplication()
        {
            _viewModel.InfoMessage = "Loading State Codes...";
            await Dispatcher.BeginInvoke(new Action( () => {
                _viewModel.LoadStateCodes();
            }), DispatcherPriority.Background);

            _viewModel.InfoMessage = "Loading Country Codes...";
            await Dispatcher.BeginInvoke(new Action(() => {
                _viewModel.LoadCountryCodes();
            }), DispatcherPriority.Background);

            _viewModel.InfoMessage = "Loading Employee Types...";
            await Dispatcher.BeginInvoke(new Action(() => {
                _viewModel.LoadEmployeeTypes();
            }), DispatcherPriority.Background);
        }
    }
}
