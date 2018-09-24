using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoR.Configurator.Utils
{
    public static class FormUtils
    {
        public static DialogResult InputBox(string title, string promptText, ref string value, bool isPassword = false)
        {
            using (var form = new Form())
            {
                using (var label = new Label())
                {
                    using (var textBox = new TextBox())
                    {
                        var buttonOk = new Button();
                        var buttonCancel = new Button();

                        form.Text = title;
                        label.Text = promptText;
                        textBox.Text = value;
                        if (isPassword)
                            textBox.PasswordChar = '*';
                        buttonOk.Text = "OK";
                        buttonCancel.Text = "Cancel";
                        buttonOk.DialogResult = DialogResult.OK;
                        buttonCancel.DialogResult = DialogResult.Cancel;

                        label.SetBounds(9, 20, 372, 13);
                        textBox.SetBounds(12, 36, 372, 20);
                        buttonOk.SetBounds(228, 72, 75, 23);
                        buttonCancel.SetBounds(309, 72, 75, 23);

                        label.AutoSize = true;
                        textBox.Anchor |= AnchorStyles.Right;
                        buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                        form.ClientSize = new Size(396, 107);
                        form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                        form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
                        form.FormBorderStyle = FormBorderStyle.FixedDialog;
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.MinimizeBox = false;
                        form.MaximizeBox = false;
                        form.AcceptButton = buttonOk;
                        form.CancelButton = buttonCancel;

                        var dialogResult = form.ShowDialog();
                        value = textBox.Text;
                        return dialogResult;
                    }
                }
            }
        }
    }
}
