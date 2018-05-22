using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public interface IStatsService { }
    public class StatsService : IStatsService
    {
        private readonly ConcurrentDictionary<string, Measure> _measures = new ConcurrentDictionary<string, Measure>();
        // public ConcurrentDictionary<string, Measure> Measures { get; private set; } = new ConcurrentDictionary<string, Measure>();
        public void AddMeasure(string item, Measure measure)
        {
            _measures.AddOrUpdate(item, measure, (key, oldVal) => { oldVal.Occurences.AddRange(measure.Occurences); return measure; });
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

    }
}
