namespace UITest.RegressionCommon.Models
{
    using System.Drawing;

    /// <summary> The size factory. </summary>
    public static class SizeFactory
    {
        /// <summary> The default landscape. </summary>
        /// <returns> The <see cref="Size" />. </returns>
        public static Size DefaultLandscape()
        {
            return new Size(1024, 768);
        }

        /// <summary> The default portrait. </summary>
        /// <returns> The <see cref="Size" />. </returns>
        public static Size DefaultPortrait()
        {
            return new Size(768, 1024);
        }

        /// <summary> The samsung s 4. </summary>
        /// <returns> The <see cref="Size" />. </returns>
        public static Size SamsungS4()
        {
            return new Size(360, 640);
        }
    }
}