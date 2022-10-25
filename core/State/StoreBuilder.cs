﻿using Streamiz.Kafka.Net.Processors;
using System;
using System.Collections.Generic;

namespace Streamiz.Kafka.Net.State
{
    /// <summary>
    /// Build a <see cref="IStateStore"/> wrapped with optional caching and logging.
    /// </summary>
    public interface StoreBuilder
    {
        /// <summary>
        /// Is window store or not
        /// </summary>
        bool IsWindowStore { get; }
        /// <summary>
        /// retention (in milliseconds) of the state store 
        /// </summary>
        long RetentionMs { get; }
        /// <summary>
        /// Configuration of the changelog topic
        /// </summary>
        IDictionary<string, string> LogConfig { get; }
        /// <summary>
        /// Logging enabled or not
        /// </summary>
        bool LoggingEnabled { get; }
        /// <summary>
        /// Name of the state store
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Build the state store
        /// </summary>
        /// <returns></returns>
        IStateStore Build();
    }

    /// <summary>
    /// Build a <see cref="IStateStore"/> wrapped with optional caching and logging.
    /// </summary>
    /// <typeparam name="T">the type of store to build</typeparam>
    public interface StoreBuilder<T>  : StoreBuilder
        where T : IStateStore
    {
        /// <summary>
        /// Activate caching
        /// </summary>
        /// <returns></returns>
        StoreBuilder<T> WithCachingEnabled();
        /// <summary>
        /// Disable caching
        /// </summary>
        /// <returns></returns>
        StoreBuilder<T> WithCachingDisabled();
        /// <summary>
        /// Activate logging
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        StoreBuilder<T> WithLoggingEnabled(IDictionary<String, String> config);
        /// <summary>
        /// Disable logging
        /// </summary>
        /// <returns></returns>
        StoreBuilder<T> WithLoggingDisabled();
        /// <summary>
        /// Build the state store
        /// </summary>
        /// <returns></returns>
        new T Build();
    }
}
