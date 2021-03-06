//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using NMF.Collections.Generic;
using NMF.Collections.ObjectModel;
using NMF.Expressions;
using NMF.Expressions.Linq;
using NMF.Models;
using NMF.Models.Collections;
using NMF.Models.Expressions;
using NMF.Models.Meta;
using NMF.Models.Repository;
using NMF.Serialization;
using NMF.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Benchmark.Railway
{
    
    
    public class SwitchPositionsCollection : ObservableOppositeList<ISwitch, ISwitchPosition>
    {
        
        public SwitchPositionsCollection(ISwitch parent) : 
                base(parent)
        {
        }
        
        private void OnItemDeleted(object sender, System.EventArgs e)
        {
            this.Remove(((ISwitchPosition)(sender)));
        }
        
        protected override void SetOpposite(ISwitchPosition item, ISwitch parent)
        {
            if ((parent != null))
            {
                item.Deleted += this.OnItemDeleted;
                item.Switch = parent;
            }
            else
            {
                item.Deleted -= this.OnItemDeleted;
                if ((item.Switch == this.Parent))
                {
                    item.Switch = parent;
                }
            }
        }
    }
}

