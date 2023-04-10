using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CoreRadzen.Models
{
    public partial class ApplicationUser
    {
        public string Name { get; set; }
    }
}
