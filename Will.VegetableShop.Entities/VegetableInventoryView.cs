using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Data;

namespace Will.VegetableShop.Entities
{
    [DataContract]
    public class VegetableInventoryView
    {
        #region 公共属性
        private String _inventoryId = "";

        /// <summary>
        ///     GUID
        /// </summary>
        /// <field>invenory_id</field>
        [DataMember]
        public String InventoryId
        {
            get { return _inventoryId; }
            set { _inventoryId = value; }
        }

        private String _vegetableId = "";

        /// <summary>
        ///     菜品ID
        /// </summary>
        /// <field>vegetable_id</field>
        [DataMember]
        public String VegetableId
        {
            get { return _vegetableId; }
            set { _vegetableId = value; }
        }

        private String _title = "";

        /// <summary>
        ///     菜品标题
        /// </summary>
        /// <field>title</field>
        [DataMember]
        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private String _categoryId = "";

        /// <summary>
        ///     分类ID
        /// </summary>
        /// <field>category_id</field>
        [DataMember]
        public String CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        private String _categoryTitle = "";

        /// <summary>
        ///     分类标题
        /// </summary>
        /// <field>category_title</field>
        [DataMember]
        public String CategoryTitle
        {
            get { return _categoryTitle; }
            set { _categoryTitle = value; }
        }

        private decimal _profitMargin = 0;

        /// <summary>
        ///     利润率
        /// </summary>
        /// <field>profit_margin</field>
        [DataMember]
        public decimal ProfitMargin
        {
            get { return _profitMargin; }
            set { _profitMargin = value; }
        }

        private decimal _amount = 0;

        /// <summary>
        ///     数量
        /// </summary>
        /// <field>amount</field>
        [DataMember]
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private decimal _purchasePrice = 0;

        /// <summary>
        ///     采购单价
        /// </summary>
        /// <field>purchase_price</field>
        [DataMember]
        public decimal PurchasePrice
        {
            get { return _purchasePrice; }
            set { _purchasePrice = value; }
        }

        private decimal _sellPrice = 0;

        /// <summary>
        ///     销售单价
        /// </summary>
        /// <field>sell_price</field>
        [DataMember]
        public decimal SellPrice
        {
            get { return _sellPrice; }
            set { _sellPrice = value; }
        }

        private decimal _discountPrice = 0;

        /// <summary>
        ///     优惠单价
        /// </summary>
        /// <field>discount_price</field>
        [DataMember]
        public decimal DiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
        }

        private decimal _marketPrice = 0;

        /// <summary>
        ///     市场价
        /// </summary>
        /// <field>market_price</field>
        [DataMember]
        public decimal MarketPrice
        {
            get { return _marketPrice; }
            set { _marketPrice = value; }
        }

        private decimal _purchaseMoney = 0;

        /// <summary>
        ///     采购金额，采购单价*数量
        /// </summary>
        /// <field>purchase_money</field>
        [DataMember]
        public decimal PurchaseMoney
        {
            get { return _purchaseMoney; }
            set { _purchaseMoney = value; }
        }

        private decimal _sellMoney = 0;

        /// <summary>
        ///     出售金额，如果优惠单价大于0，优惠单价*数量，否则出售单价*数量
        /// </summary>
        /// <field>sell_money</field>
        [DataMember]
        public decimal SellMoney
        {
            get { return _sellMoney; }
            set { _sellMoney = value; }
        }

        private Boolean _isDiscount = false;

        /// <summary>
        ///     是否有优惠，优惠价格>0是有优惠，否则无优惠
        /// </summary>
        /// <field>is_discount</field>
        [DataMember]
        public Boolean IsDiscount
        {
            get { return _isDiscount; }
            set { _isDiscount = value; }
        }

        private String _description = "";

        /// <summary>
        ///     描述说明
        /// </summary>
        /// <field>description</field>
        [DataMember]
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private DateTime _inputTime = DateTime.Now;

        /// <summary>
        ///     登记时间
        /// </summary>
        /// <field>input_time</field>
        [DataMember]
        public DateTime InputTime
        {
            get { return _inputTime; }
            set { _inputTime = value; }
        }

        private DateTime _lastUpdateTime = DateTime.Now;

        /// <summary>
        ///     最后修改时间
        /// </summary>
        /// <field>last_update_time</field>
        [DataMember]
        public DateTime LastUpdateTime
        {
            get { return _lastUpdateTime; }
            set { _lastUpdateTime = value; }
        }
        #endregion

        #region 生成实例
        #endregion

        #region 筛选条件
        [DataContract]
        public class Filter
        {
            private String _inventoryId = "";

            /// <summary>
            ///     GUID
            /// </summary>
            /// <field>invenory_id</field>
            [DataMember]
            public String InventoryId
            {
                get { return _inventoryId; }
                set { _inventoryId = value; }
            }

            private String _vegetableId = "";

            /// <summary>
            ///     菜品ID
            /// </summary>
            /// <field>vegetable_id</field>
            [DataMember]
            public String VegetableId
            {
                get { return _vegetableId; }
                set { _vegetableId = value; }
            }

            private String _categoryId = "";

            /// <summary>
            ///     分类ID
            /// </summary>
            /// <field>category_id</field>
            [DataMember]
            public String CategoryId
            {
                get { return _categoryId; }
                set { _categoryId = value; }
            }
        }
        #endregion
    }
}
