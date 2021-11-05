
namespace WindowsFormsApp1
{
    partial class Laboratory_Work_5
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.controlWindow = new OpenTK.GLControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // controlWindow
            // 
            this.controlWindow.BackColor = System.Drawing.Color.Black;
            this.controlWindow.Location = new System.Drawing.Point(2, 0);
            this.controlWindow.Margin = new System.Windows.Forms.Padding(12);
            this.controlWindow.Name = "controlWindow";
            this.controlWindow.Size = new System.Drawing.Size(1200, 1154);
            this.controlWindow.TabIndex = 0;
            this.controlWindow.VSync = false;
            this.controlWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.controlWindow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.controlWindow_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 10;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Laboratory_Work_5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1174, 1129);
            this.Controls.Add(this.controlWindow);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Laboratory_Work_5";
            this.Text = "Laboratory_Work_5";
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl controlWindow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
    }
}

