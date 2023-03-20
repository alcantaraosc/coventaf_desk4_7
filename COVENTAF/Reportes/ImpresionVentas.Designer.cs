﻿
namespace COVENTAF.Reportes
{
    partial class ImpresionVentas
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpresionVentas));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.detailTable = new DevExpress.XtraReports.UI.XRTable();
            this.detailTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.quantity = new DevExpress.XtraReports.UI.XRTableCell();
            this.productName = new DevExpress.XtraReports.UI.XRTableCell();
            this.unitPrice = new DevExpress.XtraReports.UI.XRTableCell();
            this.unitDiscount = new DevExpress.XtraReports.UI.XRTableCell();
            this.unitTax = new DevExpress.XtraReports.UI.XRTableCell();
            this.lineTotal = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.vendorContactsTable = new DevExpress.XtraReports.UI.XRTable();
            this.vendorContactsRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.vendorWebsite = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorEmail = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorPhone = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.invoiceDate = new DevExpress.XtraReports.UI.XRLabel();
            this.vendorLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.vendorTable = new DevExpress.XtraReports.UI.XRTable();
            this.vendorNameRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.vendorName = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorAddressRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.vendorAddress = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorCityRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.vendorCity = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorCountryRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.vendorCountry = new DevExpress.XtraReports.UI.XRTableCell();
            this.customerTable = new DevExpress.XtraReports.UI.XRTable();
            this.customerNameRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.customerName = new DevExpress.XtraReports.UI.XRTableCell();
            this.customerAddressRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.customerAddress = new DevExpress.XtraReports.UI.XRTableCell();
            this.customerCityRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.customerCity = new DevExpress.XtraReports.UI.XRTableCell();
            this.customerCountryRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.customerCountry = new DevExpress.XtraReports.UI.XRTableCell();
            this.SubBand1 = new DevExpress.XtraReports.UI.SubBand();
            this.headerTable = new DevExpress.XtraReports.UI.XRTable();
            this.headerTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.quantityCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.productNameCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.unitPriceCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.unitDiscountCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.unitTaxCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.lineTotalCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.invoiceLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.totalTable = new DevExpress.XtraReports.UI.XRTable();
            this.subtotalRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.subtotalCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.subtotal = new DevExpress.XtraReports.UI.XRTableCell();
            this.discountRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.discountCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.discount = new DevExpress.XtraReports.UI.XRTableCell();
            this.taxRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.taxCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.tax = new DevExpress.XtraReports.UI.XRTableCell();
            this.totalRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.totalCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.total = new DevExpress.XtraReports.UI.XRTableCell();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.baseControlStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.SubtotalCalcField = new DevExpress.XtraReports.UI.CalculatedField();
            this.DiscountLineTotalCalcField = new DevExpress.XtraReports.UI.CalculatedField();
            this.TaxLineTotalCalcField = new DevExpress.XtraReports.UI.CalculatedField();
            this.TotalCalcField = new DevExpress.XtraReports.UI.CalculatedField();
            this.UnitDiscountParameter = new DevExpress.XtraReports.Parameters.Parameter();
            this.UnitTaxParameter = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrlblTituloEjercito = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblNombreTienda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblDireccionTienda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblTelefono = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.detailTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorContactsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.detailTable});
            this.Detail.HeightF = 62.33323F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "baseControlStyle";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // detailTable
            // 
            this.detailTable.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.detailTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.detailTable.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.detailTable.LocationFloat = new DevExpress.Utils.PointFloat(20.00001F, 0F);
            this.detailTable.Name = "detailTable";
            this.detailTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.detailTableRow});
            this.detailTable.SizeF = new System.Drawing.SizeF(450F, 30F);
            this.detailTable.StylePriority.UseBorderColor = false;
            this.detailTable.StylePriority.UseBorders = false;
            this.detailTable.StylePriority.UseFont = false;
            // 
            // detailTableRow
            // 
            this.detailTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.quantity,
            this.productName,
            this.unitPrice,
            this.unitDiscount,
            this.unitTax,
            this.lineTotal});
            this.detailTableRow.Name = "detailTableRow";
            this.detailTableRow.Weight = 10.58D;
            // 
            // quantity
            // 
            this.quantity.Name = "quantity";
            this.quantity.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 5, 0, 100F);
            this.quantity.StylePriority.UsePadding = false;
            this.quantity.StylePriority.UseTextAlignment = false;
            this.quantity.Text = "1";
            this.quantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.quantity.Weight = 0.20453308109553722D;
            // 
            // productName
            // 
            this.productName.Name = "productName";
            this.productName.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 2, 5, 0, 100F);
            this.productName.StylePriority.UsePadding = false;
            this.productName.Text = "ProductName";
            this.productName.Weight = 1.158990034935852D;
            // 
            // unitPrice
            // 
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 5, 0, 100F);
            this.unitPrice.StylePriority.UsePadding = false;
            this.unitPrice.StylePriority.UseTextAlignment = false;
            this.unitPrice.Text = "0.00 C$";
            this.unitPrice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.unitPrice.TextFormatString = "{0:$0.00}";
            this.unitPrice.Weight = 0.39204113901926829D;
            // 
            // unitDiscount
            // 
            this.unitDiscount.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?UnitDiscountParameter")});
            this.unitDiscount.Name = "unitDiscount";
            this.unitDiscount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 5, 0, 100F);
            this.unitDiscount.StylePriority.UseFont = false;
            this.unitDiscount.StylePriority.UsePadding = false;
            this.unitDiscount.StylePriority.UseTextAlignment = false;
            this.unitDiscount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.unitDiscount.TextFormatString = "{0:0.##}%";
            this.unitDiscount.Weight = 0.44317361268957955D;
            // 
            // unitTax
            // 
            this.unitTax.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?UnitTaxParameter")});
            this.unitTax.Name = "unitTax";
            this.unitTax.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 5, 0, 100F);
            this.unitTax.StylePriority.UseFont = false;
            this.unitTax.StylePriority.UsePadding = false;
            this.unitTax.StylePriority.UseTextAlignment = false;
            this.unitTax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.unitTax.TextFormatString = "{0:0.##}%";
            this.unitTax.Weight = 0.25735660160031604D;
            // 
            // lineTotal
            // 
            this.lineTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lineTotal.Name = "lineTotal";
            this.lineTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 5, 0, 100F);
            this.lineTotal.StylePriority.UseFont = false;
            this.lineTotal.StylePriority.UseForeColor = false;
            this.lineTotal.StylePriority.UsePadding = false;
            this.lineTotal.StylePriority.UseTextAlignment = false;
            this.lineTotal.Text = "0.00 C$";
            this.lineTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.lineTotal.TextFormatString = "{0:$0.00}";
            this.lineTotal.Weight = 0.61188167999911147D;
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.StylePriority.UseBackColor = false;
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.vendorContactsTable,
            this.xrLine1});
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // vendorContactsTable
            // 
            this.vendorContactsTable.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.vendorContactsTable.BorderColor = System.Drawing.Color.Gray;
            this.vendorContactsTable.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.vendorContactsTable.LocationFloat = new DevExpress.Utils.PointFloat(19.99999F, 18.00005F);
            this.vendorContactsTable.Name = "vendorContactsTable";
            this.vendorContactsTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vendorContactsTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.vendorContactsRow});
            this.vendorContactsTable.SizeF = new System.Drawing.SizeF(630.0003F, 25F);
            this.vendorContactsTable.StylePriority.UseBorderColor = false;
            this.vendorContactsTable.StylePriority.UseFont = false;
            this.vendorContactsTable.StylePriority.UsePadding = false;
            // 
            // vendorContactsRow
            // 
            this.vendorContactsRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.vendorWebsite,
            this.vendorEmail,
            this.vendorPhone});
            this.vendorContactsRow.Name = "vendorContactsRow";
            this.vendorContactsRow.Weight = 1D;
            // 
            // vendorWebsite
            // 
            this.vendorWebsite.CanShrink = true;
            this.vendorWebsite.Name = "vendorWebsite";
            this.vendorWebsite.StylePriority.UseTextAlignment = false;
            this.vendorWebsite.Text = "VendorWebsite";
            this.vendorWebsite.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.vendorWebsite.Weight = 1D;
            // 
            // vendorEmail
            // 
            this.vendorEmail.CanShrink = true;
            this.vendorEmail.Name = "vendorEmail";
            this.vendorEmail.StylePriority.UseBorders = false;
            this.vendorEmail.StylePriority.UseTextAlignment = false;
            this.vendorEmail.Text = "VendorEmail";
            this.vendorEmail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.vendorEmail.Weight = 1D;
            // 
            // vendorPhone
            // 
            this.vendorPhone.CanShrink = true;
            this.vendorPhone.Name = "vendorPhone";
            this.vendorPhone.StylePriority.UseBorders = false;
            this.vendorPhone.StylePriority.UseTextAlignment = false;
            this.vendorPhone.Text = "VendorPhone";
            this.vendorPhone.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.vendorPhone.Weight = 1D;
            // 
            // xrLine1
            // 
            this.xrLine1.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.xrLine1.LineWidth = 2F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(669.6851F, 10F);
            this.xrLine1.StylePriority.UseForeColor = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLblTelefono,
            this.xrLblDireccionTienda,
            this.xrLblNombreTienda,
            this.xrlblTituloEjercito,
            this.invoiceDate,
            this.vendorLogo,
            this.vendorTable,
            this.customerTable});
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader1.HeightF = 416.9584F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.StyleName = "baseControlStyle";
            this.GroupHeader1.StylePriority.UseBackColor = false;
            this.GroupHeader1.SubBands.AddRange(new DevExpress.XtraReports.UI.SubBand[] {
            this.SubBand1});
            // 
            // invoiceDate
            // 
            this.invoiceDate.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.invoiceDate.LocationFloat = new DevExpress.Utils.PointFloat(399.9951F, 376.25F);
            this.invoiceDate.Name = "invoiceDate";
            this.invoiceDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.invoiceDate.SizeF = new System.Drawing.SizeF(250F, 22.99998F);
            this.invoiceDate.StylePriority.UseTextAlignment = false;
            this.invoiceDate.Text = "InvoiceDate";
            this.invoiceDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.invoiceDate.TextFormatString = "{0:d MMMM yyyy}";
            // 
            // vendorLogo
            // 
            this.vendorLogo.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.vendorLogo.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.TopRight;
            this.vendorLogo.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("vendorLogo.ImageSource"));
            this.vendorLogo.LocationFloat = new DevExpress.Utils.PointFloat(399.9951F, 291.25F);
            this.vendorLogo.Name = "vendorLogo";
            this.vendorLogo.SizeF = new System.Drawing.SizeF(250F, 75F);
            this.vendorLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            this.vendorLogo.StylePriority.UseBorderColor = false;
            this.vendorLogo.StylePriority.UseBorders = false;
            this.vendorLogo.StylePriority.UsePadding = false;
            // 
            // vendorTable
            // 
            this.vendorTable.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.vendorTable.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.vendorTable.LocationFloat = new DevExpress.Utils.PointFloat(399.9951F, 201.25F);
            this.vendorTable.Name = "vendorTable";
            this.vendorTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.vendorNameRow,
            this.vendorAddressRow,
            this.vendorCityRow,
            this.vendorCountryRow});
            this.vendorTable.SizeF = new System.Drawing.SizeF(250F, 80F);
            this.vendorTable.StylePriority.UseFont = false;
            this.vendorTable.StylePriority.UseTextAlignment = false;
            this.vendorTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // vendorNameRow
            // 
            this.vendorNameRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.vendorName});
            this.vendorNameRow.Name = "vendorNameRow";
            this.vendorNameRow.Weight = 0.8D;
            // 
            // vendorName
            // 
            this.vendorName.CanShrink = true;
            this.vendorName.Name = "vendorName";
            this.vendorName.StylePriority.UseFont = false;
            this.vendorName.StylePriority.UsePadding = false;
            this.vendorName.Text = "VendorName";
            this.vendorName.Weight = 1D;
            // 
            // vendorAddressRow
            // 
            this.vendorAddressRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.vendorAddress});
            this.vendorAddressRow.Name = "vendorAddressRow";
            this.vendorAddressRow.Weight = 0.8D;
            // 
            // vendorAddress
            // 
            this.vendorAddress.CanShrink = true;
            this.vendorAddress.Name = "vendorAddress";
            this.vendorAddress.StylePriority.UseFont = false;
            this.vendorAddress.Text = "VendorAddress";
            this.vendorAddress.Weight = 1D;
            // 
            // vendorCityRow
            // 
            this.vendorCityRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.vendorCity});
            this.vendorCityRow.Name = "vendorCityRow";
            this.vendorCityRow.Weight = 0.8D;
            // 
            // vendorCity
            // 
            this.vendorCity.CanShrink = true;
            this.vendorCity.Name = "vendorCity";
            this.vendorCity.StylePriority.UseFont = false;
            this.vendorCity.Text = "VendorCity";
            this.vendorCity.Weight = 1D;
            // 
            // vendorCountryRow
            // 
            this.vendorCountryRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.vendorCountry});
            this.vendorCountryRow.Name = "vendorCountryRow";
            this.vendorCountryRow.Weight = 0.8D;
            // 
            // vendorCountry
            // 
            this.vendorCountry.CanShrink = true;
            this.vendorCountry.Name = "vendorCountry";
            this.vendorCountry.StylePriority.UseFont = false;
            this.vendorCountry.Text = "VendorCountry";
            this.vendorCountry.Weight = 1D;
            // 
            // customerTable
            // 
            this.customerTable.LocationFloat = new DevExpress.Utils.PointFloat(20.00001F, 281.6667F);
            this.customerTable.Name = "customerTable";
            this.customerTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.customerNameRow,
            this.customerAddressRow,
            this.customerCityRow,
            this.customerCountryRow});
            this.customerTable.SizeF = new System.Drawing.SizeF(250F, 100F);
            // 
            // customerNameRow
            // 
            this.customerNameRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.customerName});
            this.customerNameRow.Name = "customerNameRow";
            this.customerNameRow.Weight = 1D;
            // 
            // customerName
            // 
            this.customerName.CanShrink = true;
            this.customerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.customerName.Name = "customerName";
            this.customerName.StylePriority.UseFont = false;
            this.customerName.StylePriority.UsePadding = false;
            this.customerName.Text = "CustomerName";
            this.customerName.Weight = 1.1915477284685581D;
            // 
            // customerAddressRow
            // 
            this.customerAddressRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.customerAddress});
            this.customerAddressRow.Name = "customerAddressRow";
            this.customerAddressRow.Weight = 1D;
            // 
            // customerAddress
            // 
            this.customerAddress.CanShrink = true;
            this.customerAddress.Name = "customerAddress";
            this.customerAddress.Text = "CustomerAddress";
            this.customerAddress.Weight = 1.1915477284685581D;
            // 
            // customerCityRow
            // 
            this.customerCityRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.customerCity});
            this.customerCityRow.Name = "customerCityRow";
            this.customerCityRow.Weight = 1D;
            // 
            // customerCity
            // 
            this.customerCity.CanShrink = true;
            this.customerCity.Name = "customerCity";
            this.customerCity.Text = "CustomerCity";
            this.customerCity.Weight = 1.1915477284685581D;
            // 
            // customerCountryRow
            // 
            this.customerCountryRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.customerCountry});
            this.customerCountryRow.Name = "customerCountryRow";
            this.customerCountryRow.Weight = 1D;
            // 
            // customerCountry
            // 
            this.customerCountry.CanShrink = true;
            this.customerCountry.Name = "customerCountry";
            this.customerCountry.Text = "CustomerCountry";
            this.customerCountry.Weight = 1.1915477284685581D;
            // 
            // SubBand1
            // 
            this.SubBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.headerTable,
            this.invoiceLabel});
            this.SubBand1.HeightF = 95.00003F;
            this.SubBand1.KeepTogether = true;
            this.SubBand1.Name = "SubBand1";
            // 
            // headerTable
            // 
            this.headerTable.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.headerTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.headerTable.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.headerTable.BorderWidth = 3F;
            this.headerTable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.headerTable.LocationFloat = new DevExpress.Utils.PointFloat(20.00001F, 60.00001F);
            this.headerTable.Name = "headerTable";
            this.headerTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
            this.headerTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.headerTableRow});
            this.headerTable.SizeF = new System.Drawing.SizeF(450F, 35.00002F);
            this.headerTable.StylePriority.UseBorderColor = false;
            this.headerTable.StylePriority.UseBorders = false;
            this.headerTable.StylePriority.UseBorderWidth = false;
            this.headerTable.StylePriority.UseFont = false;
            this.headerTable.StylePriority.UsePadding = false;
            // 
            // headerTableRow
            // 
            this.headerTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.quantityCaption,
            this.productNameCaption,
            this.unitPriceCaption,
            this.unitDiscountCaption,
            this.unitTaxCaption,
            this.lineTotalCaption});
            this.headerTableRow.Name = "headerTableRow";
            this.headerTableRow.Weight = 11.5D;
            // 
            // quantityCaption
            // 
            this.quantityCaption.Name = "quantityCaption";
            this.quantityCaption.StylePriority.UseTextAlignment = false;
            this.quantityCaption.Text = "Qty";
            this.quantityCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.quantityCaption.Weight = 0.19686837340925539D;
            // 
            // productNameCaption
            // 
            this.productNameCaption.Name = "productNameCaption";
            this.productNameCaption.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 0, 5, 0, 100F);
            this.productNameCaption.StylePriority.UsePadding = false;
            this.productNameCaption.Text = "Description";
            this.productNameCaption.Weight = 1.1155549107515446D;
            // 
            // unitPriceCaption
            // 
            this.unitPriceCaption.Name = "unitPriceCaption";
            this.unitPriceCaption.StylePriority.UseTextAlignment = false;
            this.unitPriceCaption.Text = "Price";
            this.unitPriceCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.unitPriceCaption.Weight = 0.37734758903012311D;
            // 
            // unitDiscountCaption
            // 
            this.unitDiscountCaption.Name = "unitDiscountCaption";
            this.unitDiscountCaption.StylePriority.UseTextAlignment = false;
            this.unitDiscountCaption.Text = "Discount";
            this.unitDiscountCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.unitDiscountCaption.Weight = 0.42656415919904428D;
            // 
            // unitTaxCaption
            // 
            this.unitTaxCaption.Name = "unitTaxCaption";
            this.unitTaxCaption.StylePriority.UseTextAlignment = false;
            this.unitTaxCaption.Text = "Tax";
            this.unitTaxCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.unitTaxCaption.Weight = 0.2477260473949362D;
            // 
            // lineTotalCaption
            // 
            this.lineTotalCaption.Name = "lineTotalCaption";
            this.lineTotalCaption.StylePriority.UseTextAlignment = false;
            this.lineTotalCaption.Text = "LineTotal ";
            this.lineTotalCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.lineTotalCaption.Weight = 0.58896456652396112D;
            // 
            // invoiceLabel
            // 
            this.invoiceLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.invoiceLabel.LocationFloat = new DevExpress.Utils.PointFloat(20F, 0F);
            this.invoiceLabel.Name = "invoiceLabel";
            this.invoiceLabel.SizeF = new System.Drawing.SizeF(157.29F, 45F);
            this.invoiceLabel.StylePriority.UseFont = false;
            this.invoiceLabel.StylePriority.UsePadding = false;
            this.invoiceLabel.StylePriority.UseTextAlignment = false;
            this.invoiceLabel.Text = "Invoice";
            this.invoiceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.totalTable});
            this.GroupFooter1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail;
            this.GroupFooter1.HeightF = 188F;
            this.GroupFooter1.KeepTogether = true;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry;
            this.GroupFooter1.StyleName = "baseControlStyle";
            // 
            // totalTable
            // 
            this.totalTable.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.totalTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.totalTable.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.totalTable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.totalTable.ForeColor = System.Drawing.Color.Black;
            this.totalTable.LocationFloat = new DevExpress.Utils.PointFloat(200F, 28F);
            this.totalTable.Name = "totalTable";
            this.totalTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 5, 0, 100F);
            this.totalTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.subtotalRow,
            this.discountRow,
            this.taxRow,
            this.totalRow});
            this.totalTable.SizeF = new System.Drawing.SizeF(449.9999F, 136F);
            this.totalTable.StylePriority.UseBorderColor = false;
            this.totalTable.StylePriority.UseBorders = false;
            this.totalTable.StylePriority.UseFont = false;
            this.totalTable.StylePriority.UseForeColor = false;
            this.totalTable.StylePriority.UsePadding = false;
            // 
            // subtotalRow
            // 
            this.subtotalRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.subtotalRow.BorderWidth = 3F;
            this.subtotalRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.subtotalCaption,
            this.subtotal});
            this.subtotalRow.Name = "subtotalRow";
            this.subtotalRow.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 7, 0, 100F);
            this.subtotalRow.StylePriority.UseBorderColor = false;
            this.subtotalRow.StylePriority.UseBorderWidth = false;
            this.subtotalRow.StylePriority.UsePadding = false;
            this.subtotalRow.Weight = 1.5217391304347823D;
            // 
            // subtotalCaption
            // 
            this.subtotalCaption.Name = "subtotalCaption";
            this.subtotalCaption.StylePriority.UseBorders = false;
            this.subtotalCaption.StylePriority.UseFont = false;
            this.subtotalCaption.StylePriority.UsePadding = false;
            this.subtotalCaption.StylePriority.UseTextAlignment = false;
            this.subtotalCaption.Text = "Subtotal";
            this.subtotalCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.subtotalCaption.Weight = 1.3201665860348288D;
            // 
            // subtotal
            // 
            this.subtotal.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SubtotalCalcField]")});
            this.subtotal.Name = "subtotal";
            this.subtotal.StylePriority.UseBorders = false;
            this.subtotal.StylePriority.UseFont = false;
            this.subtotal.StylePriority.UsePadding = false;
            this.subtotal.StylePriority.UseTextAlignment = false;
            this.subtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.subtotal.TextFormatString = "{0:0.00 C$}";
            this.subtotal.Weight = 0.98694342989111372D;
            // 
            // discountRow
            // 
            this.discountRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.discountCaption,
            this.discount});
            this.discountRow.Name = "discountRow";
            this.discountRow.Weight = 1.4347826086956519D;
            // 
            // discountCaption
            // 
            this.discountCaption.Name = "discountCaption";
            this.discountCaption.StylePriority.UseBorders = false;
            this.discountCaption.StylePriority.UsePadding = false;
            this.discountCaption.StylePriority.UseTextAlignment = false;
            this.discountCaption.Text = "Discount";
            this.discountCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.discountCaption.Weight = 2.4318719053798583D;
            // 
            // discount
            // 
            this.discount.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([DiscountLineTotalCalcField])")});
            this.discount.Name = "discount";
            this.discount.StylePriority.UseBorders = false;
            this.discount.StylePriority.UsePadding = false;
            this.discount.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.discount.Summary = xrSummary1;
            this.discount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.discount.TextFormatString = "{0:0.00 C$}";
            this.discount.Weight = 1.8180023758819859D;
            // 
            // taxRow
            // 
            this.taxRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.taxCaption,
            this.tax});
            this.taxRow.Name = "taxRow";
            this.taxRow.Weight = 1.4347826086956519D;
            // 
            // taxCaption
            // 
            this.taxCaption.Name = "taxCaption";
            this.taxCaption.StylePriority.UseTextAlignment = false;
            this.taxCaption.Text = "Tax";
            this.taxCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.taxCaption.Weight = 3.9586576660725137D;
            // 
            // tax
            // 
            this.tax.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([TaxLineTotalCalcField])")});
            this.tax.Name = "tax";
            this.tax.StylePriority.UseTextAlignment = false;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.tax.Summary = xrSummary2;
            this.tax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tax.TextFormatString = "{0:0.00 C$}";
            this.tax.Weight = 2.9593866970913618D;
            // 
            // totalRow
            // 
            this.totalRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.totalRow.BorderWidth = 3F;
            this.totalRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.totalCaption,
            this.total});
            this.totalRow.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.totalRow.Name = "totalRow";
            this.totalRow.StylePriority.UseBorderColor = false;
            this.totalRow.StylePriority.UseBorderWidth = false;
            this.totalRow.StylePriority.UseFont = false;
            this.totalRow.Weight = 1.5217391304347823D;
            // 
            // totalCaption
            // 
            this.totalCaption.Name = "totalCaption";
            this.totalCaption.StylePriority.UseFont = false;
            this.totalCaption.StylePriority.UseTextAlignment = false;
            this.totalCaption.Text = "Total";
            this.totalCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            this.totalCaption.Weight = 5.0703609369432883D;
            // 
            // total
            // 
            this.total.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalCalcField]")});
            this.total.Name = "total";
            this.total.StylePriority.UseFont = false;
            this.total.StylePriority.UseTextAlignment = false;
            this.total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            this.total.TextFormatString = "{0:0.00 C$}";
            this.total.Weight = 3.7904626522673168D;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(Api.Model.ViewModels.ViewModelFacturacion);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // baseControlStyle
            // 
            this.baseControlStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.baseControlStyle.Name = "baseControlStyle";
            this.baseControlStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // SubtotalCalcField
            // 
            this.SubtotalCalcField.DisplayName = "Subtotal";
            this.SubtotalCalcField.FieldType = DevExpress.XtraReports.UI.FieldType.Decimal;
            this.SubtotalCalcField.Name = "SubtotalCalcField";
            // 
            // DiscountLineTotalCalcField
            // 
            this.DiscountLineTotalCalcField.DisplayName = "DiscountLineTotal";
            this.DiscountLineTotalCalcField.Expression = "0";
            this.DiscountLineTotalCalcField.FieldType = DevExpress.XtraReports.UI.FieldType.Decimal;
            this.DiscountLineTotalCalcField.Name = "DiscountLineTotalCalcField";
            // 
            // TaxLineTotalCalcField
            // 
            this.TaxLineTotalCalcField.DisplayName = "TaxLineTotal";
            this.TaxLineTotalCalcField.Expression = "0";
            this.TaxLineTotalCalcField.FieldType = DevExpress.XtraReports.UI.FieldType.Decimal;
            this.TaxLineTotalCalcField.Name = "TaxLineTotalCalcField";
            // 
            // TotalCalcField
            // 
            this.TotalCalcField.DisplayName = "Total";
            this.TotalCalcField.Expression = "[SubtotalCalcField]";
            this.TotalCalcField.FieldType = DevExpress.XtraReports.UI.FieldType.Decimal;
            this.TotalCalcField.Name = "TotalCalcField";
            // 
            // UnitDiscountParameter
            // 
            this.UnitDiscountParameter.Name = "UnitDiscountParameter";
            this.UnitDiscountParameter.Type = typeof(decimal);
            this.UnitDiscountParameter.ValueInfo = "0";
            this.UnitDiscountParameter.Visible = false;
            // 
            // UnitTaxParameter
            // 
            this.UnitTaxParameter.Name = "UnitTaxParameter";
            this.UnitTaxParameter.Type = typeof(decimal);
            this.UnitTaxParameter.ValueInfo = "0";
            this.UnitTaxParameter.Visible = false;
            // 
            // xrlblTituloEjercito
            // 
            this.xrlblTituloEjercito.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.xrlblTituloEjercito.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrlblTituloEjercito.Multiline = true;
            this.xrlblTituloEjercito.Name = "xrlblTituloEjercito";
            this.xrlblTituloEjercito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrlblTituloEjercito.SizeF = new System.Drawing.SizeF(669.6851F, 23F);
            this.xrlblTituloEjercito.StylePriority.UseFont = false;
            this.xrlblTituloEjercito.StylePriority.UseTextAlignment = false;
            this.xrlblTituloEjercito.Text = "EJERCITO DE NICARAGUA";
            this.xrlblTituloEjercito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLblNombreTienda
            // 
            this.xrLblNombreTienda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.xrLblNombreTienda.LocationFloat = new DevExpress.Utils.PointFloat(0F, 33.00001F);
            this.xrLblNombreTienda.Multiline = true;
            this.xrLblNombreTienda.Name = "xrLblNombreTienda";
            this.xrLblNombreTienda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLblNombreTienda.SizeF = new System.Drawing.SizeF(669.6851F, 23F);
            this.xrLblNombreTienda.StylePriority.UseFont = false;
            this.xrLblNombreTienda.StylePriority.UseTextAlignment = false;
            this.xrLblNombreTienda.Text = "SUPER MERCADO";
            this.xrLblNombreTienda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLblDireccionTienda
            // 
            this.xrLblDireccionTienda.AutoWidth = true;
            this.xrLblDireccionTienda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.xrLblDireccionTienda.LocationFloat = new DevExpress.Utils.PointFloat(0F, 56.00001F);
            this.xrLblDireccionTienda.Multiline = true;
            this.xrLblDireccionTienda.Name = "xrLblDireccionTienda";
            this.xrLblDireccionTienda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLblDireccionTienda.SizeF = new System.Drawing.SizeF(669.6851F, 23F);
            this.xrLblDireccionTienda.StylePriority.UseFont = false;
            this.xrLblDireccionTienda.StylePriority.UseTextAlignment = false;
            this.xrLblDireccionTienda.Text = "Direccion del Super";
            this.xrLblDireccionTienda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLblTelefono
            // 
            this.xrLblTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.xrLblTelefono.LocationFloat = new DevExpress.Utils.PointFloat(0F, 79.00003F);
            this.xrLblTelefono.Multiline = true;
            this.xrLblTelefono.Name = "xrLblTelefono";
            this.xrLblTelefono.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLblTelefono.SizeF = new System.Drawing.SizeF(670.0001F, 23F);
            this.xrLblTelefono.StylePriority.UseFont = false;
            this.xrLblTelefono.StylePriority.UseTextAlignment = false;
            this.xrLblTelefono.Text = "Telefono";
            this.xrLblTelefono.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTable1
            // 
            this.xrTable1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.xrTable1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.xrTable1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(20.00001F, 29.99999F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(449.9951F, 30F);
            this.xrTable1.StylePriority.UseBorderColor = false;
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 10.58D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FacturaLinea].[Descripcion]")});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 2, 5, 0, 100F);
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.Text = "Nombre del Producto";
            this.xrTableCell2.Weight = 2.9316225973444627D;
            // 
            // ImpresionVentas
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.SubtotalCalcField,
            this.DiscountLineTotalCalcField,
            this.TaxLineTotalCalcField,
            this.TotalCalcField});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(90, 90, 100, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.UnitDiscountParameter,
            this.UnitTaxParameter});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.baseControlStyle});
            this.StyleSheetPath = "";
            this.Version = "19.2";
            ((System.ComponentModel.ISupportInitialize)(this.detailTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorContactsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable detailTable;
        private DevExpress.XtraReports.UI.XRTableRow detailTableRow;
        private DevExpress.XtraReports.UI.XRTableCell quantity;
        private DevExpress.XtraReports.UI.XRTableCell productName;
        private DevExpress.XtraReports.UI.XRTableCell unitPrice;
        private DevExpress.XtraReports.UI.XRTableCell unitDiscount;
        private DevExpress.XtraReports.UI.XRTableCell unitTax;
        private DevExpress.XtraReports.UI.XRTableCell lineTotal;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTable vendorContactsTable;
        private DevExpress.XtraReports.UI.XRTableRow vendorContactsRow;
        private DevExpress.XtraReports.UI.XRTableCell vendorWebsite;
        private DevExpress.XtraReports.UI.XRTableCell vendorEmail;
        private DevExpress.XtraReports.UI.XRTableCell vendorPhone;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel invoiceDate;
        private DevExpress.XtraReports.UI.XRPictureBox vendorLogo;
        private DevExpress.XtraReports.UI.XRTable vendorTable;
        private DevExpress.XtraReports.UI.XRTableRow vendorNameRow;
        private DevExpress.XtraReports.UI.XRTableCell vendorName;
        private DevExpress.XtraReports.UI.XRTableRow vendorAddressRow;
        private DevExpress.XtraReports.UI.XRTableCell vendorAddress;
        private DevExpress.XtraReports.UI.XRTableRow vendorCityRow;
        private DevExpress.XtraReports.UI.XRTableCell vendorCity;
        private DevExpress.XtraReports.UI.XRTableRow vendorCountryRow;
        private DevExpress.XtraReports.UI.XRTableCell vendorCountry;
        private DevExpress.XtraReports.UI.XRTable customerTable;
        private DevExpress.XtraReports.UI.XRTableRow customerNameRow;
        private DevExpress.XtraReports.UI.XRTableCell customerName;
        private DevExpress.XtraReports.UI.XRTableRow customerAddressRow;
        private DevExpress.XtraReports.UI.XRTableCell customerAddress;
        private DevExpress.XtraReports.UI.XRTableRow customerCityRow;
        private DevExpress.XtraReports.UI.XRTableCell customerCity;
        private DevExpress.XtraReports.UI.XRTableRow customerCountryRow;
        private DevExpress.XtraReports.UI.XRTableCell customerCountry;
        private DevExpress.XtraReports.UI.SubBand SubBand1;
        private DevExpress.XtraReports.UI.XRTable headerTable;
        private DevExpress.XtraReports.UI.XRTableRow headerTableRow;
        private DevExpress.XtraReports.UI.XRTableCell quantityCaption;
        private DevExpress.XtraReports.UI.XRTableCell productNameCaption;
        private DevExpress.XtraReports.UI.XRTableCell unitPriceCaption;
        private DevExpress.XtraReports.UI.XRTableCell unitDiscountCaption;
        private DevExpress.XtraReports.UI.XRTableCell unitTaxCaption;
        private DevExpress.XtraReports.UI.XRTableCell lineTotalCaption;
        private DevExpress.XtraReports.UI.XRLabel invoiceLabel;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRTable totalTable;
        private DevExpress.XtraReports.UI.XRTableRow subtotalRow;
        private DevExpress.XtraReports.UI.XRTableCell subtotalCaption;
        private DevExpress.XtraReports.UI.XRTableCell subtotal;
        private DevExpress.XtraReports.UI.XRTableRow discountRow;
        private DevExpress.XtraReports.UI.XRTableCell discountCaption;
        private DevExpress.XtraReports.UI.XRTableCell discount;
        private DevExpress.XtraReports.UI.XRTableRow taxRow;
        private DevExpress.XtraReports.UI.XRTableCell taxCaption;
        private DevExpress.XtraReports.UI.XRTableCell tax;
        private DevExpress.XtraReports.UI.XRTableRow totalRow;
        private DevExpress.XtraReports.UI.XRTableCell totalCaption;
        private DevExpress.XtraReports.UI.XRTableCell total;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.XRControlStyle baseControlStyle;
        private DevExpress.XtraReports.UI.CalculatedField SubtotalCalcField;
        private DevExpress.XtraReports.UI.CalculatedField DiscountLineTotalCalcField;
        private DevExpress.XtraReports.UI.CalculatedField TaxLineTotalCalcField;
        private DevExpress.XtraReports.UI.CalculatedField TotalCalcField;
        private DevExpress.XtraReports.Parameters.Parameter UnitDiscountParameter;
        private DevExpress.XtraReports.Parameters.Parameter UnitTaxParameter;
        private DevExpress.XtraReports.UI.XRLabel xrLblTelefono;
        private DevExpress.XtraReports.UI.XRLabel xrLblDireccionTienda;
        private DevExpress.XtraReports.UI.XRLabel xrLblNombreTienda;
        private DevExpress.XtraReports.UI.XRLabel xrlblTituloEjercito;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
    }
}
