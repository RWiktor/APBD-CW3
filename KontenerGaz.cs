namespace APBD_CW3;

public class KontenerGaz : Kontener, IHazardNotifier
{
    public double Cisnienie { get; set; }

    public KontenerGaz(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc, double cisnienie) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc, "G")
    {
        Cisnienie = cisnienie;
    }
    
    public void WyslijNotyfikacje()
    {
        Console.WriteLine("UWAGA! Wystąpiła niebezpieczna sytuacja dla kontenera: " + NumerSeryjny);
    }

    public void ZaladujKontener(double masaLadunku)
    {
        if (MasaLadunku + masaLadunku > MaksymalnaLadownosc)
        {
            WyslijNotyfikacje();
            throw new OverfillException();
        }
        
        base.ZaladujKontener(masaLadunku);
    }
    
    public void OproznijLadunek()
    {
        MasaLadunku = MasaLadunku*0.05;
        Console.WriteLine("Oprozniono ladunek dla kontenera: " + NumerSeryjny);
    }
}