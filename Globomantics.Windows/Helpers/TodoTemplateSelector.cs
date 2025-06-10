using System;
using System.Windows;
using System.Windows.Controls;
using Globomantics.Domain;

namespace Globomantics.Windows;

public class TodoTemplateSelector : DataTemplateSelector
{
    public DataTemplate BugTemplate { get; set; } = default!;
    public DataTemplate FeatureTemplate { get; set; } = default!;

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
       
        return item switch
        {
            Bug => BugTemplate,
            Feature => FeatureTemplate,
            _ => throw new NotImplementedException()
        };
    }
}