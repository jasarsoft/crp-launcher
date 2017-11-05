using System;

namespace Jasarsoft.Columbia.Library
{
    public class GoogleApi
    {
        StringCipher sc;

        private readonly string key;
        private readonly string email;

        public GoogleApi()
        {
            this.sc = new StringCipher();

            this.key = "yvp7Qd1smCo6Fd+W3teQpem6SY1wI1I0IekeVog+zg9LU9YVZ1eVy2OihXnibdIP3hnJAR5FEW947LFQG4HYwHDe7+JPX08wCGmuPXvPbBZVnk5h9+1SB0a1SliD4h04";
            this.email = "jG45OJwMGCOXxM2W4DDjmlaH8xWR4g/ctOi2wMxr3gncwh8c//8w8bRR0OvgRF9oM2ILl/5fIfhrI4XJUQ2ijt4RJunzhm+oaOYsSLRzZH7zgMNYfutu65QCCve8NTH0WJm9YzviPYfsn55eD/eE3Q9yrE5KMo2JlpIKeyq0Crg=";
        }


        public string Key
        {
            get { return this.sc.Decrypt(this.key); }
        }

        public string Email
        {
            get { return this.sc.Decrypt(this.email); }
        }
    }
}
