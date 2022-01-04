using HD_Verbinde_Laufwerk;
using System.Diagnostics;

string username = Environment.UserName;
Console.WriteLine("Hallo" + username + "\n" + "Bitte Passwort eingeben!");
string password = Console.ReadLine();

if (password == null)
{

}
else
{
    starten();
}

void starten()
{
    Console.WriteLine("Deine Netzlaufwerke werden nun neu hinzugefügt.\n");
    beginn();
    Thread.Sleep(500);
    Console.WriteLine("\n");
    


    //Laufwerke trennen
    //Hier müssen alle Netzlaufwerke eingetragen werden 
    //Beispiel
    TrenneNetzLaufwerk("L:");
    TrenneNetzLaufwerk("S:");
    


    //Laufwerke neu verbinden
    //Benötigt den Laufwerksbuchstaben + Pfad
    //Beispiel
    VerbindeNetzLaufwerk("L:", @"\\192.168.100.1\Laufwerk_L");
    VerbindeNetzLaufwerk("S:", @"\\192.168.100.1\Laufwerk_S");



}

//Erstellt einen Fortschrittsbalken
void Fortschritt(string progressText)
{
    Console.Write(progressText);
    using (var progress = new progressBar())
    {
        for (int i = 0; i <= 100; i++)
        {
            progress.Report((double)i / 100);
            Thread.Sleep(10);
        }
    }
    Console.WriteLine("Fertig.");
}

void beginn()
{
    Console.WriteLine(@"     #####");
    Console.WriteLine(@"    #### _\_  ________");
    Console.WriteLine(@"    ##=-[.].]| \      \");
    Console.WriteLine(@"    #(    _\ |  |------|");
    Console.WriteLine(@"     #   __| |  ||||||||");
    Console.WriteLine(@"      \  _ /  |  |||||||| ");
    Console.WriteLine(@"   .--'--' -. |  | ____ |");
    Console.WriteLine(@"  / __      `| __ |[o__o] |");
    Console.WriteLine(@"_(____nm_______ / ____\____");
    Console.WriteLine("");

}

//Verbindet das Laufwerk
void VerbindeNetzLaufwerk(string laufwerk, string pfad)
{

    Fortschritt(string.Format("Laufwerk {0} wird neu verbunden. ", laufwerk));
    Process p = new Process();
    p.StartInfo.FileName = "net";
    p.StartInfo.Arguments = string.Format("use {0} {1} /user:{2} {3}", laufwerk, pfad, username, password);
    p.StartInfo.UseShellExecute = false;
    p.Start();
}

//Trennt das Laufwerk
void TrenneNetzLaufwerk(string laufwerk)
{
    
    Fortschritt(string.Format("Verbindung mit Laufwerk {0} wird getrennt. ", laufwerk));
    Thread.Sleep(500);
    Process p = new Process();
    p.StartInfo.FileName = "net";
    p.StartInfo.Arguments = string.Format("use {0} /DELETE /Y", laufwerk);
    p.StartInfo.UseShellExecute = false;
    p.Start();
    Thread.Sleep(500);
}