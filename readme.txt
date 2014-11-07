1.proto_gen_csharp
是protobuf 和 protobuf-port 的生成器
调用build.bat
将把test.proto 编译 生成test.cs
并将生成的test.cs copy到 code\testproj


2.然后编译运行 code\testproj 会生成 test.bin
并测试使用 test.protobin 读取出 test.bin的内容