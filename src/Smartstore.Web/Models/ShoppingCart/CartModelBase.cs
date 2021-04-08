﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smartstore.Core.Catalog.Products;
using Smartstore.Core.Localization;
using Smartstore.Web.Modelling;
using Smartstore.Web.Models.Catalog;
using Smartstore.Web.Models.Media;

namespace Smartstore.Web.Models.ShoppingCart
{
    public abstract class CartModelBase : ModelBase
    {
        public virtual IEnumerable<CartEntityModelBase> Items { get; }

        public bool ShowSku { get; set; }
        public bool ShowProductImages { get; set; }
        public bool ShowProductBundleImages { get; set; }
        public bool IsEditable { get; set; }
        public int BundleThumbSize { get; set; }
        public bool DisplayShortDesc { get; set; }
        public List<string> Warnings { get; set; } = new();
    }

    public abstract class CartEntityModelBase : EntityModelBase, IQuantityInput
    {
        public string Sku { get; set; }
        public ImageModel Image { get; set; } = new();

        public int ProductId { get; set; }
        public LocalizedValue<string> ProductName { get; set; }
        public string ProductSeName { get; set; }
        public string ProductUrl { get; set; }
        public ProductType ProductType { get; set; }
        public bool VisibleIndividually { get; set; }
        public string UnitPrice { get; set; }
        public string SubTotal { get; set; }
        public string Discount { get; set; }

        public int EnteredQuantity { get; set; }
        public LocalizedValue<string> QuantityUnitName { get; set; }
        public List<SelectListItem> AllowedQuantities { get; set; } = new();
        public int MinOrderAmount { get; set; }
        public int MaxOrderAmount { get; set; }
        public int QuantityStep { get; set; }
        public QuantityControlType QuantiyControlType { get; set; }

        public string AttributeInfo { get; set; }
        public string RecurringInfo { get; set; }
        public List<string> Warnings { get; set; } = new();
        public LocalizedValue<string> ShortDesc { get; set; }

        public bool BundlePerItemPricing { get; set; }
        public bool BundlePerItemShoppingCart { get; set; }
        public BundleItemModel BundleItem { get; set; } = new();

        public virtual IEnumerable<CartEntityModelBase> ChildItems { get; }
        public DateTime CreatedOnUtc { get; set; }
    }

    public partial class BundleItemModel : EntityModelBase
    {
        public string PriceWithDiscount { get; set; }
        public int DisplayOrder { get; set; }
        public bool HideThumbnail { get; set; }
    }
}