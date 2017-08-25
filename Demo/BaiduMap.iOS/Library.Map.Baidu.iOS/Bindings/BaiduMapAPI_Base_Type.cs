using System;
using System.Runtime.InteropServices;
using CoreLocation;
using Foundation;

namespace Library.Map.Baidu.Base
{
	public enum BMKMapModule : uint
	{
		BMKMapModuleTile = 0 //瓦片图模块
	}

    public enum BMKCoordType : uint
	{
		BMK_COORDTYPE_GPS = 0, //GPS设备采集的原始GPS坐标（WGS-84）
		BMK_COORDTYPE_COMMON,  //GCJ坐标，google地图、soso地图、aliyun地图、mapabc地图和amap地图所用坐标
		BMK_COORDTYPE_BD09LL,  //bd09ll 百度经纬度坐标
	}

    public enum BMKMapType : uint
	{
		BMKMapTypeNone = 0,               //< 空白地图
		BMKMapTypeStandard = 1,           //< 标准地图
		BMKMapTypeSatellite = 2,          //< 卫星地图
	}

    public enum BMKErrorCode : uint
	{
		BMKErrorOk = 0,                         //< 正确，无错误
		BMKErrorConnect = 2,                    //< 网络连接错误
		BMKErrorData = 3,                       //< 数据错误
		BMKErrorRouteAddr = 4,                  //<起点或终点选择(有歧义)
		BMKErrorResultNotFound = 100,           //< 搜索结果未找到
		BMKErrorLocationFailed = 200,           //< 定位失败
		BMKErrorPermissionCheckFailure = 300,   //< 百度地图API授权Key验证失败
		BMKErrorParse = 310                     //< 数据解析失败
	}

    //鉴权结果状态码
    public enum BMKPermissionCheckResultCode : int
	{
		E_PERMISSIONCHECK_CONNECT_ERROR = -300, //链接服务器错误
		E_PERMISSIONCHECK_DATA_ERROR = -200,    //服务返回数据异常
		E_PERMISSIONCHECK_OK = 0,               // 授权验证通过
		E_PERMISSIONCHECK_KEY_ERROR = 101,      //ak不存在
		E_PERMISSIONCHECK_MCODE_ERROR = 102,    //mcode签名值不正确
		E_PERMISSIONCHECK_UID_KEY_ERROR = 200,  // APP不存在，AK有误请检查再重试
		E_PERMISSIONCHECK_KEY_FORBIDEN = 201,   // APP被用户自己禁用，请在控制台解禁
         /*
          *更多鉴权状态码请参考：
          *http://developer.baidu.com/map/index.php?title=lbscloud/api/appendix
          */
	}

    //检索结果状态码
    public enum BMKSearchErrorCode : uint
	{
		BMK_SEARCH_NO_ERROR = 0,//<检索结果正常返回
		BMK_SEARCH_AMBIGUOUS_KEYWORD,//<检索词有岐义
		BMK_SEARCH_AMBIGUOUS_ROURE_ADDR,//<检索地址有岐义
		BMK_SEARCH_NOT_SUPPORT_BUS,//<该城市不支持公交搜索
		BMK_SEARCH_NOT_SUPPORT_BUS_2CITY,//<不支持跨城市公交
		BMK_SEARCH_RESULT_NOT_FOUND,//<没有找到检索结果
		BMK_SEARCH_ST_EN_TOO_NEAR,//<起终点太近
		BMK_SEARCH_KEY_ERROR,//<key错误
		BMK_SEARCH_NETWOKR_ERROR,//网络连接错误
		BMK_SEARCH_NETWOKR_TIMEOUT,//网络连接超时
		BMK_SEARCH_PERMISSION_UNFINISHED,//还未完成鉴权，请在鉴权通过后重试
		BMK_SEARCH_INDOOR_ID_ERROR,//室内图ID错误
		BMK_SEARCH_FLOOR_ERROR,//室内图检索楼层错误
		BMK_SEARCH_INDOOR_ROUTE_NO_IN_BUILDING,//起终点不在支持室内路线的室内图内
		BMK_SEARCH_INDOOR_ROUTE_NO_IN_SAME_BUILDING,//起终点不在同一个室内
		BMK_SEARCH_PARAMETER_ERROR,//参数错误
	}

    //调起百度地图结果状态码
    public enum BMKOpenErrorCode : uint
	{
		BMK_OPEN_NO_ERROR = 0,//<正常
		BMK_OPEN_WEB_MAP,//打开的是web地图
		BMK_OPEN_OPTION_NULL,//<传入的参数为空
		BMK_OPEN_NOT_SUPPORT,//<没有安装百度地图，或者版本太低
		BMK_OPEN_POI_DETAIL_UID_NULL,//<poi详情 poiUid为空
		BMK_OPEN_POI_NEARBY_KEYWORD_NULL,//<poi周边 keyWord为空
		BMK_OPEN_ROUTE_START_ERROR,//<路线起点有误
		BMK_OPEN_ROUTE_END_ERROR,//<路线终点有误
		BMK_OPEN_PANORAMA_UID_ERROR,//<调起全景 poiUid不正确
		BMK_OPEN_PANORAMA_ABSENT,//<调起全景 此处不支持全景
		BMK_OPEN_PERMISSION_UNFINISHED,//还未完成鉴权，请在鉴权通过后重试
		BMK_OPEN_KEY_ERROR,//<app key错误
		BMK_OPEN_NETWOKR_ERROR,//网络连接错误
	}

	// 表示一个经纬度范围
	[StructLayout(LayoutKind.Sequential)]
	public struct BMKCoordinateSpan
	{
		public double latitudeDelta; //< 纬度范围

		public double longitudeDelta; //< 经度范围
	}

	//表示一个经纬度区域
	[StructLayout(LayoutKind.Sequential)]
	public struct BMKCoordinateBounds
	{
		public CLLocationCoordinate2D northEast; //< 东北角点经纬度坐标

		public CLLocationCoordinate2D southWest; //< 西南角点经纬度坐标
	}

	//表示一个经纬度区域
	[StructLayout(LayoutKind.Sequential)]
	public struct BMKCoordinateRegion
	{
		public CLLocationCoordinate2D center;   //< 中心点经纬度坐标

		public BMKCoordinateSpan span;          //< 经纬度范围
	}



	//表示一个经纬度坐标点
	[StructLayout(LayoutKind.Sequential)]
	public struct BMKGeoPoint
	{
		public int latitudeE6;       //< 纬度，乘以1e6之后的值

		public int longitudeE6;      //< 经度，乘以1e6之后的值
	}

	//地理坐标点，用直角地理坐标表示
    [StructLayout(LayoutKind.Sequential)]
	public struct BMKMapPoint
	{
		public double x;    //< 横坐标

		public double y;    //< 纵坐标
	}

	//矩形大小，用直角地理坐标表示
    [StructLayout(LayoutKind.Sequential)]
	public struct BMKMapSize
	{
		public double width;    //< 宽度

		public double height;   //< 高度
	}

	//矩形，用直角地理坐标表示
    [StructLayout(LayoutKind.Sequential)]
	public struct BMKMapRect
	{
		public BMKMapPoint origin;   //< 屏幕左上点对应的直角地理坐标

		public BMKMapSize size;      //< 坐标范围
	}

}
