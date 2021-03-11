using System;

namespace NethereumBlazor.Messages
{
    public class UrlChanged
    {
        public UrlChanged(string url)
        {
            Console.WriteLine("Url: " + url);
            Url = url;
        }

        public string Url { get; }
    }
}
