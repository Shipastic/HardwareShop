//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebSite2.Data.interfaces;
//using WebSite2.Data.Models;

//namespace WebSite2.Data.mocks
//{
//    public class MockValue : IValue
//    {

//        private readonly IProperty _prodProperty = new MockProductProperty();

//        public IEnumerable<PropertyValue> propertyValues
//        {
//            get
//            {
//                var propValue = new List<PropertyValue>
//                    {
//                    new PropertyValue
//                    {
//                     PropertyValueId = 1,
//                     Value = "H310CM-DVS",
//                     ProductPropertyId = 1,
//                     ProductProperty = _prodProperty.ProductProperties.First(),
//                    },
//                    new PropertyValue
//                    {
//                     PropertyValueId = 2,
//                     Value = "H310CM-S2",
//                     ProductPropertyId = 1,
//                     ProductProperty = _prodProperty.ProductProperties.First(),
//                    },
//                    new PropertyValue
//                    {
//                     PropertyValueId = 3,
//                     Value = "H310CM-S2 1.1",
//                     ProductPropertyId = 1,
//                     ProductProperty = _prodProperty.ProductProperties.First(),
//                    },
//                   new PropertyValue
//                    {
//                     PropertyValueId = 4,
//                     Value = "ASUS",
//                     ProductPropertyId = 2,                   
//                    },
//                    new PropertyValue
//                    {
//                     PropertyValueId = 5,
//                     Value = "ASRock",
//                     ProductPropertyId = 2,
//                    },
//                    new PropertyValue
//                    {
//                     PropertyValueId = 6,
//                     Value = "GigaByte",
//                     ProductPropertyId = 2,
//                    },
//                    new PropertyValue
//                    {
//                     PropertyValueId = 7,
//                     Value = "2.5 kg",
//                     ProductPropertyId = 3,
//                    },
//                    new PropertyValue
//                    {
//                     PropertyValueId = 8,
//                     Value = "1.8 rg",
//                     ProductPropertyId = 3,
//                    },
//                    new PropertyValue
//                    {
//                     PropertyValueId = 9,
//                     Value = "0.7 kg",
//                     ProductPropertyId = 3,
//                    },new PropertyValue
//                    {
//                     PropertyValueId = 10,
//                     Value = "0.4 kg",
//                     ProductPropertyId = 3,
//                    },
//                    };
//                return propValue;
//            }
//        }
//        public IEnumerable<PropertyValue> GetFavProducts { get; set; }

//        public PropertyValue GetObjectValue(int propValueId)
//        {
//            throw new NotImplementedException();
//        }

//    }
//}
