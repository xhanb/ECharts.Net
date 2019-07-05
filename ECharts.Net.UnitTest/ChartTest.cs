using System.Collections.Generic;
using ECharts.Net.ChartSeries;
using Xunit;

namespace ECharts.Net.UnitTest
{
    public class ChartTest
    {
        [Fact]
        public void ChartPieTest()
        {
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
            var str = ChartOpertation.ChartPieDataProcess(cpss, legend, true, "pie demo", "subtext", true);
            Assert.NotNull(str);
        }
    }
}
