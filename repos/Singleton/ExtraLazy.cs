using System;

namespace Singleton
{
    public sealed class ExtraLazy
    {
        private ExtraLazy()
        {
        }
        private static readonly Lazy<ExtraLazy> lazy = new Lazy<ExtraLazy>(() => new ExtraLazy());
        public static ExtraLazy Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
}
