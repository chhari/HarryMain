﻿using System;
using FFImageLoading.Work;
using FFImageLoading.Config;

namespace FFImageLoading.DataResolvers
{
    public class DataResolverFactory : IDataResolverFactory
    {
        static DataResolverFactory instance;
        internal static DataResolverFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataResolverFactory();
                return instance;
            }
        }

        public virtual IDataResolver GetResolver(string identifier, ImageSource source, TaskParameter parameters, Configuration configuration)
        {
            switch (source)
            {
                case ImageSource.ApplicationBundle:
                case ImageSource.Filepath:
                    return new FileDataResolver();
                case ImageSource.CompiledResource:
                    return new BundleDataResolver();
                case ImageSource.Url:
                    return new UrlDataResolver(configuration);
                case ImageSource.Stream:
                    return new StreamDataResolver();
                default:
                    throw new ArgumentException("Unknown type of ImageSource");
            }
        }
    }
}

