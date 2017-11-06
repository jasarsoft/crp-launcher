
namespace Jasarsoft.Columbia
{
    internal class BaseColumn
    {
        private readonly string valid;
        private readonly string name;
        private readonly string path;
        private readonly string size;
        private readonly string hash;
        private readonly string link;
        private readonly string url;


        public BaseColumn()
        {
            this.valid = "valid";
            this.name = "name";
            this.path = "path";
            this.size = "size";
            this.hash = "hash";
            this.link = "fileid";
            this.url = "url";
            
        }


        public string Valid
        {
            get { return this.valid; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Path
        {
            get { return this.path; }
        }

        public string Size
        {
            get { return this.size; }
        }

        public string Hash
        {
            get { return this.hash; }
        }

        public string Link
        {
            get { return this.link; }
        }

        public string Url
        {
            get { return this.url; }
        }
    }
}
