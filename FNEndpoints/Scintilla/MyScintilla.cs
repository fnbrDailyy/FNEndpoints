using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FNEndpoints.Scintilla.Utils;
using ScintillaNET;
using System.Diagnostics;
using System.Windows.Input;
using System.IO;
using System.Net;

namespace FNEndpoints.Scintilla
{
    public partial class MyScintilla : UserControl
    {
        public static Form mainForm;
        public static ScintillaNET.Scintilla scintilla1;

        public MyScintilla()
        {

            mainForm = Form1.instance;

            InitializeComponent();
        }

        public void setText(string text)
        {
            scintilla1.ReadOnly = false;
            scintilla1.Text = text;
            scintilla1.ReadOnly = true;
        }

        private void MyScintilla_Load(object sender, EventArgs e)
        {
            scintilla1 = new ScintillaNET.Scintilla();
            
            scintilla1.ReadOnly = true;
            TextPanel.Controls.Add(scintilla1);

            scintilla1.Dock = System.Windows.Forms.DockStyle.Fill;
            scintilla1.TextChanged += (this.OnTextChanged);

            // INITIAL VIEW CONFIG
            scintilla1.WrapMode = WrapMode.None;
            scintilla1.IndentationGuides = IndentView.LookBoth;

            setContextMenu();

            // STYLING
            InitColors();
            InitSyntaxColoring();

            // NUMBER MARGIN
            InitNumberMargin();

            // BOOKMARK MARGIN
            InitBookmarkMargin();

            // CODE FOLDING MARGIN
            InitCodeFolding();

            // INIT HOTKEYS
            InitHotkeys();
        }

        private void InitColors()
        {
            scintilla1.SetSelectionBackColor(true, IntToColor(0xaaaaaa));
        }

        private void InitHotkeys()
        {
            // remove conflicting hotkeys from scintilla
            scintilla1.ClearCmdKey(Keys.Control | Keys.F);
            scintilla1.ClearCmdKey(Keys.Control | Keys.R);
            scintilla1.ClearCmdKey(Keys.Control | Keys.H);
            scintilla1.ClearCmdKey(Keys.Control | Keys.L);
            scintilla1.ClearCmdKey(Keys.Control | Keys.U);


            scintilla1.KeyDown += KeyDown;

            scintilla1.MouseDwellTime = 100;
            
            scintilla1.DwellStart += DwellStart;
            scintilla1.MouseClick += MouseClick;


        }

