
namespace AsynchronousProgramming1
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
            this.button2 = new System.Windows.Forms.Button();
            this.sync = new System.Windows.Forms.Button();
            this.thread = new System.Windows.Forms.Button();
            this.Task = new System.Windows.Forms.Button();
            this.async = new System.Windows.Forms.Button();
            this.async_result = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hello
            // 
            this.hello.Location = new System.Drawing.Point(25, 133);
            this.hello.Name = "hello";
            this.hello.Size = new System.Drawing.Size(75, 23);
            this.hello.TabIndex = 0;
            this.hello.Text = "hello";
            this.hello.UseVisualStyleBackColor = true;
            this.hello.Click += new System.EventHandler(this.hello_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(560, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 9);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // sync
            // 
            this.sync.Location = new System.Drawing.Point(128, 133);
            this.sync.Name = "sync";
            this.sync.Size = new System.Drawing.Size(75, 23);
            this.sync.TabIndex = 2;
            this.sync.Text = "sync";
            this.sync.UseVisualStyleBackColor = true;
            this.sync.Click += new System.EventHandler(this.sync_Click);
            // 
            // thread
            // 
            this.thread.Location = new System.Drawing.Point(244, 133);
            this.thread.Name = "thread";
            this.thread.Size = new System.Drawing.Size(75, 23);
            this.thread.TabIndex = 3;
            this.thread.Text = "thread";
            this.thread.UseVisualStyleBackColor = true;
            this.thread.Click += new System.EventHandler(this.thread_Click);
            // 
            // Task
            // 
            this.Task.Location = new System.Drawing.Point(381, 143);
            this.Task.Name = "Task";
            this.Task.Size = new System.Drawing.Size(75, 23);
            this.Task.TabIndex = 4;
            this.Task.Text = "Task";
            this.Task.UseVisualStyleBackColor = true;
            this.Task.Click += new System.EventHandler(this.Task_Click);
            // 
            // async
            // 
            this.async.Location = new System.Drawing.Point(483, 143);
            this.async.Name = "async";
            this.async.Size = new System.Drawing.Size(75, 23);
            this.async.TabIndex = 5;
            this.async.Text = "async";
            this.async.UseVisualStyleBackColor = true;
            this.async.Click += new System.EventHandler(this.async_ClickAsync);
            // 
            // async_result
            // 
            this.async_result.Location = new System.Drawing.Point(626, 143);
            this.async_result.Name = "async_result";
            this.async_result.Size = new System.Drawing.Size(75, 23);
            this.async_result.TabIndex = 6;
            this.async_result.Text = "async_result";
            this.async_result.UseVisualStyleBackColor = true;
            this.async_result.Click += new System.EventHandler(this.async_result_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.async_result);
            this.Controls.Add(this.async);
            this.Controls.Add(this.Task);
            this.Controls.Add(this.thread);
            this.Controls.Add(this.sync);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.hello);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button hello;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button sync;
        private System.Windows.Forms.Button thread;
        private System.Windows.Forms.Button Task;
        private System.Windows.Forms.Button async;
        private System.Windows.Forms.Button async_result;
    }
}

