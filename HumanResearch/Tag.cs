using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResearch
{
    public struct Tag
    {
        public string tag { get; set; }
        public string definition { get; set;}

        public Tag(string tag, string definition)
        {
            this.tag = tag;
            this.definition = definition;
        }
    }
}
