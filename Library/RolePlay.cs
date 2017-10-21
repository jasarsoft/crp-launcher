using System;
using System.Text;

namespace Jasarsoft.Columbia.Library
{
    public class RolePlay
    {
        private readonly string[] text;
        private readonly string[] title;


        public RolePlay()
        {
            title = new string[]
            {
                "IC - In Character",
                "OCC - Out Of Character",
                "MG - MetaGaming",
                "PG - PowerGaming",
                "LTA - Leave to Avoid",
                "BH - Bunny Hopping",
                "DM - Deatmatch",
                "SK - Spawn Kill",
                "NJ - Ninja Jack",
                "DB - Drive By",
                "RK - Revenge Kill",
                "RPS - RP Supermen",
                "GFA - Gun From ASS",
                "DFA - Drug From ASS",
                "PVP - Player vs Player",
                "CK - Carachter Kill",
                "RPW - RP2WIN",
                "AA - Admin Abusing",
                "Ex - Exploiting",
                "QS - QuickSwapping",
                "ERC - Exploiting the red circle",
                "KOS - Kill on Sight",
                "CS - CrackShoting",
                "PvE - Player vs Enviroment",
                "CR - ChickenRunning",
                "Spam - Spamming"
            };

            text = new string[]
            {
                //In Character
                "In Character se koristi u svim chat-ovima u igri osim /o, /b i /report, služi za komunikaciju za drugim igračima i u njega se piše SAMO ono što ima veze sa Vašim virtualnim karakterom. U IC chatu ne pišemo smajlije i sva ostala komunikativna sredstva koja nisu realna i nisu vezana za radnju Vašeg virtualnog lika.",
                //Out Of Character
                "Out Of Character koristi se SAMO u /o /b i /report chat-ovima. Služi za priču o svemu što nema veze sa trenutnom situacijom u igri. U OOC chatu razgovarate o stvarima vezanim za stvarni život, npr. o sportskim dešavanjima. Takodje smijete zatražiti pomoc oko određenih komandi i sličnih stvari u /report chatu.",
                //Meta Gamming
                "MetaGaming (MG) je korištenje OOC formata u IC korist. Primjer: Idete do nekog lika a neznate ga IC i zovete ga imenom, to spada pod MG. Jasnije malo, npr. vi hodate u RL i vidite nekog čovjeka i priđete mu i zovete ga imenom, normalno ne znate mu ime jer se niste ni upoznali, tako i u SAMP-u.",
                //Power Gamming
                "PowerGaming (PG) je radnja koja nije izvodiva u RL ili u nekom datom trenutnku.\nPrimjer: /me dize zgradu , naravno u RL ne možemo dignuti zgradu to je PG.\n/me jede zgradu, također je i ovo PG, jer u RL ne možemo jesti kuću.",
                //Leave to Avoid
                "Leave to Avoid (LTA) je napuštanje servera da bi se nešto izbjeglo.\nPrimjer: Policija vas treba uhapsiti vi napustite server.",
                //Bunny Hopping
                "Bunny Hopping (BH) je učestalo skakanje prilikom trčanja s ciljem bržeg trčanja i sl.\nPrimjer: Ganja Vas policajac, trči za Vama a Vi lagano počnete skakati prema npr. autu da bi prije stigli i pobjegli mu.",
                //Deathmatch
                "Deatmatch (DM) je ubijanje naokolo bez dovoljno RP razloga.\nPrimjer: Kupite oruzje u Gun Shop-u i sada do svakog lika odete i ubijete ga.",
                //Spawn Kill
                "Spawn Kill (SK) je učestalo ubijanje igrača na Spawn-u.\nPrimjer: Vi odete do nečije kuće od nekog lika vidite ga i ubijete ga pa čekate opet da se spawna i opet ubijete ga.",
                //Ninja Jack
                "Ninja Jack (NJ) je NON RP krađa vozila.\nPrimjer: Neko vozi auto i uspori malo a Vi stisnete enter i ukradete mu auto te pobjegnete.",
                //Drive By
                "Drive By (DB) je pucanje i gaženje s mjesta vozača, i ubijanje elisom helikoptera.\nPrimjer: Vozite se gradom (bandit ste) i policajac Vam govori da stanete i dođe Vam s boka a Vi imate MP5 i počnete pucati na njega, ili imate helikopter i vidite ispred Burga neko okupljanje i zaletite se i elisom ih pobijete.",
                //Revenge Kill
                "Revenge Kill (RK) je ubijanje iz osvete igrača. Primjer: Neki Hitman ima Vas kao metu, i on Vas ubije a Vi mu zapamtite ime i dođete nakon 5-minuta sa M4 i kažete eh ti si mene ubio evo ti sad.\nRevenge kill je takodje dio Metagaminga, jer koristite OOC informacije da rješite IC probleme.",
                //RP Supermen
                "RP Supermen je ponašanje igrača da je on kao najjači i da mu niko ništa ne može, ne boji se ničega, nije mu bitno hoće li poginuti.",
                //Gun From ASS
                "Gun From ASS (GFA) je vađenje oružja bez korištenja /me i /do komande. Primjer: Idete gradom i vidite nekog lika koji Vam je smetao u životu i izvadite oružje na brzinu bez korištenja /me i /do komande.\nKako je pravilno izvaditi oružje?\n/me vadi pištolj sa desnog pasa\n/do u ruci mi je.",
                //Drug From ASS
                "Drug From ASS (DFA) je nonRP korišćenje droge, bez /me i /do komande. Kako je pravilno koristiti drogu?\n/me vadi vrećiću (droge ,brasna) iz dzepa\n/do izvadio\n/me istresa (drogu ,brasno) na sto\n/do smrce drogu sa stola.",
                //Player vs Player
                "Player vs Player (PVP) je napadanje nedužnog civila bez razloga, iživljavanje na njemu.",
                //Charachter Kill
                "Carachter Kill (CK) je tjeranje igrača da promjeni ime ili da napravi novi account.\nPrimjer: Stalno ga CK-ate i mučite.",
                //RP2 WIN
                "RP2WIN ponavljano korišćenje neke komande ili ponavljano mjenjanje IC priče kako bi izašli kao pobjednik iz RP-anja.\nPrimjer: Dođe vam policajac pretresa Vas pregleda dozvole sve ok. Kaže otvorite gepek a Vi u gepeku imate Silenced Pistol i ostala oružja. Vi otvorite on pretrese.\n/do Da li vidim Silenced Pistol u gepeku?\n/do Ne, ne vidiš ga zato što je ispao u gepekovi šupljinu.",
                //Admin Abusing
                "Admin Abusing (AA) je iskorištavanje Admin komandi u svoju korist.\nPrimjer: Igrate WAR ili VS s nekim i on Vam do pola skine health(zdravlje) a Vi sebi nadopunite (/sethp ID 100).",
                //Exploting
                "Exploiting je korištenje bilo kakvih poznatih/nepoznatih bug-ova/propusta u igri ili skripti. U to se ubraja i skupljanje spawnova novaca, uzimanje CJ skina i sl.\nPrimjer: Namjerno uzmete CJ skin kako bi brže trčali ili razvalite banderu za naplatu parkinga te pokupite pare.",
                //Quick Swapping
                "QuickSwapping (QS) je brzo mjenjanje oružje na Q i E bez korištenja /me i /do komande.",
                //Exploiting the Red Circle
                "Iskorištavanje crvenih check point-a u burgu, cluckin bellu i drugim prodavnicama, kad stanete na crveni marker server vas zaledi i izađe vam meni da izaberete sta želite kupiti, za to vrijeme niko ne može da vas ubije.",
                //Kill on Sight
                "Kill on Sight (KOS) je ubijanje igrača po viđenju, bez upozorenja, korištenja chata...",
                //CrackShoting
                "CrackShoting (CS) je iskorištavanje bugova sa oružjem, deagle i combat shotgun pucaju većom brzinom iz vozila.",
                //Player vs Enviroment
                "Player vs Enviroment (PvE) je divljanje i pucanje po okolini i ugrožavanje nečije imovine.",
                //ChickenRunning
                "ChickenRunning (CR) je trčanje cik-cak kako bi izbegli metke i preživeli.",
                //Spam
                "Spamming - Pisanje iste riječi ili rečenice dva ili više puta za redom. Jedino opravdanje vašeg Spam-anja može biti lag ili nešto slično. Ili slanje poruke poslije svake napisanje riječi...\n\nPrimjer:\nPetar_Petrovic: E\nPetar_Petrovic: ajde\nPetar_Petrovic: mi\nPetar_Petrovic: daj\nPetar_Petrovic: admina...",
            };
        }


        public string[] Text
        {
            get { return this.text; }
        }

        public string[] Title
        {
            get { return this.title; }
        }

    }
}
