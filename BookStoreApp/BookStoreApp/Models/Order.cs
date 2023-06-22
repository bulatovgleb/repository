//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStoreApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public int BookID { get; set; }
        public int OrderCount { get; set; }
        public System.DateTime OrderCreateDate { get; set; }
        public System.DateTime OrderDeliveryDate { get; set; }
        public Nullable<int> OrderStatusID { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Client Client { get; set; }
        public virtual OrderStatu OrderStatu { get; set; }
    }
}