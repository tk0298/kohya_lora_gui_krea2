using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Kohya_lora_trainer
{
    /// <summary>
    /// 簡易的なダークテーマの適用/設定保存を行う。
    ///
    /// 制限事項(WinFormsの標準コントロールの限界によるもの):
    /// - GroupBoxの枠線、ComboBoxのドロップダウン矢印、NumericUpDownのスピンボタン、
    ///   チェックボックス/ラジオボタンのチェック記号自体は、OSのビジュアルスタイルで
    ///   描画されるため、明るい色のまま残る場合があります。
    /// - スクロールバーの配色はOS設定に依存し、変更できません。
    /// 完全なダークテーマにはオーナードローによる全面的な作り直しが必要なため、
    /// ここでは「実用上見やすくなる」ことを目標とした簡易実装としています。
    /// </summary>
    internal static class ThemeManager
    {
        private const string RegistryKey = @"HKEY_CURRENT_USER\Software\kohya_lora_gui";
        private const string RegistryValueName = "DarkMode";

        // パレット
        internal static readonly Color FormBack = Color.FromArgb(30, 30, 30);
        internal static readonly Color ControlBack = Color.FromArgb(45, 45, 48);
        internal static readonly Color InputBack = Color.FromArgb(37, 37, 38);
        internal static readonly Color Foreground = Color.FromArgb(220, 220, 220);
        internal static readonly Color BorderColor = Color.FromArgb(70, 70, 70);
        internal static readonly Color AccentBack = Color.FromArgb(0, 90, 158);

        /// <summary>
        /// 「入力が正常な状態」を示す文字色。検証ロジックがCcolor.Blackを直接指定していた箇所を
        /// これに置き換えることで、ダークテーマ時に黒文字が背景に埋もれて見えなくなるのを防ぐ。
        /// </summary>
        internal static Color ValidForeColor => IsDarkMode ? Foreground : Color.Black;

        private static bool? _cached;

        internal static bool IsDarkMode
        {
            get
            {
                if (_cached.HasValue)
                {
                    return _cached.Value;
                }
                int value = (int)(Registry.GetValue(RegistryKey, RegistryValueName, 0) ?? 0);
                _cached = value != 0;
                return _cached.Value;
            }
            set
            {
                _cached = value;
                Registry.SetValue(RegistryKey, RegistryValueName, value ? 1 : 0);
            }
        }

        /// <summary>
        /// 各FormのコンストラクタからInitializeComponent()の直後に呼び出す。
        /// ダークテーマが有効な場合のみ再帰的に配色を適用する。
        /// </summary>
        internal static void ApplyIfEnabled(Control root)
        {
            if (!IsDarkMode)
            {
                return;
            }
            Apply(root);
        }

        private static void Apply(Control control)
        {
            switch (control)
            {
                case Form form:
                    form.BackColor = FormBack;
                    form.ForeColor = Foreground;
                    break;

                case MenuStrip menuStrip:
                    menuStrip.BackColor = ControlBack;
                    menuStrip.ForeColor = Foreground;
                    menuStrip.Renderer = new ToolStripProfessionalRenderer(new DarkToolStripColorTable());
                    break;

                case ToolStrip toolStrip:
                    toolStrip.BackColor = ControlBack;
                    toolStrip.ForeColor = Foreground;
                    toolStrip.Renderer = new ToolStripProfessionalRenderer(new DarkToolStripColorTable());
                    break;

                case TabControl tabControl:
                    tabControl.BackColor = FormBack;
                    tabControl.ForeColor = Foreground;
                    // タブ見出し自体はOS描画のため、オーナードローに切り替えて手動で塗る
                    tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
                    tabControl.DrawItem -= TabControl_DrawItem;
                    tabControl.DrawItem += TabControl_DrawItem;
                    break;

                case TextBoxBase textBox:
                    textBox.BackColor = InputBack;
                    textBox.ForeColor = Foreground;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    break;

                case ComboBox comboBox:
                    comboBox.BackColor = InputBack;
                    comboBox.ForeColor = Foreground;
                    comboBox.FlatStyle = FlatStyle.Flat;
                    break;

                case NumericUpDown numericUpDown:
                    numericUpDown.BackColor = InputBack;
                    numericUpDown.ForeColor = Foreground;
                    numericUpDown.BorderStyle = BorderStyle.FixedSingle;
                    break;

                case ListBox listBox:
                    listBox.BackColor = InputBack;
                    listBox.ForeColor = Foreground;
                    break;

                case Button button:
                    button.BackColor = ControlBack;
                    button.ForeColor = Foreground;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = BorderColor;
                    break;

                case CheckBox checkBox:
                    checkBox.ForeColor = Foreground;
                    checkBox.BackColor = Color.Transparent;
                    break;

                case RadioButton radioButton:
                    radioButton.ForeColor = Foreground;
                    radioButton.BackColor = Color.Transparent;
                    break;

                case GroupBox groupBox:
                    groupBox.ForeColor = Foreground;
                    groupBox.BackColor = Color.Transparent;
                    break;

                case Label label:
                    label.ForeColor = Foreground;
                    label.BackColor = Color.Transparent;
                    break;

                case TabPage tabPage:
                    tabPage.BackColor = FormBack;
                    tabPage.ForeColor = Foreground;
                    break;

                case Panel panel:
                    panel.BackColor = FormBack;
                    panel.ForeColor = Foreground;
                    break;

                default:
                    // ListView、DataGridView等、未対応のコントロールが将来追加された場合は
                    // ここに追記する。最低限ForeColor/BackColorだけは試みる。
                    try
                    {
                        control.BackColor = ControlBack;
                        control.ForeColor = Foreground;
                    }
                    catch
                    {
                        // BackColor/ForeColorをサポートしないコントロールは無視
                    }
                    break;
            }

            foreach (Control child in control.Controls)
            {
                Apply(child);
            }
        }

        private static void TabControl_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (sender is not TabControl tabControl)
            {
                return;
            }

            TabPage page = tabControl.TabPages[e.Index];
            bool selected = e.Index == tabControl.SelectedIndex;

            using (SolidBrush backBrush = new SolidBrush(selected ? AccentBack : ControlBack))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            TextRenderer.DrawText(
                e.Graphics,
                page.Text,
                tabControl.Font,
                e.Bounds,
                Foreground,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private sealed class DarkToolStripColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => AccentBack;
            public override Color MenuItemBorder => BorderColor;
            public override Color MenuBorder => BorderColor;
            public override Color ToolStripDropDownBackground => ControlBack;
            public override Color ImageMarginGradientBegin => ControlBack;
            public override Color ImageMarginGradientMiddle => ControlBack;
            public override Color ImageMarginGradientEnd => ControlBack;
            public override Color MenuItemSelectedGradientBegin => AccentBack;
            public override Color MenuItemSelectedGradientEnd => AccentBack;
            public override Color MenuItemPressedGradientBegin => AccentBack;
            public override Color MenuItemPressedGradientEnd => AccentBack;
            public override Color ToolStripBorder => BorderColor;
        }
    }
}
