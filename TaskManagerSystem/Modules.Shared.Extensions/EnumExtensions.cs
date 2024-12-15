using System.ComponentModel;
using System.Reflection;

namespace Modules.Shared.Extensions;

public static class EnumExtensions
{
    public static string GetDescription<TEnum>(this TEnum value) where TEnum : Enum
    {
        var field = typeof(TEnum).GetField(value.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }
}