        private void KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                OpenSearch();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.Oemplus)
            {
                ZoomIn();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.OemMinus)
            {
                ZoomOut();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.D0)
            {
                ZoomDefault();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                CloseSearch();
                e.SuppressKeyPress = true;
            }
        }

        private void InitSyntaxColoring()
        {

            // Configure the default style
            scintilla1.StyleResetDefault();
            scintilla1.Styles[Style.Default].Font = "Consolas";
            scintilla1.Styles[Style.Default].Size = 10;
            scintilla1.Styles[Style.Default].BackColor = IntToColor(0x212121);
            scintilla1.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);

            scintilla1.StyleClearAll();

            scintilla1.Styles[Style.Json.PropertyName].ForeColor = IntToColor(0x00ff00);
            scintilla1.Styles[Style.Json.String].ForeColor = IntToColor(0x008000);
            scintilla1.Styles[Style.Json.StringEol].ForeColor = IntToColor(0x008000);
            scintilla1.Styles[Style.Json.Number].ForeColor = IntToColor(0xff0000);
            scintilla1.Styles[Style.Json.Operator].ForeColor = IntToColor(0x808080);
            scintilla1.Styles[Style.Json.BlockComment].ForeColor = IntToColor(0x40BF57);
            scintilla1.Styles[Style.Json.LineComment].ForeColor = IntToColor(0x40BF57);
            scintilla1.Styles[Style.Json.Uri].ForeColor = IntToColor(0x008000);
            scintilla1.Styles[Style.FoldDisplayText].Underline = true;

            scintilla1.CaretForeColor = IntToColor(0xffffff);

            scintilla1.Lexer = ScintillaNET.Lexer.Json;

            scintilla1.SetKeywords(4, "true false");

        }

        private void setContextMenu()
        {
            ContextMenu contextMenu = new ContextMenu();

            contextMenu.Popup += ContextMenu_Popup;
            scintilla1.ContextMenu = contextMenu;
        }
        private void ContextMenu_Popup(System.Object sender, System.EventArgs e)
        {
            scintilla1.ContextMenu.MenuItems.Clear();

            scintilla1.ContextMenu.MenuItems.Add(new MenuItem("Copy", (s, ea) => scintilla1.Copy()));
            scintilla1.ContextMenu.MenuItems.Add(new MenuItem("Select All", (s, ea) => scintilla1.SelectAll()));




            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            var cor = scintilla1.PointToClient(point);
            var pos = scintilla1.CharPositionFromPoint(cor.X, cor.Y);

            int startPos = ValueStartPosition(pos);
            int endPos = ValueEndPosition(pos);

            string text = scintilla1.GetTextRange(startPos, endPos - startPos);

            if ((text.StartsWith("http://") || text.StartsWith("https://")))
            {
                scintilla1.ContextMenu.MenuItems.Add("-");
                scintilla1.ContextMenu.MenuItems.Add(new MenuItem("Open in Browser", (s, ea) => Process.Start(text)));
                if (text.EndsWith(".jpg") || text.EndsWith(".png"))
                {
                    scintilla1.ContextMenu.MenuItems.Add(new MenuItem("Open Image in new Window", (s, ea) =>
                    {

                    }));
                    scintilla1.ContextMenu.MenuItems.Add(new MenuItem("Save Image", (s, ea) =>
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.RestoreDirectory = true;
                        saveFileDialog1.Filter = "Image Files(*" + text.Split('.').Last() + ")|*." + text.Split('.').Last() + "|All files (*.*)|*.*";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            using(var webClient = new WebClient())
                            {
                                webClient.DownloadFile(text, saveFileDialog1.FileName);
                            }
                        }
                    }));
                }
            }
        }

        private void DwellStart(object sender, DwellEventArgs e)
        {
            int startPos = ValueStartPosition(e.Position);
            int endPos = ValueEndPosition(e.Position);
            string text = scintilla1.GetTextRange(startPos, endPos - startPos);
            if (text.StartsWith("http://") || text.StartsWith("https://"))
            {
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(scintilla1, "STRG+Click to open");
            }
        }
        private void MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            var cor = scintilla1.PointToClient(point);
            var pos = scintilla1.CharPositionFromPoint(cor.X, cor.Y);

            int startPos = ValueStartPosition(pos);
            int endPos = ValueEndPosition(pos);

            string text = scintilla1.GetTextRange(startPos, endPos - startPos);

            if (text.StartsWith("http://") || text.StartsWith("https://"))
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (ModifierKeys.HasFlag(Keys.Control))
                    {
                        Process.Start(text);
                    }
                }
            }
        }

        private int ValueStartPosition(int position)
        {
            bool found = false;
            int currentposition = position;
            while(!found)
            {
                if(currentposition < 0)
                {
                    found = true;
                } else
                {
                    if (scintilla1.GetCharAt(currentposition) == '"')
                    {
                        found = true;
                        currentposition += 1;
                    }
                    else
                    {
                        currentposition -= 1;
                    }
                }
            }
            return currentposition;
        }

        private int ValueEndPosition(int position)
        {
            bool found = false;
            int currentposition = position;
            while (!found)
            {
                if (currentposition > scintilla1.TextLength - 1)
                {
                    found = true;
                }
                else
                {
                    if (scintilla1.GetCharAt(currentposition) == '"')
                    {
                        found = true;
                    }
                    else
                    {
                        currentposition += 1;
                    }
                }
            }
            return currentposition;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {

        }


        #region Numbers, Bookmarks, Code Folding

        /// <summary>
        /// the background color of the text area
        /// </summary>
        private const int BACK_COLOR = 0x272727;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0xB7B7B7;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        /// <summary>
        /// change this to whatever margin you want the bookmarks/breakpoints to show in
        /// </summary>
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 2;

        /// <summary>
        /// change this to whatever margin you want the code folding tree (+/-) to show in
        /// </summary>
        private const int FOLDING_MARGIN = 3;

        /// <summary>
        /// set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
        /// </summary>
        private const bool CODEFOLDING_CIRCULAR = false;

        private void InitNumberMargin()
        {

            scintilla1.Styles[ScintillaNET.Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            scintilla1.Styles[ScintillaNET.Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            scintilla1.Styles[ScintillaNET.Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            scintilla1.Styles[ScintillaNET.Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            var nums = scintilla1.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = ScintillaNET.MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            scintilla1.MarginClick += scintilla1_MarginClick;
        }

        private void InitBookmarkMargin()
        {

            //scintilla1.SetFoldMarginColor(true, IntToColor(BACK_COLOR));

            var margin = scintilla1.Margins[BOOKMARK_MARGIN];
            margin.Width = 20;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;

            var marker = scintilla1.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(IntToColor(0xFF003B));
            marker.SetForeColor(IntToColor(0x000000));
            marker.SetAlpha(100);

        }

        private void InitCodeFolding()
        {

            scintilla1.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
            scintilla1.SetFoldMarginHighlightColor(true, IntToColor(BACK_COLOR));

            // Enable code folding
            scintilla1.SetProperty("fold", "1");
            scintilla1.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            scintilla1.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            scintilla1.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            scintilla1.Margins[FOLDING_MARGIN].Sensitive = true;
            scintilla1.Margins[FOLDING_MARGIN].Width = 15;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                scintilla1.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
                scintilla1.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            scintilla1.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            scintilla1.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            scintilla1.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            scintilla1.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla1.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            scintilla1.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla1.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            scintilla1.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }

        private void scintilla1_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = scintilla1.Lines[scintilla1.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(BOOKMARK_MARKER);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(BOOKMARK_MARKER);
                }
            }
        }

        #endregion
        #region Indent / Outdent

        private void Indent()
        {
            // we use this hack to send "Shift+Tab" to scintilla, since there is no known API to indent,
            // although the indentation function exists. Pressing TAB with the editor focused confirms this.
            GenerateKeystrokes("{TAB}");
        }

        private void Outdent()
        {
            // we use this hack to send "Shift+Tab" to scintilla, since there is no known API to outdent,
            // although the indentation function exists. Pressing Shift+Tab with the editor focused confirms this.
            GenerateKeystrokes("+{TAB}");
        }

        private void GenerateKeystrokes(string keys)
        {
            HotKeyManager.Enable = false;
            scintilla1.Focus();
            SendKeys.Send(keys);
            HotKeyManager.Enable = true;
        }

        #endregion

        #region Zoom

        private void ZoomIn()
        {
            scintilla1.ZoomIn();
        }

        private void ZoomOut()
        {
            scintilla1.ZoomOut();
        }

        private void ZoomDefault()
        {
            scintilla1.Zoom = 0;
        }


        #endregion

        #region Quick Search Bar

        bool SearchIsOpen = false;

        private void OpenSearch()
        {

            SearchManager.SearchBox = TxtSearch;
            SearchManager.TextArea = scintilla1;

            if (!SearchIsOpen)
            {
                SearchIsOpen = true;
                InvokeIfNeeded(delegate () {
                    PanelSearch.Visible = true;
                    TxtSearch.Text = SearchManager.LastSearch;
                    TxtSearch.Focus();
                    TxtSearch.SelectAll();
                });
            }
            else
            {
                InvokeIfNeeded(delegate () {
                    TxtSearch.Focus();
                    TxtSearch.SelectAll();
                });
            }
        }
        private void CloseSearch()
        {
            if (SearchIsOpen)
            {
                SearchIsOpen = false;
                InvokeIfNeeded(delegate () {
                    PanelSearch.Visible = false;
                    //CurBrowser.GetBrowser().StopFinding(true);
                });
            }
        }

        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            CloseSearch();
        }

        private void BtnPrevSearch_Click(object sender, EventArgs e)
        {
            SearchManager.Find(false, false);
        }
        private void BtnNextSearch_Click(object sender, EventArgs e)
        {
            SearchManager.Find(true, false);
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchManager.Find(true, true);
        }

        private void TxtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (HotKeyManager.IsHotkey(e, Keys.Enter))
            {
                SearchManager.Find(true, false);
            }
            if (HotKeyManager.IsHotkey(e, Keys.Enter, true) || HotKeyManager.IsHotkey(e, Keys.Enter, false, true))
            {
                SearchManager.Find(false, false);
            }
        }

        #endregion

        #region Utils

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }


        public void InvokeIfNeeded(Action action)
        {
            if (mainForm.InvokeRequired)
            {
                mainForm.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }
        #endregion
    }
}
