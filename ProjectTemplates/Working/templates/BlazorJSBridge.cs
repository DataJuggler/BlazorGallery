using Microsoft.JSInterop;
using System.Drawing;


namespace DataJuggler.BlazorGallery
{
    public class BlazorJSBridge
    {
        public async static Task<int> CopyToClipboard(IJSRuntime jsRuntime, string textToCopy)
        {
            // set the value
            int copied = await jsRuntime.InvokeAsync<int>("BlazorJSFunctions.CopyText", textToCopy);

            // return value
            return copied;
        }
    }
}
