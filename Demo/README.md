# 百度地图
1. 注册百度地图的开发这账号。http://lbsyun.baidu.com/。
2. 添加应用，ios和android要分别创建。


## ios 部分
1. 创建一个xamarin.ios工程。
2. 添加一个library-绑定库的项目。
3. 向绑定库里添加百度的api库，base 和map两个基础包。编译属性为：ObjcBindingNativeLibrary
4. 编写百度api库base和map两个对应的ApiDefinition，可以对着.h文件写。编译属性为：ObjcBindingApiDefinition
5. 编写百度api库base和map里边用到的枚举和结构体。ObjcBindingCoreSource。
6. 添加2个.a文件到“本机引用”：libssl和libcrypto。
7. 在xamarin.ios那个工程的AppDelegate进行初始化百度地图的操作:
--- 
	BMKMapManager manager = new BMKMapManager();
	BMKMapManager.SetCoordinateTypeUsedInBaiduMapSDK(BMKCoordType.BMK_COORDTYPE_BD09LL);
	bool result = manager.Start("自己的百度key", new MyBMKGeneralDelegate()); 

8. 在Info.list里添加2个标签：
---
	<key>CFBundleDisplayName</key>      
	<string>iOSBaiduMap</string>          
	<key>Bundle display name</key>           
	<string>BaiduMap</string>  
9. 自定义一个视图添加进去百度地图就OK了
---
	BMKMapView mapView = new BMKMapView();       
	mapView.Frame = View.Frame;        
	mapView.MapType = BMKMapType.BMKMapTypeStandard;       
	View.AddSubview(mapView);        

![](https://github.com/limingnihao/XamarinForms/blob/master/Printscreen/%E7%99%BE%E5%BA%A6%E5%9C%B0%E5%9B%BE-ios.jpg)


## android
