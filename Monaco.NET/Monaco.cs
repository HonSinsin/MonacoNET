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
        private string Msg = "A Registry Exception has Occured";
        public override string Message {
            get {
                return Msg;
            }
        }
        public RegistryException(string ExceptionMessage = "A Registry Exception has Occured") {
            Msg = ExceptionMessage;
        }
    }

    [ComVisible(true)]
    public class Monaco : WebBrowser {
        public Action StartupFunction;
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
                return MinimapEnabledObj;
            }
            set {
                MinimapEnabledObj = value;
            }
        }

        /// <summary>
        /// Editor Text
        /// </summary>
        public override string Text {
            get {
                return GetText();
            } set {
                SetText(value);
            }
        }

        private string RenderWhitespaceObj = "none";
        /// <summary>
        /// Determines Whether the Monaco Editor will render Whitespace
        /// </summary>
        public string RenderWhitespace {
            get {
                return RenderWhitespaceObj;
            }
            set {
                switch (value) {
                    case "none":
                        RenderWhitespaceObj = "none";
                        break;
                    case "all":
                        RenderWhitespaceObj = "all";
                        break;
                    case "boundary":
                        RenderWhitespaceObj = "boundary";
                        break;
                    default:
                        RenderWhitespaceObj = "none";
                        break;
                }
            }
        }

        public Monaco() {
            try {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                string name = AppDomain.CurrentDomain.FriendlyName;
                if (key.GetValue(name) == null) {
                    key.SetValue(name, Int32.Parse("11001"), RegistryValueKind.DWord);
                }

                this.ScriptErrorsSuppressed = true;// Boolean.Parse((true).ToString());
                this.ObjectForScripting = this;
            }
            catch (Exception e) {
                // Registry Error
                MessageBox.Show("Error in Monaco Class Constructor: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            Console.WriteLine (String.Format("file:///{0}/Monaco/Monaco.html", Environment.CurrentDirectory.Replace("\\", "/")));
            this.Url = new Uri(String.Format("file:///{0}/Monaco/Monaco.html", Environment.CurrentDirectory.Replace("\\", "/")));
            this.DocumentCompleted += OnDocumentLoaded;
        }

        public void OnDocumentLoaded(object sender, WebBrowserDocumentCompletedEventArgs e) {
            try {
                tStart = new Thread(new ThreadStart(OnMonacoLoad));
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
            if (this.Document != null) {
                switch ((MonacoTheme)theme) {
                    case MonacoTheme.Dark:
                        this.Document.InvokeScript("SetTheme", new object[] { "Dark" });
                        break;
                    case MonacoTheme.Light:
                        this.Document.InvokeScript("SetTheme", new object[] { "Light" });
                        break;
                }
            } else {
                throw new Exception("Cannot set Monaco theme while Document is null.");
            }
        }

        /// <summary>
        /// Set's the Text of Monaco to the Parameter text.
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text) {
            if (this.Document != null) {
                this.Document.InvokeScript("SetText", new object[] { text });
            }
            else {
                throw new Exception("Cannot set Monaco's text while Document is null.");
            }
        }

        /// <summary>
        /// Get's the Text of Monaco and returns it.
        /// </summary>
        /// <returns></returns>
        public string GetText() {
            if (this.Document != null)
                return this.Document.InvokeScript("GetText") as string;
            else
                throw new Exception("Cannot get Monaco's text while Document is null.");
        }

        /// <summary>
        /// Appends the Text of Monaco with the Parameter text.
        /// </summary>
        /// <param name="text"></param>
        public void AppendText(string text) {
            if (this.Document != null) {
                SetText(GetText() + text);
            } else {
                throw new Exception("Cannot append Monaco's text while Document is null.");
            }
        }

        public void GoToLine(int lineNumber) {
            if (this.Document != null) {
                this.Document.InvokeScript("SetScroll", new object[] { lineNumber });
            } else {
                throw new Exception("Cannot go to Line in Monaco's Editor while Document is null.");
            }
        }

        /// <summary>
        /// Refreshes the Monaco editor.
        /// </summary>
        public void EditorRefresh() {
            if (this.Document != null) {
                this.Document.InvokeScript("Refresh");
            } else {
                throw new Exception("Cannot refresh Monaco's editor while the Document is null.");
            }
        }

        public void ShowMiniMap(bool shown)
        {
            if (this.Document != null) {
                this.Document.InvokeScript("SwitchMinimap", new object[] { shown});
            } else {
                throw new Exception("Cannot refresh Monaco's editor while the Document is null.");
            }
            MinimapEnabled = shown;
        }


        /// <summary>
        /// Updates Monaco Editor's Settings with it's Parameter Structure.
        /// </summary>
        /// <param name="settings"></param>
        public void UpdateSettings(MonacoSettings settings) {
            if (this.Document != null) {
                this.Document.InvokeScript("SwitchMinimap", new object[] { settings.MinimapEnabled });
                this.Document.InvokeScript("SwitchReadonly", new object[] { settings.ReadOnly });
                this.Document.InvokeScript("SwitchRenderWhitespace", new object[] { settings.RenderWhitespace });
                this.Document.InvokeScript("SwitchLinks", new object[] { settings.Links });
                this.Document.InvokeScript("SwitchLineHeight", new object[] { settings.LineHeight });
                this.Document.InvokeScript("SwitchFontSize", new object[] { settings.FontSize });
                this.Document.InvokeScript("SwitchFolding", new object[] { settings.Folding });
                this.Document.InvokeScript("SwitchAutoIndent", new object[] { settings.AutoIndent });
                this.Document.InvokeScript("SwitchFontFamily", new object[] { settings.FontFamily });
                this.Document.InvokeScript("SwitchFontLigatures", new object[] { settings.FontLigatures });
            } else {
                throw new Exception("Cannot change Monaco's settings while Document is null.");
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
            if (this.Document != null) {
                this.Document.InvokeScript("AddIntellisense", new object[] {
                    label,
                    type,
                    description,
                    insert
                });
            } else {
                throw new Exception("Cannot edit Monaco's Intellisense while Document is null.");
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
            if (this.Document != null) {
                this.Document.InvokeScript("ShowErr", new object[] { line, column, endLine, endColumn, message });
            } else {
                throw new Exception("Cannot show Syntax Error for Monaco while Document is null.");
            }
        }

        /// <summary>
        /// This is for Loading Settings that are from the Control's Initializing Settings
        /// </summary>
        protected virtual void OnMonacoLoad() {
            Application.DoEvents();
            Thread.Sleep(Int32.Parse("100"));
            this.BeginInvoke(new MethodInvoker(delegate () {
                UpdateSettings(new MonacoSettings() {
                    ReadOnly = ReadOnlyObj,
                    MinimapEnabled = MinimapEnabledObj,
                    RenderWhitespace = RenderWhitespaceObj,
                });
                //StartupFunction();
            }));
            foreach (List<dynamic> i in StartupFuncs)
            {
            }
            StartupFuncs = new List<dynamic>() { };
        }
    }
}
