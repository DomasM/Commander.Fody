﻿using Commander.Fody;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AssemblyDefinitionExtensions
    {    
        [Test]
        public void GetTargetFramework_From_WindowsPhone8_Assembly()
        {
            var projectPath = @"TestAssemblies\AssemblyToProcessPhone8\AssemblyToProcessPhone8.csproj";
#if (!DEBUG)

            projectPath = projectPath.Replace("Debug", "Release");
#endif
            var moduleDefinition = WeaverHelper.GetModuleDefinition(projectPath);
            var targetFramework = moduleDefinition.Assembly.GetTargetFramework();
            targetFramework.Should().Be("WindowsPhone,Version=v8.0");
            //weaverHelper.Assembly.

        }
    }
}