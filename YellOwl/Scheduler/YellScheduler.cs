using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace YellOwl.Scheduler
{
    public class YellScheduler
    {
        private readonly ICollection<Tuple<IJobDetail, TriggerBuilder>> _jobs;
        private readonly IScheduler _scheduler;
        private readonly YellScheduleBuilder _builder;

        public YellScheduler()
        {
            _jobs = new List<Tuple<IJobDetail, TriggerBuilder>>();
            _scheduler = new StdSchedulerFactory().GetScheduler();
            _builder = new YellScheduleBuilder(_jobs);
        }

        public YellScheduler BuildJobs(Action<YellScheduleBuilder> closure)
        {
            closure(_builder);
            return this;
        }

        public void Start()
        {
            _scheduler.Start();

            foreach (var tuple in _jobs)
            {
                Task.Run(()
                    => _scheduler.ScheduleJob(tuple.Item1, tuple.Item2.ForJob(tuple.Item1).Build()));
            }
        }
    }
}