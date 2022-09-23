using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Maui.Animations;

namespace Maui.ToolKitMaui.Animations
{
    class SampleScaleAnimation : BaseAnimation
    {
        public override async Task Animate(VisualElement view)
        {
            await view.ScaleTo(1.2, Length, Easing);
            await view.ScaleTo(1, Length, Easing);
        }
    }

    class SampleScaleToAnimation : BaseAnimation
    {
        public double Scale { get; set; }

        public override Task Animate(VisualElement view) => view.ScaleTo(Scale, Length, Easing);
    }
}
