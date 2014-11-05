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
            test.TestMsg obj =new test.TestMsg();
            obj.query = "testtest0001";
            obj.page_number = 448;
            obj.result_per_page = 884;
            using (System.IO.Stream s = System.IO.File.Create("../../../../data/test.bin"))
            {
                ProtoBuf.Serializer.Serialize<test.TestMsg>(s, obj);
            }
        }
    }
}
