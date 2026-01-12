
namespace AsychronousPrograming
{
    partial class Form1
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
            this.hello = new System.Windows.Forms.Button();
            this.Task = new System.Windows.Forms.Button();
            this.async = new System.Windows.Forms.Button();
            this.async_result = new System.Windows.Forms.Button();
            this.sync = new System.Windows.Forms.Button();
            this.thread = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hello
            // 
            this.hello.Location = new System.Drawing.Point(12, 126);
            this.hello.Name = "hello";
            this.hello.Size = new System.Drawing.Size(92, 30);
            this.hello.TabIndex = 0;
            this.hello.Text = "hello";
            this.hello.UseVisualStyleBackColor = true;
            this.hello.Click += new System.EventHandler(this.button1_Click);
            // 
            // Task
            // 
            this.Task.Location = new System.Drawing.Point(363, 126);
            this.Task.Name = "Task";
            this.Task.Size = new System.Drawing.Size(75, 23);
            this.Task.TabIndex = 3;
            this.Task.Text = "Task";
            this.Task.UseVisualStyleBackColor = true;
            // 
            // async
            // 
            this.async.Location = new System.Drawing.Point(476, 145);
            this.async.Name = "async";
            this.async.Size = new System.Drawing.Size(75, 23);
            this.async.TabIndex = 4;
            this.async.Text = "async";
            this.async.UseVisualStyleBackColor = true;
            // 
            // async_result
            // 
            this.async_result.Location = new System.Drawing.Point(648, 130);
            this.async_result.Name = "async_result";
            this.async_result.Size = new System.Drawing.Size(140, 52);
            this.async_result.TabIndex = 5;
            this.async_result.Text = "async_result";
            this.async_result.UseVisualStyleBackColor = true;
            // 
            // sync
            // 
            this.sync.Location = new System.Drawing.Point(130, 130);
            this.sync.Name = "sync";
            this.sync.Size = new System.Drawing.Size(75, 52);
            this.sync.TabIndex = 6;
            this.sync.Text = "sync";
            this.sync.UseVisualStyleBackColor = true;
            // 
            // thread
            // 
            this.thread.Location = new System.Drawing.Point(251, 133);
            this.thread.Name = "thread";
            this.thread.Size = new System.Drawing.Size(75, 23);
            this.thread.TabIndex = 7;
            this.thread.Text = "thread";
            this.thread.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.thread);
            this.Controls.Add(this.sync);
            this.Controls.Add(this.async_result);
            this.Controls.Add(this.async);
            this.Controls.Add(this.Task);
            this.Controls.Add(this.hello);
            this.Name = "Form1";
            this.Text = "A";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button hello;
        private System.Windows.Forms.Button Task;
        private System.Windows.Forms.Button async;
        private System.Windows.Forms.Button async_result;
        private System.Windows.Forms.Button sync;
        private System.Windows.Forms.Button thread;
    }
}

