using System;

namespace Jasarsoft.Columbia
{
    public class About
    {
        private readonly string title;
        private readonly string version;
        private readonly string date;
        private readonly string license;
        private readonly string copyright;
        private readonly string developer;
        private readonly string description;


        public About()
        {
            this.title = "Columbia State Launcher";
            this.version = "1.0.0.0 Alpha";
            this.date = "21. oktobar 2017";
            this.license = "Vlasnički softver";
            this.copyright = "Columbia State Team";
            this.developer = "Edin (jasarsoft) Jašarević";
            this.description = "Columbia State Launcher napravljen u cilju lakšeg korištenja, bezbjednog pristupa te automatskog ažuriranja Columbia State moda za GTA San Andreas Multiplayer.";
        }

        public string Title
        {
            get { return this.title; }
        }

        public string Version
        {
            get { return this.version; }
        }

        public string Date
        {
            get { return this.date; }
        }
        public string License
        {
            get { return this.license; }
        }

        public string Copyright
        {
            get { return this.copyright; }
        }

        public string Developer
        {
            get { return this.developer; }
        }

        public string Description
        {
            get { return this.description; }
        }
    }
}
