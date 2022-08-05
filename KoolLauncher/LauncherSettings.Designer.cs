namespace KoolLauncherV2
{
    partial class LauncherSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherSettings));
            this.mysqlhost = new System.Windows.Forms.TextBox();
            this.mysqldatabasename = new System.Windows.Forms.TextBox();
            this.mysqlusername = new System.Windows.Forms.TextBox();
            this.mysqlpassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.elinksvalue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtlauncherregsiterpage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtforumurl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtstoreurl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtvoteurl = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtdiscordurl = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtsvip = new System.Windows.Forms.TextBox();
            this.txtsvport = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtlaunchername = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mysqlhost
            // 
            this.mysqlhost.Location = new System.Drawing.Point(12, 27);
            this.mysqlhost.Name = "mysqlhost";
            this.mysqlhost.Size = new System.Drawing.Size(164, 20);
            this.mysqlhost.TabIndex = 0;
            this.mysqlhost.Text = "136.243.219.97";
            // 
            // mysqldatabasename
            // 
            this.mysqldatabasename.Location = new System.Drawing.Point(12, 53);
            this.mysqldatabasename.Name = "mysqldatabasename";
            this.mysqldatabasename.Size = new System.Drawing.Size(164, 20);
            this.mysqldatabasename.TabIndex = 1;
            this.mysqldatabasename.Text = "koolkidx_l";
            this.mysqldatabasename.TextChanged += new System.EventHandler(this.dbname_TextChanged);
            // 
            // mysqlusername
            // 
            this.mysqlusername.Location = new System.Drawing.Point(12, 79);
            this.mysqlusername.Name = "mysqlusername";
            this.mysqlusername.Size = new System.Drawing.Size(164, 20);
            this.mysqlusername.TabIndex = 2;
            this.mysqlusername.Text = "koolkidx_l";
            // 
            // mysqlpassword
            // 
            this.mysqlpassword.Location = new System.Drawing.Point(12, 105);
            this.mysqlpassword.Name = "mysqlpassword";
            this.mysqlpassword.Size = new System.Drawing.Size(164, 20);
            this.mysqlpassword.TabIndex = 3;
            this.mysqlpassword.Text = "i1n9Zb*jqpQR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Database config:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Links and more:";
            // 
            // elinksvalue
            // 
            this.elinksvalue.Location = new System.Drawing.Point(82, 161);
            this.elinksvalue.MaxLength = 130000;
            this.elinksvalue.Name = "elinksvalue";
            this.elinksvalue.Size = new System.Drawing.Size(12, 20);
            this.elinksvalue.TabIndex = 10;
            this.elinksvalue.Text = "1";
            this.elinksvalue.TextChanged += new System.EventHandler(this.elinksvalue_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Enabled:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "0 = false 1 = true";
            // 
            // txtlauncherregsiterpage
            // 
            this.txtlauncherregsiterpage.Location = new System.Drawing.Point(213, 27);
            this.txtlauncherregsiterpage.Name = "txtlauncherregsiterpage";
            this.txtlauncherregsiterpage.Size = new System.Drawing.Size(292, 20);
            this.txtlauncherregsiterpage.TabIndex = 13;
            this.txtlauncherregsiterpage.Text = "http://localhost/koolweb1/auth/register.php";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "User registration webpage:";
            // 
            // txtforumurl
            // 
            this.txtforumurl.Location = new System.Drawing.Point(15, 200);
            this.txtforumurl.Name = "txtforumurl";
            this.txtforumurl.Size = new System.Drawing.Size(292, 20);
            this.txtforumurl.TabIndex = 15;
            this.txtforumurl.Text = "https://forum.multyplay.ro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Your minecraft fourm url:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Your minecraft store url:";
            // 
            // txtstoreurl
            // 
            this.txtstoreurl.Location = new System.Drawing.Point(15, 239);
            this.txtstoreurl.Name = "txtstoreurl";
            this.txtstoreurl.Size = new System.Drawing.Size(292, 20);
            this.txtstoreurl.TabIndex = 17;
            this.txtstoreurl.Text = "https://store.multyplay.ro";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Your minecraft vote page url:";
            // 
            // txtvoteurl
            // 
            this.txtvoteurl.Location = new System.Drawing.Point(15, 276);
            this.txtvoteurl.Name = "txtvoteurl";
            this.txtvoteurl.Size = new System.Drawing.Size(292, 20);
            this.txtvoteurl.TabIndex = 19;
            this.txtvoteurl.Text = "https://vote.multyplay.ro";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Your minecraft discord url:";
            // 
            // txtdiscordurl
            // 
            this.txtdiscordurl.Location = new System.Drawing.Point(15, 315);
            this.txtdiscordurl.Name = "txtdiscordurl";
            this.txtdiscordurl.Size = new System.Drawing.Size(292, 20);
            this.txtdiscordurl.TabIndex = 21;
            this.txtdiscordurl.Text = "https://discord.multyplay.ro";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(210, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Your Server ip:";
            // 
            // txtsvip
            // 
            this.txtsvip.Location = new System.Drawing.Point(213, 66);
            this.txtsvip.Name = "txtsvip";
            this.txtsvip.Size = new System.Drawing.Size(161, 20);
            this.txtsvip.TabIndex = 23;
            this.txtsvip.Text = "fun.multyplay.ro";
            // 
            // txtsvport
            // 
            this.txtsvport.Location = new System.Drawing.Point(213, 105);
            this.txtsvport.Name = "txtsvport";
            this.txtsvport.Size = new System.Drawing.Size(51, 20);
            this.txtsvport.TabIndex = 25;
            this.txtsvport.Text = "25565";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(210, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Your Server port:";
            // 
            // txtlaunchername
            // 
            this.txtlaunchername.Location = new System.Drawing.Point(213, 144);
            this.txtlaunchername.Name = "txtlaunchername";
            this.txtlaunchername.Size = new System.Drawing.Size(161, 20);
            this.txtlaunchername.TabIndex = 27;
            this.txtlaunchername.Text = "MultyPlay";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(210, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Your server name:";
            // 
            // LauncherSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 339);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtlaunchername);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtsvport);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtsvip);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtdiscordurl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtvoteurl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtstoreurl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtforumurl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtlauncherregsiterpage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.elinksvalue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mysqlpassword);
            this.Controls.Add(this.mysqlusername);
            this.Controls.Add(this.mysqldatabasename);
            this.Controls.Add(this.mysqlhost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LauncherSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.MySqlConnector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mysqlhost;
        private System.Windows.Forms.TextBox mysqldatabasename;
        private System.Windows.Forms.TextBox mysqlusername;
        private System.Windows.Forms.TextBox mysqlpassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox elinksvalue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtlauncherregsiterpage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtforumurl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtstoreurl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtvoteurl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtdiscordurl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtsvip;
        private System.Windows.Forms.TextBox txtsvport;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtlaunchername;
        private System.Windows.Forms.Label label12;
    }
}