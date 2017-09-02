﻿using System;
using System.Windows.Forms;

namespace ProcessingWindow
{
    public partial class ProcessingForm : Form
    {

        #region PROPERTIES

        public string Message
        {
            set { labelMessage.Text = value; }
        }

        public int ProgressValue
        {
            set { progressBar1.Value = value; }
        }

        #endregion

        #region METHODS

        public ProcessingForm()
        {
            InitializeComponent();
            this.MaximumSize = this.MinimumSize = this.Size;
        }

        #endregion

        #region EVENTS
        public event EventHandler<EventArgs> Canceled;

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Create a copy of the event to work with
            EventHandler<EventArgs> ea = Canceled;
            /* If there are no subscribers, eh will be null so we need to check
             * to avoid a NullReferenceException. */
            if (ea != null)
                ea(this, e);
        }

        #endregion

    }
}
