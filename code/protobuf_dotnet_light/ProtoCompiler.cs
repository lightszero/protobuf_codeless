using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBLE
{
    //原型
    public class ProtoType
    {

    }
    public class ProtoType_Value:ProtoType
    {

    }
    public class ProtoType_Array<T>:ProtoType
    {

    }
    public class ProtoMessage:ProtoType
    {
        List<ProtoType> types;
    }
    public class ProtoInstance
    {
        ProtoMessage message;
    }
    public class ProtoCompiler
    {
        public void Build(IList<Token> tokens)
        {

        }

        public Dictionary<string,ProtoMessage> messages =new Dictionary<string,ProtoMessage>();

        public ProtoMessage GetProtoMessage(string name)
        {
            return null;
        }
    }
}
