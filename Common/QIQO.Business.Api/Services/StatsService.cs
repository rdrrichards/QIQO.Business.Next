using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public interface IStatsService {
        void AddMeasure(string item, Measure measure);
    }
    public class StatsService : IStatsService
    {
        public ConcurrentDictionary<string, Measure> Measures { get; } = new ConcurrentDictionary<string, Measure>();

        public void AddMeasure(string item, Measure measure)
        {
            Measures.AddOrUpdate(item, measure, (key, oldVal) => {
                oldVal.Occurences.Add(measure.Occurences[0]);
                return oldVal;
                });
        }
    }

    public class Measure
    {
        public Measure(string measureName)
        {
            MeasureName = measureName;
            MeasureDesc = string.Empty;
        }
        public Measure(string measureName, string measureDesc)
        {
            MeasureName = measureName;
            MeasureDesc = measureDesc;
        }
        public Measure(string measureName, string measureDesc, Occurence occurence) : this(measureName, measureDesc)
        {
            Occurences.Add(occurence);
        }
        public Measure(string measureName, string measureDesc, List<Occurence> occurences) : this(measureName, measureDesc)
        {
            Occurences.AddRange(occurences);
        }
        public Measure(string measureName, Occurence occurence) : this(measureName, string.Empty, occurence) { }
        public Measure(string measureName, List<Occurence> occurences) : this(measureName, string.Empty, occurences) { }

        public string MeasureName { get; }
        public string MeasureDesc { get; }
        public List<Occurence> Occurences { get; private set; } = new List<Occurence>();
    }
    public class Occurence
    {
        public Occurence(DateTime dateTime, object value)
        {
            OccurenceDateTime = dateTime;
            OccurenceValue = value;
        }
        public DateTime OccurenceDateTime { get; }
        public object OccurenceValue { get; }
    }
}
