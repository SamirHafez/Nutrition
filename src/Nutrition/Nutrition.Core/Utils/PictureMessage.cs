using Cirrious.MvvmCross.Plugins.Messenger;

namespace Nutrition.Core.Utils
{
    public class PictureMessage : MvxMessage
    {
        public PictureMessage(object sender) : base(sender)
        { }

        public byte[] Picture { get; set; }
        public uint Width { get; set; }
        public uint Height { get; set; }
    }
}
