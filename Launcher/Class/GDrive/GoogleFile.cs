
namespace Jasarsoft.Columbia
{
    internal class GoogleFile
    {
        private string id;
        private bool valid;
        private string file;
        private string hash;
        private long size;


        public GoogleFile(string id, bool valid, string file, string hash, long size)
        {
            this.id = id;
            this.valid = valid;
            this.file = file;
            this.hash = hash;
            this.size = size;            
        }

        public string Id
        {
            get { return this.id; }
        }

        public bool Valid
        {
            get { return this.valid; }
        }

        public string File
        {
            get { return this.file; }
        }

        public string Hash
        {
            get { return this.hash; }
        }

        public long Size
        {
            get { return this.size; }
        }
    }
}
