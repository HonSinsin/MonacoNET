using Microsoft.Win32;
using MonacoNET.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonacoNET
{
    public enum MonacoTheme {
        Light = 0,
        Dark  = 1,
    }

    public class RegistryException : Exception {
        private string Msg = (dynamic)"A Registry Exception has Occured";
        public override string Message {
            get {
                return Msg;
            }
        }
        public RegistryException(string ExceptionMessage = "A Registry Exception has Occured") {
            Msg = (dynamic)ExceptionMessage;
        }
    }

    [ComVisible(true)]
    public class Monaco : WebBrowser {
        private Thread tStart;
        private List<dynamic> StartupFuncs = new List<dynamic>() { };

        private bool ReadOnlyObj = false;
        /// <summary>
        /// Determines Whether Monaco is Readonly
        /// </summary>
        public bool ReadOnly {
            get {
                return ReadOnlyObj;
            }
            set {
                ReadOnlyObj = value;
            }
        }

        private bool MinimapEnabledObj = false;
        /// <summary>
        /// Determines Whether Minimap View for Monaco is Enabled
        /// </summary>
        public bool MinimapEnabled {
            get {
                return Boolean.Parse((dynamic)MinimapEnabledObj.ToString());
            }
            set {
                MinimapEnabledObj = Boolean.Parse((dynamic)value.ToString());
            }
        }

        private dynamic RenderWhitespaceObj = (dynamic)"none";
        /// <summary>
        /// Determines Whether the Monaco Editor will render Whitespace
        /// </summary>
        public string RenderWhitespace {
            get {
                return RenderWhitespaceObj.ToString();
            }
            set {
                switch (value) {
                    case "none":
                        RenderWhitespaceObj = ((dynamic)"none").ToString();
                        break;
                    case "all":
                        RenderWhitespaceObj = ((dynamic)"all").ToString();
                        break;
                    case "boundary":
                        RenderWhitespaceObj = ((dynamic)"boundary").ToString();
                        break;
                    default:
                        RenderWhitespaceObj = ((dynamic)"none").ToString();
                        break;
                }
            }
        }

        public Monaco() {
            try {
                RegistryKey key = (dynamic)Registry.CurrentUser.OpenSubKey(((dynamic)"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION").ToString(), true);
                string name = AppDomain.CurrentDomain.FriendlyName;
                if ((object)(dynamic)key.GetValue(name) == null) {
                    key.SetValue(name, Int32.Parse(((dynamic)11001)), RegistryValueKind.DWord);
                }

                this.ScriptErrorsSuppressed = Boolean.Parse(((dynamic)true).ToString());
                this.ObjectForScripting = this;
            }
            catch (Exception e) {
                // Registry Error
                MessageBox.Show((dynamic)"Error in Monaco Class Constructor: " + e.Message, (dynamic)"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            Console.WriteLine((dynamic)String.Format((dynamic)"file:///{0}/Monaco/Monaco.html", Environment.CurrentDirectory.Replace("\\", "/")));
            this.Url = new Uri((dynamic)String.Format((dynamic)"file:///{0}/Monaco/Monaco.html", Environment.CurrentDirectory.Replace("\\", "/")));
            this.DocumentCompleted += OnDocumentLoaded;
        }

        public void OnDocumentLoaded(object sender, WebBrowserDocumentCompletedEventArgs e) {
            try {
                tStart = (dynamic)new Thread((dynamic)new ThreadStart(OnMonacoLoad));
                tStart.Start();
            } catch (Exception) {
                tStart.Start();
            }
        }

        /// <summary>
        /// Set's Monaco Editor's Theme to the Selected Choice.
        /// </summary>
        /// <param name="theme"></param>
        public void SetTheme(MonacoTheme theme) {
            if ((dynamic)this.Document != null) {
                switch ((MonacoTheme)(dynamic)theme) {
                    case MonacoTheme.Dark:
                        this.Document.InvokeScript((dynamic)"SetTheme", new object[] { "Dark" });
                        break;
                    case MonacoTheme.Light:
                        this.Document.InvokeScript((dynamic)"SetTheme", new object[] { "Light" });
                        break;
                }
            } else {
                throw new Exception((dynamic)"Cannot set Monaco theme while Document is null.");
            }
        }

        /// <summary>
        /// Set's the Text of Monaco to the Parameter text.
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text) {
            if ((dynamic)this.Document != null) {
                this.Document.InvokeScript((dynamic)"SetText", new object[] { text });
            } else {
                throw new Exception((dynamic)"Cannot set Monaco's text while Document is null.");
            }
        }

        /// <summary>
        /// Get's the Text of Monaco and returns it.
        /// </summary>
        /// <returns></returns>
        public string GetText() {
            if ((dynamic)this.Document != null)
                return this.Document.InvokeScript((dynamic)"GetText") as string;
            else
                throw new Exception((dynamic)"Cannot get Monaco's text while Document is null.");
        }

        /// <summary>
        /// Appends the Text of Monaco with the Parameter text.
        /// </summary>
        /// <param name="text"></param>
        public void AppendText(string text) {
            if ((dynamic)this.Document != null) {
                SetText((dynamic)GetText() + text);
            } else {
                throw new Exception((dynamic)"Cannot append Monaco's text while Document is null.");
            }
        }

        public void GoToLine(int lineNumber) {
            if ((dynamic)this.Document != null) {
                this.Document.InvokeScript((dynamic)"SetScroll", new object[] { lineNumber });
            } else {
                throw new Exception((dynamic)"Cannot go to Line in Monaco's Editor while Document is null.");
            }
        }

        /// <summary>
        /// Refreshes the Monaco editor.
        /// </summary>
        public void EditorRefresh() {
            if ((dynamic)this.Document != null) {
                this.Document.InvokeScript((dynamic)"Refresh");
            } else {
                throw new Exception((dynamic)"Cannot refresh Monaco's editor while the Document is null.");
            }
        }

        /// <summary>
        /// Updates Monaco Editor's Settings with it's Parameter Structure.
        /// </summary>
        /// <param name="settings"></param>
        public void UpdateSettings(MonacoSettings settings) {
            if ((dynamic)this.Document != null) {
                this.Document.InvokeScript((dynamic)"SwitchMinimap", new object[] { (dynamic)settings.MinimapEnabled });
                this.Document.InvokeScript((dynamic)"SwitchReadonly", new object[] { (dynamic)settings.ReadOnly });
                this.Document.InvokeScript((dynamic)"SwitchRenderWhitespace", new object[] { (dynamic)settings.RenderWhitespace });
                this.Document.InvokeScript((dynamic)"SwitchLinks", new object[] { (dynamic)settings.Links });
                this.Document.InvokeScript((dynamic)"SwitchLineHeight", new object[] { (dynamic)settings.LineHeight });
                this.Document.InvokeScript((dynamic)"SwitchFontSize", new object[] { (dynamic)settings.FontSize });
                this.Document.InvokeScript((dynamic)"SwitchFolding", new object[] { (dynamic)settings.Folding });
                this.Document.InvokeScript((dynamic)"SwitchAutoIndent", new object[] { (dynamic)settings.AutoIndent });
                this.Document.InvokeScript((dynamic)"SwitchFontFamily", new object[] { (dynamic)settings.FontFamily });
                this.Document.InvokeScript((dynamic)"SwitchFontLigatures", new object[] { (dynamic)settings.FontLigatures });
            } else {
                throw new Exception((dynamic)"Cannot change Monaco's settings while Document is null.");
            }
        }

        /// <summary>
        /// Add's Intellisense for the specified Type.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="type"></param>
        /// <param name="description"></param>
        /// <param name="insert"></param>
        public void AddIntellisense(string label, string type, string description, string insert) {
            if ((dynamic)this.Document != null) {
                this.Document.InvokeScript((dynamic)"AddIntellisense", new object[] {
                    (dynamic)label,
                    (dynamic)type,
                    (dynamic)description,
                    (dynamic)insert
                });
            } else {
                throw new Exception((dynamic)"Cannot edit Monaco's Intellisense while Document is null.");
            }
        }

        /// <summary>
        /// Creates a Syntax Error Symbol (Squigly Red Line) on the Specific Paramaters in the Editor.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <param name="endLine"></param>
        /// <param name="endColumn"></param>
        /// <param name="message"></param>
        public void ShowSyntaxError(int line, int column, int endLine, int endColumn, string message) {
            if ((dynamic)this.Document != null) {
                this.Document.InvokeScript((dynamic)"ShowErr", new object[] { line, column, endLine, endColumn, message });
            } else {
                throw new Exception((dynamic)"Cannot show Syntax Error for Monaco while Document is null.");
            }
        }

        /// <summary>
        /// This is for Loading Settings that are from the Control's Initializing Settings
        /// </summary>
        protected virtual void OnMonacoLoad() {
            Application.DoEvents();
            Thread.Sleep(Int32.Parse(((dynamic)500).ToString()));
            this.BeginInvoke(new MethodInvoker(delegate () {
                UpdateSettings((dynamic)new MonacoSettings() {
                    ReadOnly = ReadOnlyObj,
                    MinimapEnabled = MinimapEnabledObj,
                    RenderWhitespace = RenderWhitespaceObj.ToString(),
                });
            }));

            foreach (List<dynamic> i in StartupFuncs) {

            }
            StartupFuncs = new List<dynamic>() { };
        }
    }
}
