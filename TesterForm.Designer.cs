namespace PurchaseProposalTester
{
    partial class TesterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TesterForm));
            this.lblProductTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPurchaseOrder = new System.Windows.Forms.TextBox();
            this.txtPreparedToOrder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtActiveMailConversion = new System.Windows.Forms.TextBox();
            this.txtContainerQuantity = new System.Windows.Forms.TextBox();
            this.txtWeeklySalesForecast = new System.Windows.Forms.TextBox();
            this.btnCreateUpdateProduct = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblExpectedSOQ = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblExpectedOriginalSOQ = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblOkMsg = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkMandatoryContainerQuantity = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblProductTitle
            // 
            this.lblProductTitle.AutoSize = true;
            this.lblProductTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductTitle.Location = new System.Drawing.Point(36, 32);
            this.lblProductTitle.Name = "lblProductTitle";
            this.lblProductTitle.Size = new System.Drawing.Size(281, 32);
            this.lblProductTitle.TabIndex = 0;
            this.lblProductTitle.Text = "Product Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Available Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Purchase Order";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "Prepared to Order";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(291, 97);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(188, 38);
            this.txtProductID.TabIndex = 5;
            this.txtProductID.Text = "0";
            this.txtProductID.TextChanged += new System.EventHandler(this.txtProductID_TextChanged);
            this.txtProductID.Leave += new System.EventHandler(this.txtProductID_Leave);
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(291, 163);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(188, 38);
            this.txtStock.TabIndex = 6;
            this.txtStock.Text = "0";
            this.txtStock.TextChanged += new System.EventHandler(this.txtStock_TextChanged);
            this.txtStock.Leave += new System.EventHandler(this.txtStock_Leave);
            // 
            // txtPurchaseOrder
            // 
            this.txtPurchaseOrder.Location = new System.Drawing.Point(291, 234);
            this.txtPurchaseOrder.Name = "txtPurchaseOrder";
            this.txtPurchaseOrder.Size = new System.Drawing.Size(188, 38);
            this.txtPurchaseOrder.TabIndex = 7;
            this.txtPurchaseOrder.Text = "0";
            this.txtPurchaseOrder.TextChanged += new System.EventHandler(this.txtPurchaseOrder_TextChanged);
            this.txtPurchaseOrder.Leave += new System.EventHandler(this.txtPurchaseOrder_Leave);
            // 
            // txtPreparedToOrder
            // 
            this.txtPreparedToOrder.Location = new System.Drawing.Point(291, 303);
            this.txtPreparedToOrder.Name = "txtPreparedToOrder";
            this.txtPreparedToOrder.Size = new System.Drawing.Size(188, 38);
            this.txtPreparedToOrder.TabIndex = 8;
            this.txtPreparedToOrder.Text = "0";
            this.txtPreparedToOrder.TextChanged += new System.EventHandler(this.txtPreparedToOrder_TextChanged);
            this.txtPreparedToOrder.Leave += new System.EventHandler(this.txtPreparedToOrder_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(590, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Active Mail Conversion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(590, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 32);
            this.label6.TabIndex = 10;
            this.label6.Text = "Container Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(590, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(304, 32);
            this.label7.TabIndex = 11;
            this.label7.Text = "Weekly Sales Forecast";
            // 
            // txtActiveMailConversion
            // 
            this.txtActiveMailConversion.Location = new System.Drawing.Point(948, 104);
            this.txtActiveMailConversion.Name = "txtActiveMailConversion";
            this.txtActiveMailConversion.Size = new System.Drawing.Size(178, 38);
            this.txtActiveMailConversion.TabIndex = 12;
            this.txtActiveMailConversion.Text = "0";
            this.txtActiveMailConversion.TextChanged += new System.EventHandler(this.txtActiveMailConversion_TextChanged);
            this.txtActiveMailConversion.Leave += new System.EventHandler(this.txtActiveMailConversion_Leave);
            // 
            // txtContainerQuantity
            // 
            this.txtContainerQuantity.Location = new System.Drawing.Point(948, 241);
            this.txtContainerQuantity.Name = "txtContainerQuantity";
            this.txtContainerQuantity.Size = new System.Drawing.Size(178, 38);
            this.txtContainerQuantity.TabIndex = 14;
            this.txtContainerQuantity.Text = "1";
            this.txtContainerQuantity.TextChanged += new System.EventHandler(this.txtContainerQuantity_TextChanged);
            this.txtContainerQuantity.Leave += new System.EventHandler(this.txtContainerQuantity_Leave);
            // 
            // txtWeeklySalesForecast
            // 
            this.txtWeeklySalesForecast.Location = new System.Drawing.Point(948, 172);
            this.txtWeeklySalesForecast.Name = "txtWeeklySalesForecast";
            this.txtWeeklySalesForecast.Size = new System.Drawing.Size(178, 38);
            this.txtWeeklySalesForecast.TabIndex = 13;
            this.txtWeeklySalesForecast.Text = "0";
            this.txtWeeklySalesForecast.TextChanged += new System.EventHandler(this.txtWeeklySalesForecast_TextChanged);
            this.txtWeeklySalesForecast.Leave += new System.EventHandler(this.txtWeeklySalesForecast_Leave);
            // 
            // btnCreateUpdateProduct
            // 
            this.btnCreateUpdateProduct.Location = new System.Drawing.Point(341, 581);
            this.btnCreateUpdateProduct.Name = "btnCreateUpdateProduct";
            this.btnCreateUpdateProduct.Size = new System.Drawing.Size(554, 59);
            this.btnCreateUpdateProduct.TabIndex = 15;
            this.btnCreateUpdateProduct.Text = "Create Proposal";
            this.btnCreateUpdateProduct.UseVisualStyleBackColor = true;
            this.btnCreateUpdateProduct.Click += new System.EventHandler(this.btnCreateUpdateProduct_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 440);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(212, 32);
            this.label8.TabIndex = 16;
            this.label8.Text = "Expected SOQ:";
            // 
            // lblExpectedSOQ
            // 
            this.lblExpectedSOQ.AutoSize = true;
            this.lblExpectedSOQ.Location = new System.Drawing.Point(285, 440);
            this.lblExpectedSOQ.Name = "lblExpectedSOQ";
            this.lblExpectedSOQ.Size = new System.Drawing.Size(31, 32);
            this.lblExpectedSOQ.TabIndex = 17;
            this.lblExpectedSOQ.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(46, 488);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(214, 29);
            this.label9.TabIndex = 18;
            this.label9.Text = "Un-rounded Value:";
            // 
            // lblExpectedOriginalSOQ
            // 
            this.lblExpectedOriginalSOQ.AutoSize = true;
            this.lblExpectedOriginalSOQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpectedOriginalSOQ.Location = new System.Drawing.Point(291, 488);
            this.lblExpectedOriginalSOQ.Name = "lblExpectedOriginalSOQ";
            this.lblExpectedOriginalSOQ.Size = new System.Drawing.Size(26, 29);
            this.lblExpectedOriginalSOQ.TabIndex = 19;
            this.lblExpectedOriginalSOQ.Text = "0";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(48, 694);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 36);
            this.lblError.TabIndex = 20;
            // 
            // lblOkMsg
            // 
            this.lblOkMsg.AutoSize = true;
            this.lblOkMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkMsg.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblOkMsg.Location = new System.Drawing.Point(48, 694);
            this.lblOkMsg.Name = "lblOkMsg";
            this.lblOkMsg.Size = new System.Drawing.Size(0, 36);
            this.lblOkMsg.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(590, 303);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(331, 32);
            this.label10.TabIndex = 22;
            this.label10.Text = "Mandatory Container Qty";
            // 
            // chkMandatoryContainerQuantity
            // 
            this.chkMandatoryContainerQuantity.AutoSize = true;
            this.chkMandatoryContainerQuantity.Location = new System.Drawing.Point(948, 310);
            this.chkMandatoryContainerQuantity.Name = "chkMandatoryContainerQuantity";
            this.chkMandatoryContainerQuantity.Size = new System.Drawing.Size(34, 33);
            this.chkMandatoryContainerQuantity.TabIndex = 15;
            this.chkMandatoryContainerQuantity.UseVisualStyleBackColor = true;
            this.chkMandatoryContainerQuantity.CheckedChanged += new System.EventHandler(this.chkMandatoryContainerQuantity_CheckedChanged);
            // 
            // TesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 747);
            this.Controls.Add(this.chkMandatoryContainerQuantity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblOkMsg);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblExpectedOriginalSOQ);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblExpectedSOQ);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCreateUpdateProduct);
            this.Controls.Add(this.txtWeeklySalesForecast);
            this.Controls.Add(this.txtContainerQuantity);
            this.Controls.Add(this.txtActiveMailConversion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPreparedToOrder);
            this.Controls.Add(this.txtPurchaseOrder);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProductTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TesterForm";
            this.Text = "Proposal Testing Thingamajig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPurchaseOrder;
        private System.Windows.Forms.TextBox txtPreparedToOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtActiveMailConversion;
        private System.Windows.Forms.TextBox txtContainerQuantity;
        private System.Windows.Forms.TextBox txtWeeklySalesForecast;
        private System.Windows.Forms.Button btnCreateUpdateProduct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblExpectedSOQ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblExpectedOriginalSOQ;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblOkMsg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkMandatoryContainerQuantity;
    }
}

