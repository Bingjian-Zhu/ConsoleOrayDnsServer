基于.NET Core 2.2的花生壳域名解析服务的控制台程序

用于把花生壳的域名绑定到公网IP上         作用：省钱！！！

可运行在Linux平台上，已上传Docker镜像。

#### 获取docker镜像：
```
docker pull zhubingjian/oray_server:1.1
```
#### 运行方式：
#### 方式1：
把域名和本机的公网IP绑定，运行时输入自己的花生壳账号信息
```
docker run zhubingjian/oray_server:1.1 "花生壳用户名|密码|域名"
```
#### 方式2：
把域名解析到指定的IP地址，运行方式：
```
docker run zhubingjian/oray_server:1.1 "花生壳用户名|密码|域名|IP地址"
```


