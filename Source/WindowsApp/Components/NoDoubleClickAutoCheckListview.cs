﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoR.Configurator.Components
{
    public class NoDoubleClickAutoCheckListview : ListView
    {
        private bool checkFromDoubleClick = false;

        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            if (checkFromDoubleClick)
            {
                ice.NewValue = ice.CurrentValue;
                checkFromDoubleClick = false;
            }
            else
            {
                base.OnItemCheck(ice);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Is this a double-click?
            if ((e.Button == MouseButtons.Left) && (e.Clicks > 1))
            {
                checkFromDoubleClick = true;
            }
            base.OnMouseDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            checkFromDoubleClick = false;
            base.OnKeyDown(e);
        }
    }
}
