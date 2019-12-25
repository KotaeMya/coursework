using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace courseworkWPF.Model
{
    [XmlRoot(Namespace = "http://cpe.mitre.org/language/2.0")]
    public class OneEventLog
    {
        [XmlAttribute("Event")]
        public string Event { get; set; }
        [XmlAttribute("EventLog")]
        public string EventLog { get; set; }
    }
}
