namespace Cafe
{
    partial class ItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemControl));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.BtnDecrease = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.ProductImg = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.BtnAddcart = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnDecrease)).BeginInit();
            this.bunifuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 3;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.ProductImg);
            this.bunifuPanel1.Controls.Add(this.lblItemPrice);
            this.bunifuPanel1.Controls.Add(this.lblItemName);
            this.bunifuPanel1.Controls.Add(this.bunifuPanel2);
            this.bunifuPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bunifuPanel1.Location = new System.Drawing.Point(7, 10);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(286, 388);
            this.bunifuPanel1.TabIndex = 0;
            // 
            // BtnDecrease
            // 
            this.BtnDecrease.AllowFocused = false;
            this.BtnDecrease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnDecrease.AutoSizeHeight = true;
            this.BtnDecrease.BorderRadius = 29;
            this.BtnDecrease.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDecrease.Image = global::Cafe.Properties.Resources.Minus;
            this.BtnDecrease.IsCircle = true;
            this.BtnDecrease.Location = new System.Drawing.Point(207, 9);
            this.BtnDecrease.Name = "BtnDecrease";
            this.BtnDecrease.Size = new System.Drawing.Size(57, 57);
            this.BtnDecrease.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnDecrease.TabIndex = 4;
            this.BtnDecrease.TabStop = false;
            this.BtnDecrease.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            this.BtnDecrease.Click += new System.EventHandler(this.BtnDecrease_Click);
            // 
            // ProductImg
            // 
            this.ProductImg.ActiveImage = null;
            this.ProductImg.AllowAnimations = true;
            this.ProductImg.AllowBuffering = false;
            this.ProductImg.AllowToggling = false;
            this.ProductImg.AllowZooming = true;
            this.ProductImg.AllowZoomingOnFocus = false;
            this.ProductImg.BackColor = System.Drawing.Color.Transparent;
            this.ProductImg.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ProductImg.ErrorImage = ((System.Drawing.Image)(resources.GetObject("ProductImg.ErrorImage")));
            this.ProductImg.FadeWhenInactive = false;
            this.ProductImg.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.ProductImg.Image = ((System.Drawing.Image)(resources.GetObject("ProductImg.Image")));
            this.ProductImg.ImageActive = null;
            this.ProductImg.ImageLocation = null;
            this.ProductImg.ImageMargin = 40;
            this.ProductImg.ImageSize = new System.Drawing.Size(237, 195);
            this.ProductImg.ImageZoomSize = new System.Drawing.Size(277, 235);
            this.ProductImg.InitialImage = ((System.Drawing.Image)(resources.GetObject("ProductImg.InitialImage")));
            this.ProductImg.Location = new System.Drawing.Point(6, 3);
            this.ProductImg.Name = "ProductImg";
            this.ProductImg.Rotation = 0;
            this.ProductImg.ShowActiveImage = true;
            this.ProductImg.ShowCursorChanges = true;
            this.ProductImg.ShowImageBorders = true;
            this.ProductImg.ShowSizeMarkers = false;
            this.ProductImg.Size = new System.Drawing.Size(277, 235);
            this.ProductImg.TabIndex = 3;
            this.ProductImg.ToolTipText = "";
            this.ProductImg.WaitOnLoad = false;
            this.ProductImg.Zoom = 40;
            this.ProductImg.ZoomSpeed = 10;
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblItemPrice.Font = new System.Drawing.Font("Kantumruy Pro", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPrice.Location = new System.Drawing.Point(14, 270);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(84, 42);
            this.lblItemPrice.TabIndex = 2;
            this.lblItemPrice.Text = "$ 2.5";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.BackColor = System.Drawing.Color.Transparent;
            this.lblItemName.Font = new System.Drawing.Font("Kantumruy Pro SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(16, 241);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(150, 29);
            this.lblItemName.TabIndex = 2;
            this.lblItemName.Text = "Product Name";
            // 
            // BtnAddcart
            // 
            this.BtnAddcart.AllowAnimations = true;
            this.BtnAddcart.AllowMouseEffects = true;
            this.BtnAddcart.AllowToggling = false;
            this.BtnAddcart.AnimationSpeed = 200;
            this.BtnAddcart.AutoGenerateColors = false;
            this.BtnAddcart.AutoRoundBorders = false;
            this.BtnAddcart.AutoSizeLeftIcon = true;
            this.BtnAddcart.AutoSizeRightIcon = true;
            this.BtnAddcart.BackColor = System.Drawing.Color.Transparent;
            this.BtnAddcart.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(183)))), ((int)(((byte)(99)))));
            this.BtnAddcart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnAddcart.BackgroundImage")));
            this.BtnAddcart.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAddcart.ButtonText = "ទិញ";
            this.BtnAddcart.ButtonTextMarginLeft = 0;
            this.BtnAddcart.ColorContrastOnClick = 45;
            this.BtnAddcart.ColorContrastOnHover = 45;
            this.BtnAddcart.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.BtnAddcart.CustomizableEdges = borderEdges1;
            this.BtnAddcart.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnAddcart.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnAddcart.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnAddcart.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnAddcart.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.BtnAddcart.Font = new System.Drawing.Font("Kantumruy Pro", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddcart.ForeColor = System.Drawing.Color.White;
            this.BtnAddcart.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAddcart.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnAddcart.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnAddcart.IconMarginLeft = 11;
            this.BtnAddcart.IconPadding = 10;
            this.BtnAddcart.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAddcart.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnAddcart.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnAddcart.IconSize = 25;
            this.BtnAddcart.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(183)))), ((int)(((byte)(99)))));
            this.BtnAddcart.IdleBorderRadius = 30;
            this.BtnAddcart.IdleBorderThickness = 1;
            this.BtnAddcart.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(183)))), ((int)(((byte)(99)))));
            this.BtnAddcart.IdleIconLeftImage = null;
            this.BtnAddcart.IdleIconRightImage = null;
            this.BtnAddcart.IndicateFocus = false;
            this.BtnAddcart.Location = new System.Drawing.Point(35, 12);
            this.BtnAddcart.Name = "BtnAddcart";
            this.BtnAddcart.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnAddcart.OnDisabledState.BorderRadius = 30;
            this.BtnAddcart.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAddcart.OnDisabledState.BorderThickness = 1;
            this.BtnAddcart.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnAddcart.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnAddcart.OnDisabledState.IconLeftImage = null;
            this.BtnAddcart.OnDisabledState.IconRightImage = null;
            this.BtnAddcart.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.BtnAddcart.onHoverState.BorderRadius = 30;
            this.BtnAddcart.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAddcart.onHoverState.BorderThickness = 1;
            this.BtnAddcart.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.BtnAddcart.onHoverState.ForeColor = System.Drawing.Color.White;
            this.BtnAddcart.onHoverState.IconLeftImage = null;
            this.BtnAddcart.onHoverState.IconRightImage = null;
            this.BtnAddcart.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(183)))), ((int)(((byte)(99)))));
            this.BtnAddcart.OnIdleState.BorderRadius = 30;
            this.BtnAddcart.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAddcart.OnIdleState.BorderThickness = 1;
            this.BtnAddcart.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(183)))), ((int)(((byte)(99)))));
            this.BtnAddcart.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnAddcart.OnIdleState.IconLeftImage = null;
            this.BtnAddcart.OnIdleState.IconRightImage = null;
            this.BtnAddcart.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.BtnAddcart.OnPressedState.BorderRadius = 30;
            this.BtnAddcart.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAddcart.OnPressedState.BorderThickness = 1;
            this.BtnAddcart.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.BtnAddcart.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnAddcart.OnPressedState.IconLeftImage = null;
            this.BtnAddcart.OnPressedState.IconRightImage = null;
            this.BtnAddcart.Size = new System.Drawing.Size(119, 48);
            this.BtnAddcart.TabIndex = 1;
            this.BtnAddcart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnAddcart.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnAddcart.TextMarginLeft = 0;
            this.BtnAddcart.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnAddcart.UseDefaultRadiusAndThickness = true;
            this.BtnAddcart.Click += new System.EventHandler(this.BtnAddcart_Click);
            // 
            // bunifuPanel2
            // 
            this.bunifuPanel2.BackgroundColor = System.Drawing.Color.Chocolate;
            this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
            this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel2.BorderRadius = 3;
            this.bunifuPanel2.BorderThickness = 1;
            this.bunifuPanel2.Controls.Add(this.BtnDecrease);
            this.bunifuPanel2.Controls.Add(this.BtnAddcart);
            this.bunifuPanel2.Location = new System.Drawing.Point(3, 316);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = true;
            this.bunifuPanel2.Size = new System.Drawing.Size(280, 69);
            this.bunifuPanel2.TabIndex = 5;
            // 
            // ItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuPanel1);
            this.Name = "ItemControl";
            this.Size = new System.Drawing.Size(298, 401);
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnDecrease)).EndInit();
            this.bunifuPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnAddcart;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemPrice;
        private Bunifu.UI.WinForms.BunifuImageButton ProductImg;
        private Bunifu.UI.WinForms.BunifuPictureBox BtnDecrease;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
    }
}
