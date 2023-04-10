using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CoreRadzen.Models;
using CoreRadzen.Models.Core;
using Radzen;

namespace CoreRadzen
{
    public partial class GlobalsService
    {

    }

    public class PropertyChangedEventArgs
    {
        public string Name { get; set; }
        public object NewValue { get; set; }
        public object OldValue { get; set; }
        public bool IsGlobal { get; set; }
    }
}
