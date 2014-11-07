using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testproj
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试用生成的结构 序列化
            Console.WriteLine("测试用生成的结构 序列化");
            TestMsg.Builder msgbuild = new TestMsg.Builder();
            msgbuild.Query = "testtest0001";
            msgbuild.Pagenumber = 448;
            msgbuild.ResultPerPage = 884;

            using (System.IO.Stream s = System.IO.File.Create("../../../../test.bin"))
            {
                msgbuild.Build().WriteTo(s);
            }

            //测试解析并dump DescriptorSet
            Console.WriteLine("测试解析并dump DescriptorSet");
            byte[] descriptors = System.IO.File.ReadAllBytes("../../../../test.protobin");

            Google.ProtocolBuffers.DescriptorProtos.FileDescriptorSet set = Google.ProtocolBuffers.DescriptorProtos.FileDescriptorSet.ParseFrom(descriptors);

            Google.ProtocolBuffers.Descriptors.MessageDescriptor messagetype = null;
            foreach (var s in set.FileList)
            {
                foreach (Google.ProtocolBuffers.DescriptorProtos.DescriptorProto msg in s.MessageTypeList)
                {
                    Console.WriteLine("got message:" + msg.Name);
                    foreach (var f in msg.FieldList)
                    {
                        Console.WriteLine("   field:" + f.Name + "," + f.Number + " " + f.Label + " def=" + f.HasDefaultValue + " opt=" + f.HasOptions);
                    }
                    if (msg.Name == "TestMsg")
                    {
                        messagetype = msg.DescriptorForType;
                    }
                }
            }

            //测试DynamicMessage
            Console.WriteLine("测试DynamicMessage");
            byte[] data = System.IO.File.ReadAllBytes("../../../../test.bin");
            Google.ProtocolBuffers.DynamicMessage message = Google.ProtocolBuffers.DynamicMessage.ParseFrom(messagetype, data);

            foreach (var info in message.AllFields)
            {
                Console.WriteLine("read:" + info.Key.Name + "," + info.Value.ToString());
            }
            foreach (var info in message.UnknownFields.FieldDictionary)
            {
                Console.WriteLine("read unknows:" + info.Key + "," + info.Value.ToString());
            }
            //Console.WriteLine(fileDesc.Name + "," + fileDesc.MessageTypes.Count);

            Console.WriteLine("观测到DynamicMessage有bug,作者一年没更新了,要用还得自己修复一下bug");
            Console.ReadLine();
        }
    }
}
