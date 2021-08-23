namespace Furniture
{
    partial class AdminS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProducer = new System.Windows.Forms.TextBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.btnMaterial = new System.Windows.Forms.Button();
            this.btnProducer = new System.Windows.Forms.Button();
            this.materialErr = new System.Windows.Forms.Label();
            this.producerErr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(95, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 45;
            this.label2.Text = "Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(28, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 46;
            this.label7.Text = "Material";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(20, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Producer";
            // 
            // txtProducer
            // 
            this.txtProducer.Location = new System.Drawing.Point(99, 125);
            this.txtProducer.Name = "txtProducer";
            this.txtProducer.Size = new System.Drawing.Size(100, 20);
            this.txtProducer.TabIndex = 49;
            this.txtProducer.UseSystemPasswordChar = true;
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(99, 62);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(100, 20);
            this.txtMaterial.TabIndex = 48;
            // 
            // btnMaterial
            // 
            this.btnMaterial.Location = new System.Drawing.Point(205, 60);
            this.btnMaterial.Name = "btnMaterial";
            this.btnMaterial.Size = new System.Drawing.Size(75, 23);
            this.btnMaterial.TabIndex = 50;
            this.btnMaterial.Text = "Add";
            this.btnMaterial.UseVisualStyleBackColor = true;
            this.btnMaterial.Click += new System.EventHandler(this.BtnMaterial_Click);
            // 
            // btnProducer
            // 
            this.btnProducer.Location = new System.Drawing.Point(205, 123);
            this.btnProducer.Name = "btnProducer";
            this.btnProducer.Size = new System.Drawing.Size(75, 23);
            this.btnProducer.TabIndex = 51;
            this.btnProducer.Text = "Add";
            this.btnProducer.UseVisualStyleBackColor = true;
            this.btnProducer.Click += new System.EventHandler(this.BtnProducer_Click);
            // 
            // materialErr
            // 
            this.materialErr.AutoSize = true;
            this.materialErr.ForeColor = System.Drawing.Color.Red;
            this.materialErr.Location = new System.Drawing.Point(96, 85);
            this.materialErr.Name = "materialErr";
            this.materialErr.Size = new System.Drawing.Size(0, 13);
            this.materialErr.TabIndex = 52;
            // 
            // producerErr
            // 
            this.producerErr.AutoSize = true;
            this.producerErr.ForeColor = System.Drawing.Color.Red;
            this.producerErr.Location = new System.Drawing.Point(96, 148);
            this.producerErr.Name = "producerErr";
            this.producerErr.Size = new System.Drawing.Size(0, 13);
            this.producerErr.TabIndex = 53;
            // 
            // AdminS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 205);
            this.Controls.Add(this.producerErr);
            this.Controls.Add(this.materialErr);
            this.Controls.Add(this.btnProducer);
            this.Controls.Add(this.btnMaterial);
            this.Controls.Add(this.txtProducer);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Name = "AdminS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProducer;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Button btnMaterial;
        private System.Windows.Forms.Button btnProducer;
        private System.Windows.Forms.Label materialErr;
        private System.Windows.Forms.Label producerErr;
    }
}