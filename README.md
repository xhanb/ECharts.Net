# ECharts.Net

[![](https://img.shields.io/badge/.Net%20Standard%20-2.0-brightgreen.svg)](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) 
[![Open Source Love svg1](https://badges.frapsoft.com/os/v1/open-source.svg?v=103)](https://github.com/ellerbrock/open-source-badges/)
[![Nuget](https://img.shields.io/nuget/dt/ECharts.Net.svg)](https://www.nuget.org/packages/ECharts.Net)
[![GitHub](https://img.shields.io/github/license/xhanb/ECharts.Net.svg)](https://github.com/xhanb/ECharts.Net/blob/master/LICENSE)

## Tips
Based on [Echarts2.0](https://echarts.baidu.com/echarts2/doc/doc.html)

## How to use?
该类库包含Echarts2.0版本的所有基本类型，操作类**ChartOpertation**提供以下图表的静态方法，未列出的可以自己实现或者创建分支一起完善。
#### 饼状图：ChartPieDataProcess
#### 线性图：ChartLineDataProcess
#### 时间轴线性图：TimeLineChartLineDataProcess
#### 柱状图：ChartBarDataProcess
#### 折柱混搭：ChartBarAndLineDataProcess
#### 条形图：ChartTiaoBarDataProcess
#### 多维条形图：ChartDuoWeiTiaoBarDataProcess

## Demo
```
ChartPieSeries cps = new ChartPieSeries();
cps.name = "pie demo";
cps.radius = 90;
cps.startAngle = 300;
cps.type = "pie"; 

ChartSeriesData csd_pc = new ChartSeriesData();
csd_pc.name = "电脑";
csd_pc.value = "23";

ChartSeriesData csd_phone = new ChartSeriesData();
csd_phone.name = "手机";
csd_phone.value = "88";

List<object> data = new List<object>();
data.Add(csd_pc);
data.Add(csd_phone);

cps.data = data; 

List<string> legend = new List<string>(4);
legend.Add("电脑");
legend.Add("手机"); 

List<ChartPieSeries> cpss = new List<ChartPieSeries>();
cpss.Add(cps); 

string str = ChartOpertation.ChartPieDataProcess(cpss, legend, true, "pie demo", "subtext", true);
```
