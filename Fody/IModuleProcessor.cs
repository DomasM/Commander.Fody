﻿using Mono.Cecil;

namespace Commander.Fody
{
    public interface IModuleProcessor
    {
        IFodyLogger Logger { get; }
        void Execute();
    }
}