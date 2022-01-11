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
    
    
    /// <summary>
    /// The public interface for SwitchPosition
    /// </summary>
    [DefaultImplementationTypeAttribute(typeof(SwitchPosition))]
    [XmlDefaultImplementationTypeAttribute(typeof(SwitchPosition))]
    [ModelRepresentationClassAttribute("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark#//SwitchPosition")]
    public interface ISwitchPosition : IModelElement, IRailwayElement
    {
        
        /// <summary>
        /// The position property
        /// </summary>
        [DisplayNameAttribute("position")]
        [CategoryAttribute("SwitchPosition")]
        [XmlElementNameAttribute("position")]
        [XmlAttributeAttribute(true)]
        Position Position
        {
            get;
            set;
        }
        
        /// <summary>
        /// The switch property
        /// </summary>
        [DisplayNameAttribute("switch")]
        [CategoryAttribute("SwitchPosition")]
        [XmlElementNameAttribute("switch")]
        [XmlAttributeAttribute(true)]
        [XmlOppositeAttribute("positions")]
        ISwitch Switch
        {
            get;
            set;
        }
        
        /// <summary>
        /// The route property
        /// </summary>
        [BrowsableAttribute(false)]
        [XmlElementNameAttribute("route")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        [XmlAttributeAttribute(true)]
        [XmlOppositeAttribute("follows")]
        IRoute Route
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets fired before the Position property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> PositionChanging;
        
        /// <summary>
        /// Gets fired when the Position property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> PositionChanged;
        
        /// <summary>
        /// Gets fired before the Switch property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> SwitchChanging;
        
        /// <summary>
        /// Gets fired when the Switch property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> SwitchChanged;
        
        /// <summary>
        /// Gets fired before the Route property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> RouteChanging;
        
        /// <summary>
        /// Gets fired when the Route property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> RouteChanged;
    }
}

