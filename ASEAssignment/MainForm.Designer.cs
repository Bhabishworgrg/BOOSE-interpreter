namespace ASEAssignment
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtbox_input = new TextBox();
            btn_run = new Button();
            picbox_output = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picbox_output).BeginInit();
            SuspendLayout();
            // 
            // txtbox_input
            // 
            txtbox_input.Location = new Point(23, 69);
            txtbox_input.Multiline = true;
            txtbox_input.Name = "txtbox_input";
            txtbox_input.Size = new Size(579, 610);
            txtbox_input.TabIndex = 0;
            // 
            // btn_run
            // 
            btn_run.Location = new Point(23, 711);
            btn_run.Name = "btn_run";
            btn_run.Size = new Size(112, 34);
            btn_run.TabIndex = 1;
            btn_run.Text = "Run";
            btn_run.UseVisualStyleBackColor = true;
            btn_run.Click += btn_run_Click;
            // 
            // picbox_output
            // 
            picbox_output.BorderStyle = BorderStyle.Fixed3D;
            picbox_output.Location = new Point(634, 69);
            picbox_output.Name = "picbox_output";
            picbox_output.Size = new Size(579, 610);
            picbox_output.TabIndex = 2;
            picbox_output.TabStop = false;
            picbox_output.Paint += picbox_output_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 797);
            Controls.Add(picbox_output);
            Controls.Add(btn_run);
            Controls.Add(txtbox_input);
            MaximizeBox = false;
            MaximumSize = new Size(1258, 853);
            MinimumSize = new Size(1258, 853);
            Name = "MainForm";
            Text = "ASE Assignment App";
            ((System.ComponentModel.ISupportInitialize)picbox_output).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbox_input;
        private Button btn_run;
        private PictureBox picbox_output;
    }
}
