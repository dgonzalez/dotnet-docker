using System;
namespace DocumentManager.Controllers.Domain
{
    public class Document
    {
        public string title { get; set; }
        public int pageCount { get; set; }

        public Document()
        {
        }

        public Document(String title, int pageCount) {
            this.title = title;
            this.pageCount = pageCount;
        }
    }
}
