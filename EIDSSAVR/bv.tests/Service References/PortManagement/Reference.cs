﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bv.tests.PortManagement {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PortManagement.IPortManagerContract")]
    public interface IPortManagerContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPortManagerContract/GetFreePort", ReplyAction="http://tempuri.org/IPortManagerContract/GetFreePortResponse")]
        ushort GetFreePort(ushort lowerBound, ushort upperBound);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPortManagerContractChannel : bv.tests.PortManagement.IPortManagerContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PortManagerContractClient : System.ServiceModel.ClientBase<bv.tests.PortManagement.IPortManagerContract>, bv.tests.PortManagement.IPortManagerContract {
        
        public PortManagerContractClient() {
        }
        
        public PortManagerContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PortManagerContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PortManagerContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PortManagerContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ushort GetFreePort(ushort lowerBound, ushort upperBound) {
            return base.Channel.GetFreePort(lowerBound, upperBound);
        }
    }
}
