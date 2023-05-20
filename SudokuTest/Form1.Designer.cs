namespace SudokuTest
{
    partial class Form1
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
            this.checkWinButton = new System.Windows.Forms.Button();
            this.saveGameBtn = new System.Windows.Forms.Button();
            this.loadGameBtn = new System.Windows.Forms.Button();
            this.solveBtn = new System.Windows.Forms.Button();
            this.newGameBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkWinButton
            // 
            this.checkWinButton.Location = new System.Drawing.Point(657, 516);
            this.checkWinButton.Name = "checkWinButton";
            this.checkWinButton.Size = new System.Drawing.Size(112, 23);
            this.checkWinButton.TabIndex = 0;
            this.checkWinButton.Text = "Check Result";
            this.checkWinButton.UseVisualStyleBackColor = true;
            this.checkWinButton.Click += new System.EventHandler(this.checkWinButton_Click);
            // 
            // saveGameBtn
            // 
            this.saveGameBtn.Location = new System.Drawing.Point(657, 51);
            this.saveGameBtn.Name = "saveGameBtn";
            this.saveGameBtn.Size = new System.Drawing.Size(112, 23);
            this.saveGameBtn.TabIndex = 1;
            this.saveGameBtn.Text = "Save Game";
            this.saveGameBtn.UseVisualStyleBackColor = true;
            this.saveGameBtn.Click += new System.EventHandler(this.saveGameBtn_Click);
            // 
            // loadGameBtn
            // 
            this.loadGameBtn.Location = new System.Drawing.Point(657, 80);
            this.loadGameBtn.Name = "loadGameBtn";
            this.loadGameBtn.Size = new System.Drawing.Size(112, 23);
            this.loadGameBtn.TabIndex = 2;
            this.loadGameBtn.Text = "Load Last Game";
            this.loadGameBtn.UseVisualStyleBackColor = true;
            this.loadGameBtn.Click += new System.EventHandler(this.loadGameBtn_Click);
            // 
            // solveBtn
            // 
            this.solveBtn.Location = new System.Drawing.Point(657, 274);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(112, 23);
            this.solveBtn.TabIndex = 3;
            this.solveBtn.Text = "Solve";
            this.solveBtn.UseVisualStyleBackColor = true;
            this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
            // 
            // newGameBtn
            // 
            this.newGameBtn.Location = new System.Drawing.Point(657, 22);
            this.newGameBtn.Name = "newGameBtn";
            this.newGameBtn.Size = new System.Drawing.Size(112, 23);
            this.newGameBtn.TabIndex = 4;
            this.newGameBtn.Text = "New Game";
            this.newGameBtn.UseVisualStyleBackColor = true;
            this.newGameBtn.Click += new System.EventHandler(this.newGameBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 563);
            this.Controls.Add(this.newGameBtn);
            this.Controls.Add(this.solveBtn);
            this.Controls.Add(this.loadGameBtn);
            this.Controls.Add(this.saveGameBtn);
            this.Controls.Add(this.checkWinButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button checkWinButton;
        private System.Windows.Forms.Button saveGameBtn;
        private System.Windows.Forms.Button loadGameBtn;
        private System.Windows.Forms.Button solveBtn;
        private System.Windows.Forms.Button newGameBtn;
    }
}

