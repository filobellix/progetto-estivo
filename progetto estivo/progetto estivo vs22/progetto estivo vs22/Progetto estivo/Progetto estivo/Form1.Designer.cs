namespace Progetto_estivo
{
    partial class Form1
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
            textBoxTemp = new TextBox();
            labelTemp = new Label();
            labelHum = new Label();
            textBoxHum = new TextBox();
            labelRedSpento = new Label();
            labelRosso = new Label();
            textBoxRed = new TextBox();
            labelGreenSpento = new Label();
            labelVerde = new Label();
            textBoxGreen = new TextBox();
            labelRedAcceso = new Label();
            labelGreenAcceso = new Label();
            buttonRED = new Button();
            buttonGREEN = new Button();
            textBoxJSON = new TextBox();
            labelJSON = new Label();
            buttonJSON = new Button();
            SuspendLayout();
            // 
            // textBoxTemp
            // 
            textBoxTemp.Location = new Point(91, 53);
            textBoxTemp.Multiline = true;
            textBoxTemp.Name = "textBoxTemp";
            textBoxTemp.Size = new Size(129, 39);
            textBoxTemp.TabIndex = 0;
            textBoxTemp.TextChanged += textBoxTemp_TextChanged;
            // 
            // labelTemp
            // 
            labelTemp.AutoSize = true;
            labelTemp.Location = new Point(110, 27);
            labelTemp.Name = "labelTemp";
            labelTemp.Size = new Size(93, 20);
            labelTemp.TabIndex = 1;
            labelTemp.Text = "Temperatura";
            // 
            // labelHum
            // 
            labelHum.AutoSize = true;
            labelHum.Location = new Point(619, 27);
            labelHum.Name = "labelHum";
            labelHum.Size = new Size(62, 20);
            labelHum.TabIndex = 4;
            labelHum.Text = "Umidità";
            // 
            // textBoxHum
            // 
            textBoxHum.Location = new Point(582, 51);
            textBoxHum.Multiline = true;
            textBoxHum.Name = "textBoxHum";
            textBoxHum.Size = new Size(129, 39);
            textBoxHum.TabIndex = 3;
            // 
            // labelRedSpento
            // 
            labelRedSpento.AutoSize = true;
            labelRedSpento.Location = new Point(240, 389);
            labelRedSpento.Name = "labelRedSpento";
            labelRedSpento.Size = new Size(56, 20);
            labelRedSpento.TabIndex = 8;
            labelRedSpento.Text = "Spento";
            // 
            // labelRosso
            // 
            labelRosso.AutoSize = true;
            labelRosso.Location = new Point(127, 344);
            labelRosso.Name = "labelRosso";
            labelRosso.Size = new Size(76, 20);
            labelRosso.TabIndex = 7;
            labelRosso.Text = "Led Rosso";
            // 
            // textBoxRed
            // 
            textBoxRed.Location = new Point(91, 387);
            textBoxRed.Multiline = true;
            textBoxRed.Name = "textBoxRed";
            textBoxRed.Size = new Size(129, 39);
            textBoxRed.TabIndex = 6;
            // 
            // labelGreenSpento
            // 
            labelGreenSpento.AutoSize = true;
            labelGreenSpento.Location = new Point(716, 387);
            labelGreenSpento.Name = "labelGreenSpento";
            labelGreenSpento.Size = new Size(56, 20);
            labelGreenSpento.TabIndex = 11;
            labelGreenSpento.Text = "Spento";
            // 
            // labelVerde
            // 
            labelVerde.AutoSize = true;
            labelVerde.Location = new Point(587, 344);
            labelVerde.Name = "labelVerde";
            labelVerde.Size = new Size(75, 20);
            labelVerde.TabIndex = 10;
            labelVerde.Text = "Led Verde";
            // 
            // textBoxGreen
            // 
            textBoxGreen.Location = new Point(565, 385);
            textBoxGreen.Multiline = true;
            textBoxGreen.Name = "textBoxGreen";
            textBoxGreen.Size = new Size(129, 39);
            textBoxGreen.TabIndex = 9;
            // 
            // labelRedAcceso
            // 
            labelRedAcceso.AutoSize = true;
            labelRedAcceso.Location = new Point(11, 389);
            labelRedAcceso.Name = "labelRedAcceso";
            labelRedAcceso.Size = new Size(56, 20);
            labelRedAcceso.TabIndex = 12;
            labelRedAcceso.Text = "Acceso";
            // 
            // labelGreenAcceso
            // 
            labelGreenAcceso.AutoSize = true;
            labelGreenAcceso.Location = new Point(484, 389);
            labelGreenAcceso.Name = "labelGreenAcceso";
            labelGreenAcceso.Size = new Size(56, 20);
            labelGreenAcceso.TabIndex = 13;
            labelGreenAcceso.Text = "Acceso";
            // 
            // buttonRED
            // 
            buttonRED.Location = new Point(110, 463);
            buttonRED.Name = "buttonRED";
            buttonRED.Size = new Size(94, 29);
            buttonRED.TabIndex = 14;
            buttonRED.Text = "ON/OFF";
            buttonRED.UseVisualStyleBackColor = true;
            buttonRED.Click += buttonRED_Click;
            // 
            // buttonGREEN
            // 
            buttonGREEN.Location = new Point(587, 455);
            buttonGREEN.Name = "buttonGREEN";
            buttonGREEN.Size = new Size(94, 29);
            buttonGREEN.TabIndex = 15;
            buttonGREEN.Text = "ON/OFF";
            buttonGREEN.UseVisualStyleBackColor = true;
            buttonGREEN.Click += buttonGREEN_Click;
            // 
            // textBoxJSON
            // 
            textBoxJSON.Location = new Point(290, 134);
            textBoxJSON.Multiline = true;
            textBoxJSON.Name = "textBoxJSON";
            textBoxJSON.Size = new Size(234, 157);
            textBoxJSON.TabIndex = 16;
            // 
            // labelJSON
            // 
            labelJSON.AutoSize = true;
            labelJSON.Location = new Point(393, 111);
            labelJSON.Name = "labelJSON";
            labelJSON.Size = new Size(44, 20);
            labelJSON.TabIndex = 17;
            labelJSON.Text = "JSON";
            // 
            // buttonJSON
            // 
            buttonJSON.Location = new Point(364, 297);
            buttonJSON.Name = "buttonJSON";
            buttonJSON.Size = new Size(119, 29);
            buttonJSON.TabIndex = 18;
            buttonJSON.Text = "Genera JSON";
            buttonJSON.UseVisualStyleBackColor = true;
            buttonJSON.Click += buttonJSON_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 539);
            Controls.Add(buttonJSON);
            Controls.Add(labelJSON);
            Controls.Add(textBoxJSON);
            Controls.Add(buttonGREEN);
            Controls.Add(buttonRED);
            Controls.Add(labelGreenAcceso);
            Controls.Add(labelRedAcceso);
            Controls.Add(labelGreenSpento);
            Controls.Add(labelVerde);
            Controls.Add(textBoxGreen);
            Controls.Add(labelRedSpento);
            Controls.Add(labelRosso);
            Controls.Add(textBoxRed);
            Controls.Add(labelHum);
            Controls.Add(textBoxHum);
            Controls.Add(labelTemp);
            Controls.Add(textBoxTemp);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTemp;
        private Label labelTemp;
        private Label labelHum;
        private TextBox textBoxHum;
        private Label labelRedSpento;
        private Label labelRosso;
        private TextBox textBoxRed;
        private Label labelGreenSpento;
        private Label labelVerde;
        private TextBox textBoxGreen;
        private Label labelRedAcceso;
        private Label labelGreenAcceso;
        private Button buttonRED;
        private Button buttonGREEN;
        private TextBox textBoxJSON;
        private Label labelJSON;
        private Button buttonJSON;
    }
}