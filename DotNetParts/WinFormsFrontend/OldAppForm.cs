using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using Shared;
using System.Net.Http;
using System.Text;
//using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsFrontend
{
    public partial class OldAppForm : Form
    {
        private IHubProxy _hub;
        private SynchronizationContext _uiContext;
        private delegate void UiThreadDelegation();

        private Person _currentPerson;

        public OldAppForm()
        {
            InitializeComponent();

            _uiContext = SynchronizationContext.Current;

            string url = @"http://localhost:8080/";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("InteractionHub");
            connection.Start().Wait();

            // register listener on hub actions fired by other clients
            _hub.On<HubAction>("ActionRequested", (action) => OnActionRequested(action));

            // inform all other clients that an "authenticated" main-app is registered on the hub (insecure demo case)
            DispatchAction(new HubAction { Name = "login", Arguments = "" });
        }

        private void OnActionRequested(HubAction action)
        {
            switch (action.Name)
            {
                case "requestLogin":
                    // response with login
                    DispatchAction(new HubAction { Name = "login", Arguments = "" });
                    break;

                case "changePerson":
                    // display the same person as the sender of this action
                    Task.Run(() => RefreshActivePerson(action.Arguments));
                    break;

                case "editPerson":
                    // start edit mode and bring form to front
                    ProcessInUiThread(EditPerson);
                    ProcessInUiThread(BringFormToFront);
                    ProcessInUiThread(() => SetNotification(""));
                    break;

                default:
                    break;

            }
        }

        private async Task RefreshActivePerson(string id)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:44369/api/persons/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            _currentPerson = JsonConvert.DeserializeObject<Person>(content);
            ProcessInUiThread(() => PersonTextBox.Text = $"{_currentPerson.Firstname} {_currentPerson.Lastname}");
        }

        private void EditPerson()
        {
            FristnameTextBox.Text = _currentPerson.Firstname;
            LastnameTextBox.Text = _currentPerson.Lastname;

            SetEditorVisibility(true);
        }

        /// <summary>
        /// In WinForms the SignalR messages arrive in a different thread. According to this, we need a reference to
        /// the UI thread to proceed visible manipulations.
        /// </summary>
        /// <param name="uiDelegation">A delegate function with should be processed in the UI thread.</param>
        private void ProcessInUiThread(UiThreadDelegation uiDelegation)
        {
            _uiContext.Post(_ =>
            {
                uiDelegation();
            }, null);
        }

        private void BringFormToFront()
        {

            // Put all code that touches the UI here
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                TopMost = true;
                Focus();
                BringToFront();
                TopMost = false;
            }
        }

        private void StartWebButton_Click(object sender, System.EventArgs e)
        {
            // This is just a hyperlink.
            // For sure... the webserver on this uri has to be started in advance (ng serve...). 
            System.Diagnostics.Process.Start("http://localhost:4200/");
        }

        /// <summary>
        /// Dispatch a action to the hub, which will notify the other clients.
        /// </summary>
        /// <param name="action"></param>
        private void DispatchAction(HubAction action)
        {
            _hub.Invoke("DispatchAction", action);
        }

        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            Logout();
            Close();
        }

        private void OldAppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logout();
        }

        private void Logout()
        {
            // All connected clients have to be notified, that the leading app (old) is logged out.
            DispatchAction(new HubAction { Name = "logout", Arguments = "" });
        }

        private void SetNotification(string message, System.Drawing.Color? color = null)
        {
            NotificationLabel.Text = message;
            NotificationLabel.ForeColor = color ?? System.Drawing.Color.Black;
            NotificationLabel.BackColor = System.Drawing.Color.FromArgb(50, color ?? System.Drawing.Color.Transparent);
        }

        private async void SaveButton_Click(object sender, System.EventArgs e)
        {
            if (FristnameTextBox.Text.Trim().Length == 0 || LastnameTextBox.Text.Trim().Length == 0)
            {
                SetNotification("Please complete your entries", System.Drawing.Color.Red);
                return;
            }

            _currentPerson.Firstname = FristnameTextBox.Text;
            _currentPerson.Lastname = LastnameTextBox.Text;

            var httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(_currentPerson), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync($"https://localhost:44369/api/persons/{_currentPerson.Id}", content);
            response.EnsureSuccessStatusCode();

            DispatchAction(new HubAction { Name = "dataChanged" });

            SetEditorVisibility(false);

            SetNotification("Person saved", System.Drawing.Color.Green);

            SendToBack();

        }

        private void SetEditorVisibility(bool visible)
        {
            FristnameTextBox.Visible = visible;
            LastnameTextBox.Visible = visible;
            SaveButton.Visible = visible;
            CancelButton.Visible = visible;
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            SetEditorVisibility(false);
        }
    }
}