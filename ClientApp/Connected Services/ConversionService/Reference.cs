﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientApp.ConversionService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ConversionService.IConvertDollarNumericToText")]
    public interface IConvertDollarNumericToText {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvertDollarNumericToText/Convert", ReplyAction="http://tempuri.org/IConvertDollarNumericToText/ConvertResponse")]
        string Convert(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvertDollarNumericToText/Convert", ReplyAction="http://tempuri.org/IConvertDollarNumericToText/ConvertResponse")]
        System.Threading.Tasks.Task<string> ConvertAsync(string value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IConvertDollarNumericToTextChannel : ClientApp.ConversionService.IConvertDollarNumericToText, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConvertDollarNumericToTextClient : System.ServiceModel.ClientBase<ClientApp.ConversionService.IConvertDollarNumericToText>, ClientApp.ConversionService.IConvertDollarNumericToText {
        
        public ConvertDollarNumericToTextClient() {
        }
        
        public ConvertDollarNumericToTextClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConvertDollarNumericToTextClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConvertDollarNumericToTextClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConvertDollarNumericToTextClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Convert(string value) {
            return base.Channel.Convert(value);
        }
        
        public System.Threading.Tasks.Task<string> ConvertAsync(string value) {
            return base.Channel.ConvertAsync(value);
        }
    }
}
