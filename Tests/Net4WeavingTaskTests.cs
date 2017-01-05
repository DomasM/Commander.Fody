using System;
using System.Linq;
using Commander.Fody;
using FluentAssertions;
using JetBrains.Annotations;
using Mono.Cecil;
using NUnit.Framework;

[TestFixture]
public class Net4WeavingTaskTests : BaseTaskTests
{

    public Net4WeavingTaskTests()
        : base(@"TestAssemblies\AssemblyToProcess\AssemblyToProcessDotNet4.csproj", Console.WriteLine)
    {
    }    

    [Test]
    public void TestCommand_Should_Be_Injected()
    {
        object instance = Assembly.GetInstance("CommandClass");
        var type = instance.GetType();
        var testCommandProperty = type.Properties().Single(prop => prop.Name == "TestCommand");
        testCommandProperty.PropertyType.FullName.Should().Be("System.Windows.Input.ICommand");
        var getter = testCommandProperty.GetGetMethod();
        var setter = testCommandProperty.GetSetMethod();
        getter.As<object>().Should().NotBeNull("property "+testCommandProperty.Name+" should have a getter.");
        setter.As<object>().Should().NotBeNull("property "+testCommandProperty.Name+" should have setter.");


        object instance2 = Assembly.GetInstance("CommandClass2");
        var type2 = instance2.GetType();
        var testCommandProperty2 = type2.Properties().Single(prop => prop.Name == "TestCommand");
        testCommandProperty2.PropertyType.FullName.Should().Be("System.Windows.Input.ICommand");
        var getter2 = testCommandProperty.GetGetMethod();
        var setter2 = testCommandProperty.GetSetMethod();
        getter2.As<object>().Should().NotBeNull("property " + testCommandProperty.Name + " should have a getter.");
        setter2.As<object>().Should().NotBeNull("property " + testCommandProperty.Name + " should have setter.");

    }

}