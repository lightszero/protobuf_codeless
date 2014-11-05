1.proto_gen_csharp
是protobuf 和 protobuf-net 的生成器
调用build.bat
将把test.proto 编译 生成test.cs

2.将生成的test.cs copy到 code\testproj
然后编译运行 code\testproj 会生成 test.bin

为该协议的打包结果

3.将测试使用 test.proto 读取出 test.bin的内容