using System.ComponentModel;

namespace Zartis.Core.Enums
{
    public enum Availability
    {
        [Description("out of platform")]
        OutOfPlatform,

        [Description("clash")]
        Clash,

        [Description("ok for landing")]
        OkForLanding
    }
}
