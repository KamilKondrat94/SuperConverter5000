using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace ServerApp.Contracts
{
    [ServiceContract]
    public interface IConvertDollarNumericToText
    {
        [OperationContract]
        [WebInvoke]
        string Convert(string value);

    }
}
