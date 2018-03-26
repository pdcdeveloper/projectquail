using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Microsoft.Toolkit.Uwp.Helpers;

namespace pqcommonui
{
    public partial class Styles
    {
        public Styles()
        {
            this.InitializeComponent();

            // Check application theme.
            ResourceLoader resourceLoader = null;
            switch (Application.Current.RequestedTheme)
            {
                case ApplicationTheme.Dark:
                    resourceLoader = ResourceLoader.GetForViewIndependentUse("pqcommonui/ColorsDark");
                    break;

                // todo
                case ApplicationTheme.Light:
                    resourceLoader = ResourceLoader.GetForViewIndependentUse("pqcommonui/ColorsDark");
                    break;
            }

            CommentAuthorColor = new SolidColorBrush(resourceLoader.GetString("CommentAuthor").ToColor());
            GenericButtonBackgroundColor = new SolidColorBrush(resourceLoader.GetString("GenericButtonBackground").ToColor());
        }

        public SolidColorBrush CommentAuthorColor { get; set; }
        public SolidColorBrush GenericButtonBackgroundColor { get; set; }

    }
}
