using System;
using System.Collections.Generic;
using Quartz;

namespace YellOwl.Scheduler
{
    public class YellScheduleBuilder
    {
        private readonly ICollection<Tuple<IJobDetail, TriggerBuilder>> _jobs;

        public YellScheduleBuilder(ICollection<Tuple<IJobDetail, TriggerBuilder>> jobs)
        {
            _jobs = jobs;
        }

        public void Add<T>(Func<TriggerBuilder, TriggerBuilder> closure) where T : IJob
        {
            _jobs.Add(new Tuple<IJobDetail, TriggerBuilder>(
                JobBuilder.Create<T>().Build(),
                closure(TriggerBuilder.Create())
            ));
        }
    }
}