﻿using Microsoft.Extensions.Options;

namespace CommonScenarios;

public class MyNameServiceUsingDoubleNameOptions : IMyNameService
{
    private readonly MyDoubleNameOptions _options;

    public MyNameServiceUsingDoubleNameOptions(IOptions<MyDoubleNameOptions> options)
    {
        _options = options.Value;
    }

    public string? GetName(bool someCondition)
    {
        return someCondition ? _options.FirstName : _options.SecondName;
    }
}
