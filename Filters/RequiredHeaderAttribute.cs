#pragma warning disable CS1591
using System;

[AttributeUsage(AttributeTargets.Method)]
public class RequiredHeaderAttribute : Attribute
{
    public bool IsRequired { get; set; }
}