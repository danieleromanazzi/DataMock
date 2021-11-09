using DataMock.Behaviors;
using DataMock.Configuration;
using DataMock.Customization;
using DataMock.Customization.Ini;
using DataMock.Handlers;
using DesignTimeMock.Handlers;
using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace DataMock.Wpf
{
    public class MockExtension : MarkupExtension
    {
        public MockExtension()
        {
            Configure.Current.AddHandler(typeof(Brush), new BrushGeneratorHandler())
                             .AddHandler(typeof(ImageSource), new ImageGeneratorHandler())
                             .AddBehavior<ImageBehavior>(new ImageBehavior() 
                             { 
                                 Width = 200,
                                 Height = 200,
                                 PixelArtSize = 50
                             });
        }

        public Type Type
        {
            get; set;
        }

        public string ConfigurationName
        {
            get; set;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            ICustomization configuration = null;

            if (!string.IsNullOrWhiteSpace(ConfigurationName))
            {
                configuration = new Customizer(Type.Assembly, ConfigurationName);
            }
            
            var instance = Activator.CreateMock.MockingData(Type, configuration);
            return instance;
        }
    }
}
