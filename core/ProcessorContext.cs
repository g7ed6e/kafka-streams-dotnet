﻿using Confluent.Kafka;
using kafka_stream_core.Kafka;
using kafka_stream_core.Processors;
using kafka_stream_core.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace kafka_stream_core
{
    public class ProcessorContext
    {
        internal string ApplicationId => Configuration.ApplicationId;
        internal IStreamConfig Configuration { get; private set; }
        internal RecordContext RecordContext { get; private set; }
        internal IRecordCollector RecordCollector { get; private set; }

        internal long Timestamp => RecordContext.timestamp;
        internal string Topic => RecordContext.topic;
        internal long Offset => RecordContext.offset;
        internal Partition Partition => RecordContext.partition;

        internal ProcessorContext(IStreamConfig configuration)
        {
            Configuration = configuration;
        }

        internal ProcessorContext UseRecordCollector(IRecordCollector collector)
        {
            if (collector != null)
                RecordCollector = collector;
            return this;
        }

        internal void setRecordMetaData(ConsumeResult<byte[], byte[]> result)
        {
            
        }

        internal StateStore GetStateStore(string queryableStoreName)
        {
            throw new NotImplementedException();
        }
    }
}
