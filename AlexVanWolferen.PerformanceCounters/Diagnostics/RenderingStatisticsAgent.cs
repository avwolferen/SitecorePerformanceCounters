using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Diagnostics
{
    public class RenderingStatisticsAgent
    {

        private void GetStatistics(string siteName)
        {
            HtmlTable htmlTable = new HtmlTable()
            {
                Border = 1,
                CellPadding = 2
            };
            HtmlUtil.AddRow(htmlTable, new string[] { "Rendering", "Site", "Count", "From cache", "Avg. time (ms)", "Avg. items", "Max. time", "Max. items", "Total time", "Total items", "Last run" });
            SortedList<string, Statistics.RenderingData> strs = new SortedList<string, Statistics.RenderingData>();

            foreach (Statistics.RenderingData renderingStatistic in Statistics.RenderingStatistics)
            {
                if (siteName != null && !renderingStatistic.SiteName.Equals(siteName, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                strs.Add(string.Concat(renderingStatistic.SiteName, 255, renderingStatistic.TraceName), renderingStatistic);
            }

            foreach (Statistics.RenderingData value in strs.Values)
            {
                object[] traceName = new object[] { value.TraceName, value.SiteName, value.RenderCount, value.UsedCache, null, null, null, null, null, null, null };
                TimeSpan averageTime = value.AverageTime;
                traceName[4] = averageTime.TotalMilliseconds;
                traceName[5] = value.AverageItemsAccessed;
                averageTime = value.MaxTime;
                traceName[6] = averageTime.TotalMilliseconds;
                traceName[7] = value.MaxItemsAccessed;
                traceName[8] = value.TotalTime;
                traceName[9] = value.TotalItemsAccessed;
                traceName[10] = DateUtil.ToServerTime(value.LastRendered);
                HtmlTableRow htmlTableRow = HtmlUtil.AddRow(htmlTable, traceName);
                for (int i = 2; i < htmlTableRow.Cells.Count; i++)
                {
                    htmlTableRow.Cells[i].Align = "right";
                }
            }

        }

        private void TrackStatistics(Statistics.RenderingData stats)
        {
            var sample = new MetricTelemetry();
            sample.Name = "metric name";
            sample.Value = 42.3;
            telemetryClient.TrackMetric(sample);
        }

        private void ClearStatistics()
        {
            Statistics.Clear();
        }
    }
}