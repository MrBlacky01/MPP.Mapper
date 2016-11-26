﻿using System;
using DtoMapper.Compiler;

namespace DtoMapper
{
    public class Mapper : IMapper
    {
        private readonly IFunctionCompiler functionCompiler;

        public Mapper() : this(new CashFunctionCompiler())
        {

        }

        public Mapper(IFunctionCompiler functionaCompiler)
        {
            if(functionaCompiler == null)
                throw new ArgumentNullException(nameof(functionaCompiler));

            this.functionCompiler = functionaCompiler;
        }

        public TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            Func<TSource, TDestination> function = functionCompiler.CompileMappingFunction<TSource, TDestination>();
            return function.Invoke(source);
        }
    }
}
