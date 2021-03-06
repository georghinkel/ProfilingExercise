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
    /// The default implementation of the Semaphore class
    /// </summary>
    [XmlNamespaceAttribute("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark")]
    [XmlNamespacePrefixAttribute("hu.bme.mit.trainbenchmark")]
    [ModelRepresentationClassAttribute("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark#//Semaphore")]
    [DebuggerDisplayAttribute("Semaphore {Id}")]
    public partial class Semaphore : RailwayElement, ISemaphore, IModelElement
    {
        
        /// <summary>
        /// The backing field for the Signal property
        /// </summary>
        [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
        private Signal _signal;
        
        private static Lazy<ITypedElement> _signalAttribute = new Lazy<ITypedElement>(RetrieveSignalAttribute);
        
        private static IClass _classInstance;
        
        /// <summary>
        /// The signal property
        /// </summary>
        [DisplayNameAttribute("signal")]
        [CategoryAttribute("Semaphore")]
        [XmlElementNameAttribute("signal")]
        [XmlAttributeAttribute(true)]
        public Signal Signal
        {
            get
            {
                return this._signal;
            }
            set
            {
                if ((this._signal != value))
                {
                    Signal old = this._signal;
                    ValueChangedEventArgs e = new ValueChangedEventArgs(old, value);
                    this.OnSignalChanging(e);
                    this.OnPropertyChanging("Signal", e, _signalAttribute);
                    this._signal = value;
                    this.OnSignalChanged(e);
                    this.OnPropertyChanged("Signal", e, _signalAttribute);
                }
            }
        }
        
        /// <summary>
        /// Gets the Class model for this type
        /// </summary>
        public new static IClass ClassInstance
        {
            get
            {
                if ((_classInstance == null))
                {
                    _classInstance = ((IClass)(MetaRepository.Instance.Resolve("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark#//Semaphore")));
                }
                return _classInstance;
            }
        }
        
        /// <summary>
        /// Gets fired before the Signal property changes its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> SignalChanging;
        
        /// <summary>
        /// Gets fired when the Signal property changed its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> SignalChanged;
        
        private static ITypedElement RetrieveSignalAttribute()
        {
            return ((ITypedElement)(((ModelElement)(Benchmark.Railway.Semaphore.ClassInstance)).Resolve("signal")));
        }
        
        /// <summary>
        /// Raises the SignalChanging event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnSignalChanging(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.SignalChanging;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Raises the SignalChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnSignalChanged(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.SignalChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Resolves the given attribute name
        /// </summary>
        /// <returns>The attribute value or null if it could not be found</returns>
        /// <param name="attribute">The requested attribute name</param>
        /// <param name="index">The index of this attribute</param>
        protected override object GetAttributeValue(string attribute, int index)
        {
            if ((attribute == "SIGNAL"))
            {
                return this.Signal;
            }
            return base.GetAttributeValue(attribute, index);
        }
        
        /// <summary>
        /// Sets a value to the given feature
        /// </summary>
        /// <param name="feature">The requested feature</param>
        /// <param name="value">The value that should be set to that feature</param>
        protected override void SetFeature(string feature, object value)
        {
            if ((feature == "SIGNAL"))
            {
                this.Signal = ((Signal)(value));
                return;
            }
            base.SetFeature(feature, value);
        }
        
        /// <summary>
        /// Gets the property expression for the given attribute
        /// </summary>
        /// <returns>An incremental property expression</returns>
        /// <param name="attribute">The requested attribute in upper case</param>
        protected override NMF.Expressions.INotifyExpression<object> GetExpressionForAttribute(string attribute)
        {
            if ((attribute == "SIGNAL"))
            {
                return Observable.Box(new SignalProxy(this));
            }
            return base.GetExpressionForAttribute(attribute);
        }
        
        /// <summary>
        /// Gets the Class for this model element
        /// </summary>
        public override IClass GetClass()
        {
            if ((_classInstance == null))
            {
                _classInstance = ((IClass)(MetaRepository.Instance.Resolve("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark#//Semaphore")));
            }
            return _classInstance;
        }
        
        /// <summary>
        /// Represents a proxy to represent an incremental access to the signal property
        /// </summary>
        private sealed class SignalProxy : ModelPropertyChange<ISemaphore, Signal>
        {
            
            /// <summary>
            /// Creates a new observable property access proxy
            /// </summary>
            /// <param name="modelElement">The model instance element for which to create the property access proxy</param>
            public SignalProxy(ISemaphore modelElement) : 
                    base(modelElement, "signal")
            {
            }
            
            /// <summary>
            /// Gets or sets the value of this expression
            /// </summary>
            public override Signal Value
            {
                get
                {
                    return this.ModelElement.Signal;
                }
                set
                {
                    this.ModelElement.Signal = value;
                }
            }
        }
    }
}

