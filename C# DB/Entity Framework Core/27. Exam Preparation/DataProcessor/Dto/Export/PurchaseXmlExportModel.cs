using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Purchase")]
    public class PurchaseXmlExportModel
    {
        public string Card { get; set; }
        public string Cvc { get; set; }

        public string Date { get; set; }

        public GameXmlExportModel Game  { get; set; }


    }
}
