//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VapeForLife.DBContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class manufacturer_nicotine_relation
    {
        public int IdManufacturer_Nicotine_Relation { get; set; }
        public int IdfManufacturer { get; set; }
        public int IdfNicotine { get; set; }
        public string ArticleSiteUrl { get; set; }
        public string Amount { get; set; }
        public string IdfUnits { get; set; }
        public string Price { get; set; }
    }
}
