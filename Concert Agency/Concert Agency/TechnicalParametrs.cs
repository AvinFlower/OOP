using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Concert_Agency
{
    public class TechnicalParameters : Entity
    {
        public string AttributeParameters { get; set; }
        public void Add(string AttributeParameters)
        {
            this.AttributeParameters = AttributeParameters;
        }
    }
}