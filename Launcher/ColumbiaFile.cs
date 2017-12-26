
namespace Jasarsoft.Columbia
{
    internal class ColumbiaFile
    {
        private readonly bool valid;
        private readonly string name;
        private readonly long size;
        private readonly string hash;
        private readonly string link;


        public ColumbiaFile(bool valid, string name, long size, string hash, string link)
        {
            this.valid = valid;
            this.name = name;
            this.size = size;
            this.hash = hash;
            this.link = link;
        }


        public bool Valid
        {
            get { return this.valid; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public long Size
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
    }
}
