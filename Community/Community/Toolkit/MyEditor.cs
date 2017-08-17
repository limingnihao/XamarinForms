using System;
using Xamarin.Forms;

namespace Community.Toolkit
{
    public class MyEditor : Editor
    {
        public MyEditor()
        {
            this.TextChanged += (sender, e) =>
            {
                InvalidateMeasure();
            };
        }
    }
}
