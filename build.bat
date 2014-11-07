proto_gen_csharp\protoc --descriptor_set_out=test.protobin --include_imports test.proto
proto_gen_csharp\protogen test.protobin
copy test.cs code\testproj