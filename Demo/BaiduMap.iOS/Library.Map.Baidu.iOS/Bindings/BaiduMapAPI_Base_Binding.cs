using System;

using Foundation;
using ObjCRuntime;
using CoreLocation;

namespace Library.Map.Baidu.Base
{
	// 通知Delegate
	// @interface BMKGeneralDelegate : NSObject
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface BMKGeneralDelegate
	{
		/**
         *返回网络错误
         *@param iError 错误号
         */
		// @optional -(void)onGetNetworkState:(int)iError;
		[Export("onGetNetworkState:")]
		void OnGetNetworkState(int iError);

		/**
         *返回授权验证错误
         *@param iError 错误号 : 为0时验证通过，具体参加BMKPermissionCheckResultCode
         */
		// @optional -(void)onGetPermissionState:(int)iError;
		[Export("onGetPermissionState:")]
		void OnGetPermissionState(int iError);
	}

	// 主引擎类
	// @interface BMKMapManager : NSObject
	[BaseType(typeof(NSObject))]
    interface BMKMapManager{

        /**
         *百度地图SDK所有接口均支持百度坐标（BD09LL）和国测局坐标（GCJ02），用此方法设置您使用的坐标类型.
         *默认是BD09LL（BMK_COORDTYPE_BD09LL）坐标.
         *如果需要使用GCJ02坐标，需要设置CoordinateType为：BMK_COORDTYPE_COMMON.
         */
        //+ (BOOL) setCoordinateTypeUsedInBaiduMapSDK:(BMK_COORD_TYPE) coorType;
		[Static]
		[Export("setCoordinateTypeUsedInBaiduMapSDK:")]
		bool SetCoordinateTypeUsedInBaiduMapSDK(BMKCoordType coorType);

		/**
         *获取百度地图SDK当前使用的经纬度类型
         *@return 经纬度类型
         *+ (BMK_COORD_TYPE) getCoordinateTypeUsedInBaiduMapSDK;
         */
		[Static]
		[Export("getCoordinateTypeUsedInBaiduMapSDK")]
		BMKCoordType CoordinateTypeUsedInBaiduMapSDK { get; }

		/**
         *是否开启打印某模块的log，默认不打印log
         *debug时，建议打开，有利于调试程序；release时建议关闭
         *@param enable 是否开启
         *@param mapModule 地图模块
         *+ (void) logEnable:(BOOL) enable module:(BMKMapModule) mapModule;
         */
		[Static]
		[Export("logEnable:module:")]
		void LogEnable(bool enable, BMKMapModule mapModule);


		/**
        *启动引擎
        *@param key 申请的有效key
        *@param delegate 
        *-(BOOL) start:(NSString*) key generalDelegate:(id<BMKGeneralDelegate>) delegate;
        */
		[Export("start:generalDelegate:")]
		bool Start(string key, BMKGeneralDelegate @delegate);


		/**
         *获取所有在线服务消耗的发送流量,单位：字节
         *-(int) getTotalSendFlaxLength;
         */
		[Export("getTotalSendFlaxLength")]
		int TotalSendFlaxLength { get; }

		/**
         *获取所有在线服务消耗的接收流量,单位：字节
         *-(int) getTotalRecvFlaxLength;
         */
		[Export("getTotalRecvFlaxLength")]
		int TotalRecvFlaxLength { get; }


		/**
        *停止引擎
        *-(BOOL) stop;
        */
		[Export("stop")]
		bool Stop();

	}


	// @interface BMKUserLocation : NSObject
	[BaseType(typeof(NSObject))]
	interface BMKUserLocation
	{
		// 位置更新状态，如果正在更新位置信息，则该值为YES
		// @property (readonly, getter = isUpdating, nonatomic) BOOL updating;
		[Export("updating")]
		bool Updating { [Bind("isUpdating")] get; }

		// 位置信息，尚未定位成功，则该值为nil
		// @property (readonly, nonatomic, strong) CLLocation * location;
		[Export("location", ArgumentSemantic.Strong)]
		CLLocation Location { get; }

		// heading信息，尚未定位成功，则该值为nil
		// @property (readonly, nonatomic, strong) CLHeading * heading;
		[Export("heading", ArgumentSemantic.Strong)]
		CLHeading Heading { get; }

		// 定位标注点要显示的标题信息
		// @property (nonatomic, strong) NSString * title;
		[Export("title", ArgumentSemantic.Strong)]
		string Title { get; set; }

		// 定位标注点要显示的子标题信息.
		// @property (nonatomic, strong) NSString * subtitle;
		[Export("subtitle", ArgumentSemantic.Strong)]
		string Subtitle { get; set; }
	}

	// @interface BMKPlanNode : NSObject
	[BaseType(typeof(NSObject))]
	interface BMKPlanNode
	{
		// @property (nonatomic, strong) NSString * cityName;
		[Export("cityName", ArgumentSemantic.Strong)]
		string CityName { get; set; }

		// @property (assign, nonatomic) NSInteger cityID;
		[Export("cityID")]
		nint CityID { get; set; }

		// @property (nonatomic, strong) NSString * name;
		[Export("name", ArgumentSemantic.Strong)]
		string Name { get; set; }

		// @property (nonatomic) CLLocationCoordinate2D pt;
		[Export("pt", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Pt { get; set; }
	}

	// @interface BMKIndoorPlanNode : NSObject
	[BaseType(typeof(NSObject))]
	interface BMKIndoorPlanNode
	{
		// @property (retain, nonatomic) NSString * floor;
		[Export("floor", ArgumentSemantic.Retain)]
		string Floor { get; set; }

		// @property (nonatomic) CLLocationCoordinate2D pt;
		[Export("pt", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Pt { get; set; }
	}

	// @interface BMKAddressComponent : NSObject
	[BaseType(typeof(NSObject))]
	interface BMKAddressComponent
	{
		// @property (nonatomic, strong) NSString * streetNumber;
		[Export("streetNumber", ArgumentSemantic.Strong)]
		string StreetNumber { get; set; }

		// @property (nonatomic, strong) NSString * streetName;
		[Export("streetName", ArgumentSemantic.Strong)]
		string StreetName { get; set; }

		// @property (nonatomic, strong) NSString * district;
		[Export("district", ArgumentSemantic.Strong)]
		string District { get; set; }

		// @property (nonatomic, strong) NSString * city;
		[Export("city", ArgumentSemantic.Strong)]
		string City { get; set; }

		// @property (nonatomic, strong) NSString * province;
		[Export("province", ArgumentSemantic.Strong)]
		string Province { get; set; }

		// @property (nonatomic, strong) NSString * country;
		[Export("country", ArgumentSemantic.Strong)]
		string Country { get; set; }

		// @property (nonatomic, strong) NSString * countryCode;
		[Export("countryCode", ArgumentSemantic.Strong)]
		string CountryCode { get; set; }

		// @property (nonatomic, strong) NSString * adCode;
		[Export("adCode", ArgumentSemantic.Strong)]
		string AdCode { get; set; }
	}

}