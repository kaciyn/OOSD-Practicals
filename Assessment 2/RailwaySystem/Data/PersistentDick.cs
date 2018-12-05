using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using Logic;

namespace Data
{
    class PersistentDick
    {
        [XmlElement("Dictionary")]
        public List<KeyValuePair<string, Train>> XMLDictionaryProxy
        {
            get => new List<KeyValuePair<string, Train>>(Dictionary);
            set
            {
                this.Dictionary = new Dictionary<string, Train>();
                foreach (var pair in value)
                    this.Dictionary[pair.Key] = pair.Value;
            }
        }

        [XmlIgnore] public Dictionary<string, Train> Dictionary { get; set; }
    }
}